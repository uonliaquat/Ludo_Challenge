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

public class Database : MonoBehaviour {
    //private static GameObject startMenuManager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);

    public static string DisplayName, CountryName, DisplayImage;

    public static void setPlayerDataInLocalDatabase(string _name, string country_name, int coins, string userUid){
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

        if (PlayerPrefs.HasKey(userUid + "vsComputerWins"))
        {
            return PlayerPrefs.GetInt(userUid + "vsComputerWins");
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
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerWins"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerWins");
        }
        else
        {
            return 0;
        }
          

    }

    public static int getVsMultiplayerLoses(string userUid)
    {
        if (PlayerPrefs.HasKey(userUid + "vsMultiplayerLoses"))
        {
            return PlayerPrefs.GetInt(userUid + "vsMultiplayerLoses");
        }
        else
        {
            return 0;
        }

    }


    //Set Wins

    public static void setVsComputerWins(string userUid){
        int wins = getVsComputerWins(userUid);
        if (wins != 0)
        {
            wins++;
        }
        PlayerPrefs.SetInt(userUid + "vsComputerWins", wins);
    }


    public static void setVsComputerLoses(string userUid)
    {
        int loses = getVsComputerLoses(userUid);
        if (loses != 0)
        {
            loses++;
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
        PlayerPrefs.SetInt(userUid + "vsMultiplayerWins", wins);
    }

    public static void setVsMultiplayerLoses(string userUid)
    {
        int loses = getVsMultiplayerLoses(userUid);
        if (loses != 0)
        {
            loses++;
        }
        PlayerPrefs.SetInt(userUid + "vsMultiplayerLoses", loses);
    }


    public static void setPlayerDataInGameSpark(string _name, string country_name, string displayImage_path){
        new LogEventRequest().SetEventKey("PLAYER_DATA").SetEventAttribute("PN", _name).SetEventAttribute("CN", country_name) .SetEventAttribute("PIC", displayImage_path).SetDurable(true).
                             Send((response) => {
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


    public static void setPlayerDisplayImageinGameSpark(string display_image){
        new LogEventRequest().SetEventKey("PLAYER_DATA").SetEventAttribute("PIC", display_image).SetDurable(true).Send((response) => {
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

    public static Sprite LoadCountryImage(string countryName){
        return Resources.Load<Sprite>("Sprites/Flags/" + countryName);
    }

    public static void LoadPlayerDataFromGameSpark(){
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

    public static Sprite GetPlayerDisplayImage(Texture2D texture){
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
        else{
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


    public static void UploadDisplayImageInGameSpark(byte[] bytes){
        GameObject startMenuManager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
        startMenuManager.GetComponent<UploadAndRetieveProfilePic>().UploadDisplayImage(bytes);
    }


    public static void SetDsiplayImageUploadId(string userUid, string uploadId){
        PlayerPrefs.SetString(userUid + "uploadId", uploadId);
    }

    public static string GetDisplayImageUplaodId(String userUid){
        if(PlayerPrefs.HasKey(userUid + "uploadId")){
            return PlayerPrefs.GetString(userUid + "uploadId");
        }
        else{
            return "0";
        }
    }




}
