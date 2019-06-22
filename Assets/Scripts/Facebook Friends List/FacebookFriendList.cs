using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Api.Messages;
using GameSparks.Api;
using GameSparks.Core;

public class FacebookFriendList : MonoBehaviour
{

    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    private GameObject displayImage;
    public static int friendCount;
    public static int list_count;
    private string challenge_id;
    public static string Challenge_Game_Name;


    void Start()
    {
        scrollView.verticalNormalizedPosition = 1;
        friendCount = 0;
        list_count = 1;

    }


    public void GenerateItem(string displayName, string fb_id, bool onlineStatus, string id)
    {
        friendCount--;
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        GameObject displayNameObject = scrollItemObj.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        displayImage = scrollItemObj.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        GameObject status = scrollItemObj.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
        GameObject challengeButoon = scrollItemObj.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        if (!onlineStatus)
        {
            Color color = status.GetComponent<Image>().color;
            color.a = 0;
            status.GetComponent<Image>().color = color;
            challengeButoon.GetComponent<Button>().interactable = false;
        }
        else
        {
            Color color = status.GetComponent<Image>().color;
            color.a = 1;
            status.GetComponent<Image>().color = color;
            challengeButoon.GetComponent<Button>().interactable = true;
            challengeButoon.GetComponent<Button>().onClick.AddListener(delegate { SendChallenge(LoginWithFB.displayName_FB, displayName, id); });
        }
        displayNameObject.GetComponent<Text>().text = displayName;
        string url = "http://graph.facebook.com/" + fb_id + "/picture?width=100&height=100";
        StartCoroutine(DownloadFBImage(url));
    }


    public void GenerateItems(int count, string displayName, string fb_id, bool onlineStatus, string id)
    {
        friendCount = count;
        GenerateItem(displayName, fb_id, onlineStatus, id);
    }


    public IEnumerator DownloadFBImage(string downloadUrl)
    {
        Debug.Log("FB Image Downloding Started");
        var www = new WWW(downloadUrl);
        yield return www;
        Texture2D FB_Image = new Texture2D(100, 100, TextureFormat.Alpha8, false);
        www.LoadImageIntoTexture(FB_Image);
        Debug.Log("FB Image Downloded");
        displayImage.GetComponent<Image>().sprite = Sprite.Create(FB_Image, new Rect(0, 0, 100, 100), new Vector2(0, 0));

        if (friendCount != 0)
        {
            GenerateItems(friendCount, MainMenu.friendName[list_count], MainMenu.friendProfileId[list_count], MainMenu.onlineStatus[list_count], MainMenu.player_id[list_count]);
            list_count++;
        }
        else
        {
            MainMenu.friendName.Clear();
            MainMenu.friendProfileId.Clear();
        }
    }


    public void SendChallenge(string challengerName, string displayNameofChalengedPlayer, string id)
    {
        if (Register.isSoundPlaying)
        {
            GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
            game_manager.GetComponent<StartMenu>().audioSource.Play();
        }
        string message = LoginWithFB.displayName_FB + " challenged You!";
        string match_key = "";
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            message = GameConstants.LUDO_CHALLENGE + message + " in " + GameConstants.LUDO_CHALLENGE;
            match_key = GameConstants.TWO_PLAYERS_MATCH_100;
        }
        else{
            
            message = GameConstants.SNAKES_AND_LADDER + message + " in " + GameConstants.SNAKES_AND_LADDER;
            match_key = GameConstants.SAL_TWO_PLAYERS_MATCH_100;
        }
        List<string> ids = new List<string>();
        ids.Add(id);
        new SendFriendMessageRequest().SetFriendIds(ids).SetMessage(message).Send((response) =>
        {
            MakeAMatch.UserAccountDetails();
            MakeAMatch.ChallengeSatrtedListener();
            MakeAMatch.MatchFoundListener();
            MakeAMatch.MatchNotFoundListener();
            MakeAMatch.ChatOnChallegeListener();

            if (!response.HasErrors)
            {

                GSData scriptDat = response.ScriptData;
                Debug.Log("Message Sent");
                string jsonString = "{\"$in\":[\"" + id +"\"]}";
                GSRequestData customQuery = new GSRequestData().AddJSONStringAsObject("players.playerId", jsonString);
                new MatchmakingRequest().SetSkill(100).SetMatchShortCode(match_key).SetCustomQuery(customQuery).Send((response2) =>
                {
                    if (!response2.HasErrors)
                    {
                        MainMenu.friendList_canvas.GetComponent<CanvasGroup>().interactable = false;
                        MainMenu.challengeResponse_canvas.enabled = true;

                        GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                        StartCoroutine(game_manager.GetComponent<MainMenu>().StopWaitingForResponse(60));
                        string game = "";
                        if (Register.Game == GameConstants.LUDO_CHALLENGE)
                        {
                            game = GameConstants.LUDO_CHALLENGE;
                        }
                        else
                        {
                            game = GameConstants.SNAKES_AND_LADDER;
                        }
                        Debug.Log("Game " + game);
                        GameInitializer.SetGame(game, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
                    }
                });
            }
            else
            {
                Debug.Log("Message Not Sent!");
            }
        });
    }


    public static void ReceiveChallenge()
    {
        FriendMessage.Listener = (message) =>
        {
            if (!message.HasErrors)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                string msg = message.Message;
                if (msg.Contains("doesn't want to Play!"))
                {
                    MainMenu.challengeResponse_canvas.enabled = false;
                    MainMenu.doesntWantToPlay_text.text = msg;
                    MainMenu.doesntWantToPlay_canvas.enabled = true;
                    MainMenu.friendList_canvas.enabled = false;
                    MainMenu.friendList_canvas.GetComponent<CanvasGroup>().interactable = true;
                    GameObject game_manager = GameObject.Find("content");
                    foreach (Transform child in game_manager.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    MainMenu.friendName.Clear();
                    MainMenu.friendProfileId.Clear();
                    MainMenu.onlineStatus.Clear();
                    MainMenu.player_id.Clear();
                    friendCount = 0;
                    list_count = 1;

                    string jsonString = "{\"$in\":[\"" + message.FromId + "\"]}";
                    GSRequestData customQuery = new GSRequestData().AddJSONStringAsObject("players.playerId", jsonString);
                    string match_key = "";
                    if (Register.Game == GameConstants.LUDO_CHALLENGE)
                    {
                        match_key = GameConstants.TWO_PLAYERS_MATCH_100;
                    }
                    else
                    {
                        match_key = GameConstants.SAL_TWO_PLAYERS_MATCH_100;
                    }
                        new MatchmakingRequest().SetSkill(100).SetMatchShortCode(match_key).SetCustomQuery(customQuery).SetAction("cancel").Send((response2) =>
                    {
                        if (!response2.HasErrors)
                        {
                            Debug.Log("Match Canceled");
                        }
                    });

                    return;

                }
                string challenger_id = message.FromId;

                StartMenu.challenger_id = challenger_id;
                MainMenu.challenger_id = challenger_id;

                Debug.Log("Message: " + msg);
                //ShowToast.MyShowToastMethod(msg);
                if (sceneName == GameConstants.STARTMENU_SCENE || sceneName == GameConstants.START_MENU_SAL_SCENE)
                {
                    if (Register.isSoundPlaying)
                    {
                        GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
                        game_manager.GetComponent<StartMenu>().notificationSource.Play();
                    }
                    if (msg.Contains(GameConstants.LUDO_CHALLENGE))
                    {
                        msg = msg.Remove(0, 13);
                        Challenge_Game_Name = GameConstants.LUDO_CHALLENGE;
                    }
                    else if(msg.Contains(GameConstants.SNAKES_AND_LADDER))
                    {
                        msg = msg.Remove(0, 15);
                        Challenge_Game_Name = GameConstants.SNAKES_AND_LADDER;
                    }
                    StartMenu.challenge_msg.text = msg;
                    StartMenu.main_canvas.GetComponent<CanvasGroup>().interactable = false;
                    StartMenu.challenge_canvas.enabled = true;
                }
                else if (sceneName == GameConstants.MAINMENU_SCENE || sceneName == GameConstants.MAIN_MENU_SAL_SCENE)
                {
                    if (Register.isSoundPlaying)
                    {
                        GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                        game_manager.GetComponent<MainMenu>().notificationSource.Play();
                        Debug.Log("Played");
                    }
                    if (msg.Contains(GameConstants.LUDO_CHALLENGE))
                    {
                        msg = msg.Remove(0, 13);
                        Challenge_Game_Name = GameConstants.LUDO_CHALLENGE;
                    }
                    else if (msg.Contains(GameConstants.SNAKES_AND_LADDER))
                    {
                        msg = msg.Remove(0, 15);
                        Challenge_Game_Name = GameConstants.SNAKES_AND_LADDER;
                    }
                    Debug.Log("Split Message: " + msg);
                    MainMenu.challenge_msg.text = msg;
                    MainMenu.main_canvas.interactable = false;
                    MainMenu.challenge_canvas.enabled = true;
                }
            }

        };
    }
}
