using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;
using System;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.UI;

public class Database : MonoBehaviour
{
    //private static GameObject startMenuManager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);

    public static string DisplayName, CountryName, DisplayImage;

    public static void setPlayerDataInLocalDatabase(string _name, string country_name, int coins, string userUid)
    {
        PlayerPrefs.SetString(userUid + "playerName", _name);
        PlayerPrefs.SetString(userUid + "countryName", country_name);
        PlayerPrefs.SetInt(userUid + "coins", coins);
    }


    public static void setAllWinsAndLosesToZero(string userUid)
    {
        setVsComputerWins(userUid);
        setVsMultiplayerWins(userUid);
        setVsMultiplayerLoses(userUid);
        setVsMultiplayerLoses(userUid);
    }


    //get Wins
    public static int getVsComputerWins(string userUid)
    {

        if (PlayerPrefs.HasKey(userUid + "vsComputerWins0"))
        {
            return PlayerPrefs.GetInt(userUid + "vsComputerWins0");
        }
        else
        {
            return 0;
        }
    }

    public static int getVsComputerLoses(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsComputerLoses"))
        {
            return PlayerPrefs.GetInt(userUid + "vsComputerLoses");
        }
        else
        {
            return 0;
        }

    }

    public static int getVsMultiplayerWins(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerWins0"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerWins0");
        }
        else
        {
            return 0;
        }


    }

    public static int getVsMultiplayerLoses(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerLoses0"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerLoses0");
        }
        else
        {
            return 0;
        }

    }









    public static int getVsComputerWinsSAL(string userUid)
    {

        if (PlayerPrefs.HasKey(userUid + "vsComputerWinsSAL"))
        {
            return PlayerPrefs.GetInt(userUid + "vsComputerWinsSAL");
        }
        else
        {
            return 0;
        }
    }

    public static int getVsComputerLosesSAL(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsComputerLosesSAL"))
        {
            return PlayerPrefs.GetInt(userUid + "vsComputerLosesSAL");
        }
        else
        {
            return 0;
        }

    }

    public static int getVsMultiplayerWinsSAL(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerWinsSAL"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerWinsSAL");
        }
        else
        {
            return 0;
        }


    }

    public static int getVsMultiplayerLosesSAL(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerLosesSAL"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerLosesSAL");
        }
        else
        {
            return 0;
        }

    }






    //Set Wins

    public static void setVsComputerWins(string userUid)
    {
        int wins = getVsComputerWins(userUid);
        if (wins != 0)
        {
            wins++;
        }
        else{
            wins = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsComputerWins0", wins);
    }


    public static void setVsComputerLoses(string userUid)
    {
        int loses = getVsComputerLoses(userUid);
        if (loses != 0)
        {
            loses++;
        }
        else
        {
            loses = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsComputerLoses", loses);
    }

    public static void setVsMultiplayerWins(string userUid)
    {
        int wins = getVsMultiplayerWins(userUid);
        if (wins != 0)
        {
            wins++;
        }
        else
        {
            wins = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsMultiplayerWins0", wins);
    }

    public static void setVsMultiplayerLoses(string userUid)
    {
        int loses = getVsMultiplayerLoses(userUid);
        if (loses != 0)
        {
            loses++;
        }
        else
        {
            loses = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsMultiplayerLoses0", loses);
    }






    //Set Wins

    public static void setVsComputerWinsSAL(string userUid)
    {
        int wins = getVsComputerWinsSAL(userUid);
        if (wins != 0)
        {
            wins++;
        }
        else
        {
            wins = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsComputerWinsSAL", wins);
    }


    public static void setVsComputerLosesSAL(string userUid)
    {
        int loses = getVsComputerLosesSAL(userUid);
        if (loses != 0)
        {
            loses++;
        }
        else
        {
            loses = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsComputerLosesSAL", loses);
    }

    public static void setVsMultiplayerWinsSAL(string userUid)
    {
        int wins = getVsMultiplayerWinsSAL(userUid);
        if (wins != 0)
        {
            wins++;
        }
        else
        {
            wins = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsMultiplayerWinsSAL", wins);
    }

    public static void setVsMultiplayerLosesSAL(string userUid)
    {
        int loses = getVsMultiplayerLosesSAL(userUid);
        if (loses != 0)
        {
            loses++;
        }
        else
        {
            loses = 1;
        }
        PlayerPrefs.SetInt(userUid + "vsMultiplayerLosesSAL", loses);
    }






    public static void setPlayerDataInGameSpark(string _name, string country_name, string displayImage_path)
    {
        new LogEventRequest().SetEventKey("PLAYER_DATA").SetEventAttribute("PN", _name).SetEventAttribute("CN", country_name).SetEventAttribute("PIC", displayImage_path).SetDurable(true).
                             Send((response) =>
                             {
                                 if (!response.HasErrors)
                                 {
                                     Debug.Log("Player Saved To GameSparks...");
                                 }
                                 else
                                 {
                                     Debug.Log("Error Saving Player Data...");
                                 }
                             });
    }


    public static void setPlayerDisplayImageinGameSpark(string display_image)
    {
        new LogEventRequest().SetEventKey("PLAYER_DATA").SetEventAttribute("PIC", display_image).SetDurable(true).Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Pic Saved To GameSparks...");
            }
            else
            {
                Debug.Log("Error Saving Pic Data...");
            }
        });
    }

    public static Sprite LoadCountryImage(string countryName)
    {
        return Resources.Load<Sprite>("Sprites/Flags/" + countryName);
    }

    public static void LoadPlayerDataFromGameSpark()
    {
        new LogEventRequest().SetEventKey("LOAD_PLAYER_DATA").SetDurable(true).Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Received Player Data From GameSparks...");
                GSData data = response.ScriptData.GetGSData("player_Data");

                DisplayName = data.GetString("playerName");
                CountryName = data.GetString("countryName");
                DisplayImage = data.GetString("displayImage");
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });
    }


    public static string GetPlayerDisplayName(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "playerName"))
        {
            return PlayerPrefs.GetString(userUid + "playerName");
        }
        else
        {
            return "Guest Player";
        }
    }

    public static string GetPlayerCountryName(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "countryName"))
        {
            return PlayerPrefs.GetString(userUid + "countryName");
        }
        else
        {
            return null;
        }
    }

    public static int GetPlayerCoins(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "coins"))
        {
            return PlayerPrefs.GetInt(userUid + "coins");
        }
        else
        {
            return 5000;
        }
    }

    public static Sprite GetPlayerDisplayImage(Texture2D texture)
    {
        if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
        {
            string path = PlayerPrefs.GetString(Register.userId + "displayImage");
            texture = NativeGallery.LoadImageAtPath(path, 1000);
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            return Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        }
        else
        {
            return null;
        }
    }

    public static string GetPlayerDisplayImagePath(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "displayImage"))
        {
            return PlayerPrefs.GetString(userUid + "displayImage");
        }
        else
        {
            return null;
        }
    }


    public static void SetPlayerDisplayImagePath(string userUid, string path)
    {
        PlayerPrefs.SetString(userUid + "displayImage", path);
    }

    public static void SetPlayerCoins(string userUid, int coins)
    {

        PlayerPrefs.SetInt(userUid + "coins", coins);
    }


    public static void UploadDisplayImageInGameSpark(byte[] bytes)
    {
        GameObject startMenuManager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
        startMenuManager.GetComponent<UploadAndRetieveProfilePic>().UploadDisplayImage(bytes);
    }


    public static void SetDsiplayImageUploadId(string userUid, string uploadId)
    {
        PlayerPrefs.SetString(userUid + "uploadId", uploadId);
    }

    public static string GetDisplayImageUplaodId(String userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "uploadId"))
        {
            return PlayerPrefs.GetString(userUid + "uploadId");
        }
        else
        {
            return "0";
        }
    }


    public static string GetDate(String userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "savedDate"))
        {
            return PlayerPrefs.GetString(userUid + "savedDate");
        }
        else
        {
            return "0";
        }
    }

    public static string GetAdDate(String userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "savedAdDate"))
        {
            return PlayerPrefs.GetString(userUid + "savedAdDate");
        }
        else
        {
            return "0";
        }
    }



    public static string GetSpinAdDate(String userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "savedSpinAdDate"))
        {
            return PlayerPrefs.GetString(userUid + "savedSpinAdDate");
        }
        else
        {
            return "0";
        }
    }


    public static void SetSpinAdDate(string userUid, string date)
    {
        PlayerPrefs.SetString(userUid + "savedSpinAdDate", date);
    }



    public static string GetDailyBonusDate(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "savedDailyBonusDate"))
        {
            return PlayerPrefs.GetString(userUid + "savedDailyBonusDate");
        }
        else
        {
            return "0";
        }
    }


    public static void SetDailyBonusDate(string userUid, string date)
    {
        PlayerPrefs.SetString(userUid + "savedDailyBonusDate", date);
    }


    public static int GetDailyBonusCoins(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "savedDailyBonusCoins"))
        {
            return PlayerPrefs.GetInt(userUid + "savedDailyBonusCoins");
        }
        else
        {
            return 0;
        }
    }

    public static void SetDailyBonusCoins(string userUid, int coins)
    {
        PlayerPrefs.SetInt(userUid + "savedDailyBonusCoins", coins);
    }


    public static void SetDate(string userUid, string date)
    {
        PlayerPrefs.SetString(userUid + "savedDate", date);
    }


    public static void SetAdDate(string userUid, string date)
    {
        PlayerPrefs.SetString(userUid + "savedAdDate", date);
    }


    public static void SetLoginStatus(string status)
    {
        PlayerPrefs.SetString("ludoChallengeLoginStatus", status);
    }

    public static string GetLoginStatus()
    {
        return PlayerPrefs.GetString("ludoChallengeLoginStatus");
    }

    public static void SetUserName(string userName)
    {
        PlayerPrefs.SetString("ludoChallengeUserName", userName);
    }

    public static string GetUserName()
    {
        return PlayerPrefs.GetString("ludoChallengeUserName");
    }

    public static void SetPassword(string password)
    {
        PlayerPrefs.SetString("ludoChallengePassword", password);
    }

    public static string GetPassword()
    {
        return PlayerPrefs.GetString("ludoChallengePassword");
    }

    public static void SetDisplayName(string displayName)
    {
        PlayerPrefs.SetString("ludoChallengeDisplayName", displayName);
    }

    public static string GetDisplayName()
    {
        return PlayerPrefs.GetString("ludoChallengeDisplayName");
    }

    public static void SetSoundStatus(string status)
    {
        PlayerPrefs.SetString("ludoChallengeSoundStatus", status);
    }

    public static string GetSoundStatus()
    {
        if (PlayerPrefs.HasKey("ludoChallengeSoundStatus"))
        {
            return PlayerPrefs.GetString("ludoChallengeSoundStatus");
        }
        else{
            return "0";
        }
    }

    public static void SetMusicStatus(string status)
    {
        PlayerPrefs.SetString("ludoChallengeMusicStatus", status);
    }

    public static string GetMusicStatus()
    {
        if (PlayerPrefs.HasKey("ludoChallengeMusicStatus"))
        {
            return PlayerPrefs.GetString("ludoChallengeMusicStatus");
        }
        else{
            return "0";
        }
    }


    public static void SetSystemHour(string userID, int hour)
    {
        PlayerPrefs.SetInt(userID + "systemHour", hour);
    }

    public static void SetSystemMinutes(string userID, int minutes)
    {
        PlayerPrefs.SetInt(userID + "systemMinutes", minutes);
    }

    public static void SetSystemSeconds(string userID, int seconds)
    {
        PlayerPrefs.SetInt(userID + "systemSeconds", seconds);
    }

    public static int GetSystemHour(string userID)
    {
        if (PlayerPrefs.HasKey(userID + "systemHour"))
        {
            return PlayerPrefs.GetInt(userID + "systemHour");
        }
        else
        {
            return -1;
        }
    }

    public static int GetSystemMinutes(string userID)
    {
        if (PlayerPrefs.HasKey(userID + "systemMinutes"))
        {
            return PlayerPrefs.GetInt(userID + "systemMinutes");
        }
        else
        {
            return -1;
        }
    }

    public static int GetSystemSeconds(string userID)
    {
        if (PlayerPrefs.HasKey(userID + "systemSeconds"))
        {
            return PlayerPrefs.GetInt(userID + "systemSeconds");
        }
        else
        {
            return -1;
        }
    }

}

