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





    public static void SendValues(int m, int d, int ct, string event_key)
    {

        new LogChallengeEventRequest().SetChallengeInstanceId(MakeAMatch.challengeId).SetEventKey("2_PLAYER_CHALLENGE_DATA")
                                      .SetEventAttribute("M", m).SetEventAttribute("D", d).SetEventAttribute("CT", ct).SetDurable(true).
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
            ChallengeTurnTakenMessage._Challenge challenge_data = message.Challenge;
            playerTurn_UserId = challenge_data.NextPlayer;
            who = message.Who;

            if (who != MakeAMatch.displayName)
            {
                GSData scriptData = message.Challenge.ScriptData.GetGSData("data");
                markerNo_list.Add((int)scriptData.GetInt("m"));
                dice_value_list.Add((int)scriptData.GetInt("d"));


                if (counter == 0)
                {
                    MoveOpponent(markerNo_list[counter], dice_value_list[counter]);
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
