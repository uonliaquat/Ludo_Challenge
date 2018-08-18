using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;

public class Register : MonoBehaviour
{
    
    private Button register_btn, login_btn;
    private Text NAME, USERNAME, PASSWORD;
    public static Text countryName;
    public static string userId;

    private void Awake()
    {

        register_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_BUTTON).GetComponent<Button>();
        login_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_LOGIN_BUTTON).GetComponent<Button>();
        NAME = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_NAME).GetComponent<Text>();
        USERNAME = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_USERNAME).GetComponent<Text>();
        PASSWORD = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_PASSWORD).GetComponent<Text>();
        countryName = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_COUNTRY_NAME).GetComponent<Text>();

        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Start()
    {
        register_btn.onClick.AddListener(RegisterUser);
        login_btn.onClick.AddListener(AlreadyHaveAnAccount);
    }

    private void Update()
    {

    }
    private void RegisterUser()
    {
        string _name = NAME.text;
        string _username = USERNAME.text;
        string _password = PASSWORD.text;
        string _countryName = countryName.text;
        if (_name == "")
        {
            ShowToast.MyShowToastMethod("Enter you Name!");
            return;
        }
        if (_username == "")
        {
            ShowToast.MyShowToastMethod("Enter you Username!");
            return;
        }
        if (_password == "")
        {
            ShowToast.MyShowToastMethod("Enter you Password!");
            return;
        }

        Debug.Log("Registering User...");
        new RegistrationRequest().SetDisplayName(_name).SetUserName(_username).SetPassword(_password).Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Player Registered");

                ShowToast.MyShowToastMethod("Player registered successfully!");

                userId = response.UserId;
                Database.setPlayerDataInGameSpark(_name, _countryName, "null");
                Database.setPlayerDataInLocalDatabase(_name, _countryName, 5000, userId);
                Database.setAllWinsAndLosesToZero(userId);
                //change scene
                SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
            }
            else
            {
                Debug.Log("Error Registering Player");
                ShowToast.MyShowToastMethod("Error Registering Player!");
            }
          

        });
    }

    private void AlreadyHaveAnAccount(){
        //Change Scene
        SceneManager.LoadScene(GameConstants.LOGIN_SCENE);
    }

}
