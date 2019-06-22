using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Api.Messages;
using System;

using Assets.SimpleAndroidNotifications;

public class OnlineMultiplayer:MonoBehaviour
{
    private static GameObject gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
    public static string playerTurn_UserId;
    public static int playerNo, markerNo, dice_value;
    public static int change_turn = 0;
    public static bool check_LoadValues = false;
    public static int check_LoadValuesCount = 0;
    public static string who;
    public static int counter = 0;

    public static int[] markerNo_array = new int[5];
    public static int[]dice_value_array = new int[5];


    public static List<int> markerNo_list = new List<int>();
    public static List<int> dice_value_list = new List<int>();

    public static int points;



    public static void SendValues(int m, int d, int ct, int p, string event_key)
    {

        new LogChallengeEventRequest().SetChallengeInstanceId(MakeAMatch.challengeId).SetEventKey("2_PLAYER_CHALLENGE_DATA")
                                      .SetEventAttribute("M", m).SetEventAttribute("D", d).SetEventAttribute("CT", ct).SetEventAttribute("P", p).SetDurable(true).
          Send((response) =>
          {
              if (!response.HasErrors)
              {
                  Debug.Log("Values Sent Successfully!");
              }
              else
              {
                  Debug.Log("Couldn't send values!");
              }
          });
    }

    public static void ChallengeTurnTakenListener(){
        ChallengeTurnTakenMessage.Listener = (message) => {
            Debug.Log(message.Who + " has taken his turn!");
            GameInitializer.fillAmount = 0.92f;
            ChallengeTurnTakenMessage._Challenge challenge_data = message.Challenge;
            playerTurn_UserId = challenge_data.NextPlayer;
            GameObject game_Manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
            if ((GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS && GameController.playerTurn == 0))
            {
                GameController.playerTurn = game_Manager.GetComponent<PlayerActivation>().ChangePlayer(GameController.playerTurn);
                game_Manager.GetComponent<GameController>().dice = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[GameController.playerTurn]);
                game_Manager.GetComponent<GameController>().checkLoop_AI_Dice = false;
                game_Manager.GetComponent<GameController>().checkLoop_AI_Marker = false;
                GameController.checkChangeTurn = false;
                GameController.GAME_STATE = GameConstants.DICE_ROLL;
            }
            who = message.Who;
            Debug.Log(who + " has taken his turn!");

            if (who != MakeAMatch.displayName)
            {
                GSData scriptData = message.Challenge.ScriptData.GetGSData("data");
                int diceValue = (int)scriptData.GetInt("d");
                points = (int)scriptData.GetInt("p");
                GameInitializer.points = points;

                //set points
                GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

                //Exit turn of leaving player
                if (GameInitializer.NoOfPlayers == 2 && points == 0)
                {
                    GameInitializer.SetValues_YouWin();
                    Debug.Log("You Oppenent Left The Game!");
                    ShowToast.MyShowToastMethod("Your opponent left the Game!");
                }
                if (points == 0)
                {
                    game_manager.GetComponent<GameInitializer>().ChangeTurn(0);
                }

                if (who == GameInitializer.Player2Name.text)
                {
                    game_manager.GetComponent<GameInitializer>().player2Points_text.text = "" + points;
                    if (points == 0)
                    {
                        game_manager.GetComponent<GameInitializer>().player[1].SetActive(false);
                        GameInitializer.player2_out = true;
                    }
                }
                else if (who == GameInitializer.Player3Name.text)
                {
                    game_manager.GetComponent<GameInitializer>().player3Points_text.text = "" + points;
                    if (points == 0)
                    {
                        game_manager.GetComponent<GameInitializer>().player[2].SetActive(false);
                        GameInitializer.player3_out = true;
                    }
                }
                else if (who == GameInitializer.Player4Name.text)
                {
                    game_manager.GetComponent<GameInitializer>().player4Points_text.text = "" + points;
                    if (points == 0)
                    {
                        game_manager.GetComponent<GameInitializer>().player[3].SetActive(false);
                        GameInitializer.player4_out = true;
                    }
                }

                if (diceValue == -1)
                {
                    GameObject gameController = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                    gameController.GetComponent<GameInitializer>().ChangeTurn(1);
                }
                else
                {
                    markerNo_list.Add((int)scriptData.GetInt("m"));
                    dice_value_list.Add((int)scriptData.GetInt("d"));

                    Debug.Log("Counter: " + counter);
                    if (counter == 0)
                    {
                        MoveOpponent(markerNo_list[counter], dice_value_list[counter]);
                    }
                }
            }
        };
    }


    public static void  MoveOpponent(int mn, int dv){
        counter++;
        playerNo = GameController.playerTurn;
        markerNo = mn;
        dice_value = dv;
        GameController.onlineMultiplayer_diceRoll = true;
    }

    public static IEnumerator checkInternetConnection(Action<bool> action)
    {
        GameController.internetCheck = true;
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }


}
