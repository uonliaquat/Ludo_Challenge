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

public class MakeAMatch:MonoBehaviour
{
    public static string[] playerNames = new string[4];
    public static string[] playerIDs = new string[4];
    private static int count = 0;
    public static string challengeId;
    public static string userId;
    public static string displayName;
    public static string opponents_image_id = "0";
    private static string messageToSend;
    private static bool isOppnentsImageID_received = false;
    private static bool messageReceived = false;
    private static int counter = 0;

    public static void MakeMatch(int cost, string match_name)
    {
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
            if(!response.HasErrors){
               if (MainMenu.roomForPlayers == 2)
               {
                   GameInitializer.SetGame(GameConstants.LUDO_CHALLENGE, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
               }
                else if(MainMenu.roomForPlayers == 4){
                    GameInitializer.SetGame(GameConstants.LUDO_CHALLENGE, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.FOUR_PLAYERS);
                }
            }
       });

    }


    private static void ChallengeSatrtedListener(){
        ChallengeStartedMessage.Listener = (message) => {
            Debug.Log("Challenge Started!");
            ChallengeStartedMessage._Challenge challenge_data = message.Challenge;
            challengeId = challenge_data.ChallengeId;
            OnlineMultiplayer.playerTurn_UserId = challenge_data.NextPlayer;

            //Set Coins
            int coins = Database.GetPlayerCoins(userId);
            coins = coins - MainMenu.matchCost;
            Database.SetPlayerCoins(userId, coins);


            //Debug.Log("challenge started");

            //MainMenu.searchingForPlayer_canvas.enabled = false;
            //MainMenu.searchingForPlayer_anim.SetActive(false);
            ////Start Game
            //SceneManager.LoadScene("GamePlay");


            //Real
            messageToSend = displayName + " " + messageToSend;
            ChatOnChallengeRequest(challengeId, messageToSend);

        };

    }


    private static void MatchFoundListener(){
        
        MatchFoundMessage.Listener = (message) =>
        {
            Debug.Log("Match Made: ");

            GSEnumerable<MatchFoundMessage._Participant> participants = message.Participants;
            foreach (MatchFoundMessage._Participant i in participants)
            {
                playerNames[count] = i.DisplayName;
                playerIDs[count] = i.Id;
                Debug.Log(playerIDs[count]);
                count++;
            }

        };
    }


    private static void MatchNotFoundListener(){
        MatchNotFoundMessage.Listener = (message) =>
        {

            Debug.Log("Couldn't find Match!");
            MainMenu.searchingForPlayer_canvas.enabled = false;
            MainMenu.searchingForPlayer_anim.SetActive(false);

            MainMenu.messageBox_text.text = "Couldn't Find Match!";
            MainMenu.messageBox_canvas.enabled = true;
            MainMenu.disableMessageBox = true;
        };

    }

    private static void UserAccountDetails(){
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

                MainMenu.searchingForPlayer_canvas.enabled = false;
                MainMenu.searchingForPlayer_anim.SetActive(false);
            }
        });

    }

    public static void ChatOnChallegeListener()
    {
        ChallengeChatMessage.Listener = (message) =>
        {
            counter++;


            Debug.Log(message.Message);


            //Real
            //if(message.Message != "0"){
            //    isOppnentsImageID_received = true;
            //    Debug.Log(message.Message);
            //    opponents_image_id = message.Message;
            //    MainMenu.searchingForPlayer_canvas.enabled = false;
            //    MainMenu.searchingForPlayer_anim.SetActive(false);
            //    //Start Game
            //    SceneManager.LoadScene("GamePlay");
            //    return;
            //}
            //if(counter >= 2){
            //    //Start Game
            //    SceneManager.LoadScene("GamePlay");
            //}


        };
    }
}
