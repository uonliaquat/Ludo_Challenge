using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Api.Messages;
using GameSparks.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MakeAMatch:MonoBehaviour
{
    public static string[] playerNames = new string[4];
    public static string[] playerIDs = new string[4];
    private static int count = 0;
    public static string challengeId;
    public static string userId;
    public static string displayName;
    public static string opponents_image_id = "0";
    public static List<string> opponents_image_ids = new List<string>();
    public static List<string> opponents_name = new List<string>();
    private static string messageToSend;
    private static bool isOppnentsImageID_received = false;
    private static bool messageReceived = false;
    private static int counter = 0;
    public static string chat_message;
    public static string FB_opponentsImageURL;
    public static int noOfPlayersLeftTheGame = 0;


    public static void MakeMatch(int cost, string match_name)
    {
        OnlineMultiplayer.markerNo_list.Clear();
        OnlineMultiplayer.dice_value_list.Clear();

        opponents_name.Clear();
        opponents_image_ids.Clear();

        isOppnentsImageID_received = false;
        messageToSend = Database.GetDisplayImageUplaodId(Register.userId);
        Debug.Log("Making a match.....");
        UserAccountDetails();
        ChallengeSatrtedListener();
        MatchFoundListener();
        MatchNotFoundListener();
        ChatOnChallegeListener();
        new MatchmakingRequest().SetSkill(cost).SetMatchShortCode(match_name)
       .Send((response) =>
       {
           if (!response.HasErrors)
           {
               string game = "";
               if (Register.Game == GameConstants.LUDO_CHALLENGE)
               {
                   game = GameConstants.LUDO_CHALLENGE;
               }
               else
               {
                   game = GameConstants.SNAKES_AND_LADDER;
               }

               if (MainMenu.roomForPlayers == 2)
               {
                   GameInitializer.SetGame(game, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
               }
               else if (MainMenu.roomForPlayers == 4)
               {
                   GameInitializer.SetGame(game, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.FOUR_PLAYERS);
               }
           }
       });

    }


    public static void ChallengeSatrtedListener(){
        ChallengeStartedMessage.Listener = (message) => {
            ChallengeStartedMessage._Challenge challenge_data = message.Challenge;
            challengeId = challenge_data.ChallengeId;
            OnlineMultiplayer.playerTurn_UserId = challenge_data.NextPlayer;

            //Set Coins
            int coins = Database.GetPlayerCoins(userId);
            if(LoginWithFB.FacebookLoggedIn){
                coins = coins - 100;
            }
            else{
                coins = coins - MainMenu.matchCost; 
            }
            Database.SetPlayerCoins(userId, coins);

            if (LoginWithFB.FacebookLoggedIn)
            {
                messageToSend = LoginWithFB.displayName_FB + "/" + messageToSend;
            }
            else{
                messageToSend = displayName + "/" + messageToSend;
            }
            Debug.Log(messageToSend);
            ChatOnChallengeRequest(challengeId, messageToSend);

        };

    }


    public static void MatchFoundListener(){
        
        MatchFoundMessage.Listener = (message) =>
        {
            if(LoginWithFB.FacebookLoggedIn){
                isOppnentsImageID_received = false;
                messageToSend = LoginWithFB.url;
            }
            ShowToast.MyShowToastMethod("Match Made:");
            GSEnumerable<MatchFoundMessage._Participant> participants = message.Participants;
            foreach (MatchFoundMessage._Participant i in participants)
            {
                playerNames[count] = i.DisplayName;
                playerIDs[count] = i.Id;
                count++;
            }

        };
    }


    public static void MatchNotFoundListener(){
        MatchNotFoundMessage.Listener = (message) =>
        {

            Debug.Log("Couldn't find Match!");
            ShowToast.MyShowToastMethod("Couldn't Find Match");
            if (!MainMenu.friendList_canvas.GetComponent<CanvasGroup>().interactable)
            {
                MainMenu.friendList_canvas.GetComponent<CanvasGroup>().interactable = true;
            }
            if (MainMenu.challengeResponse_canvas.enabled)
            {
                MainMenu.challengeResponse_canvas.enabled = false;
            }
            MainMenu.searchingForPlayer_canvas.enabled = false;
            MainMenu.searchingForPlayer_anim.SetActive(false);
            MainMenu.searchingForPlayerTimeRemaining_text.enabled = false;
            MainMenu.isSearchingForPlayer = false;
            MainMenu.timeLeftToSearchPlayer = 60.0f;

            if (!LoginWithFB.FacebookLoggedIn)
            {
                MainMenu.messageBox_text.text = "Couldn't Find Match!";
                MainMenu.messageBox_canvas.enabled = true;
                MainMenu.disableMessageBox = true;
            }
        };

    }

    public static void UserAccountDetails(){
        new AccountDetailsRequest().Send((response) =>
        {
            displayName = response.DisplayName;
            userId = response.UserId;
        });
    }


    public static void ChatOnChallengeRequest(string challengeInstanceId, string message)
    {
        new ChatOnChallengeRequest().SetChallengeInstanceId(challengeInstanceId).SetMessage(message).Send((response) =>
        {
            if(!response.HasErrors){
                Debug.Log("Message Sent!");
            }
            else
            {
                Debug.Log("Couldnt Send Message!");
                MainMenu.messageBox_btn.GetComponent<Text>().text = "Connection Unstable!";
                MainMenu.messageBox_canvas.enabled = true;
                MainMenu.disableMessageBox = true;
            }
        });

    }

    public static void ChatOnChallegeListener()
    {
        ChallengeChatMessage.Listener = (message) =>
        {
            chat_message = "";
            if(message.Message.Contains("////")){
                int j = 0;
                for (int i = 0; i < message.Message.Length; i++){
                    if(message.Message[i] == ' ' && message.Message[i + 1] == ' ' && message.Message[i + 2] == ' '){
                        j = i + 3;
                        for (int k = j; k < message.Message.Length; k++){
                            chat_message =  chat_message + message.Message[k];
                        }
                        break;
                    }
                }

                if (chat_message == "EndGame")
                {
                    if (GameInitializer.NoOfPlayers == GameConstants.TWO_PLAYERS)
                    {
                        if (GameInitializer.messageToSend != "EndGame")
                        {
                            GameInitializer.SetValues_YouWin();
                            Debug.Log("You Oppenent Left The Game!");
                            ShowToast.MyShowToastMethod("Your opponent left the Game!");
                        }
                    }
                    else
                    {
                        GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

              


                        if(message.Message.Contains(GameInitializer.Player2Name.text)){
                            Debug.Log(GameInitializer.Player2Name.text + " left the Game!");
                            ShowToast.MyShowToastMethod(GameInitializer.Player2Name.text + " left the Game!");
                            game_manager.GetComponent<GameInitializer>().player[1].SetActive(false);
                            GameInitializer.player2_out = true;

                        }   
                        else if (message.Message.Contains(GameInitializer.Player3Name.text))
                        {
                            Debug.Log(GameInitializer.Player3Name.text + " left the Game!");
                            ShowToast.MyShowToastMethod(GameInitializer.Player3Name.text + " left the Game!");
                            game_manager.GetComponent<GameInitializer>().player[2].SetActive(false);
                            GameInitializer.player3_out = true;
                        }
                        else if (message.Message.Contains(GameInitializer.Player4Name.text))
                        {
                            Debug.Log(GameInitializer.Player4Name.text + " left the Game!");
                            ShowToast.MyShowToastMethod(GameInitializer.Player4Name.text + " left the Game!");
                            game_manager.GetComponent<GameInitializer>().player[3].SetActive(false);
                            GameInitializer.player4_out = true;
                        }


                    
                    }
                }

                for (int i = 0; i < opponents_name.Count; i++){
                    if(message.Message.Contains(opponents_name[i])){
                        if (GameInitializer.Player2Name.text == opponents_name[i])
                        {
                            GameInitializer.player2Message = true;
                        }
                        else if (GameInitializer.Player3Name.text == opponents_name[i])
                        {
                            GameInitializer.player3Message = true;
                        }
                        else if (GameInitializer.Player4Name.text == opponents_name[i])
                        {
                            GameInitializer.player4Message = true;
                        }
                    }
                }
                return;
            }

            counter++;
            string name = "", id = "";
            bool nameChecked = false;
            for (int i = 0; i < message.Message.Length; i++){
                if(message.Message[i] != '/' && !nameChecked){
                    name = name + message.Message[i];
                }
                if (nameChecked)
                {
                    id =  id + message.Message[i];
                }
                if(message.Message[i] == '/'){
                    nameChecked = true;
                }
            }
            Debug.Log(message.Message);
            if (LoginWithFB.FacebookLoggedIn)
            {
                nameChecked = false;
                if (name != LoginWithFB.displayName_FB)
                {
                    Debug.Log("Oppenent Name: " + name);
                    Debug.Log("Oppenent ID: " + id);
                    opponents_name.Add(name);
                    opponents_image_ids.Add(id);
                }

            }
            else
            {
                nameChecked = false;
                opponents_name.Add(name);
                opponents_image_ids.Add(id);
            }

            if (GameInitializer.NoOfPlayers == 2 && counter >= 2)
            {
                isOppnentsImageID_received = true;
                if (LoginWithFB.FacebookLoggedIn)
                {

                    try
                    {
                        if (MainMenu.challengeResponse_canvas.enabled)
                        {
                            MainMenu.challengeResponse_canvas.enabled = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
                else{

                    //MainMenu.searchingForPlayer_canvas.enabled = false;
                    //MainMenu.searchingForPlayer_anim.SetActive(false);
                }
                //SceneManager.LoadScene("GamePlay");
                StartMenu.startGame = true;
            }
            else if (GameInitializer.NoOfPlayers == 4 && counter >= 4)
            {
                //Start Game
                isOppnentsImageID_received = true;
                //MainMenu.searchingForPlayer_canvas.enabled = false;
                //MainMenu.searchingForPlayer_anim.SetActive(false);
                //SceneManager.LoadScene("GamePlay");
                StartMenu.startGame = true;
            }

        };
    }

}
