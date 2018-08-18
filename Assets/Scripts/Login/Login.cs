using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    private Button login_btn, createOne_btn;
    private Text  USERNAME, PASSWORD;

    private void Awake()
    {

        login_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_BUTTON).GetComponent<Button>();
        createOne_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_CREATEONE_BUTTON).GetComponent<Button>();
        USERNAME = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_USERNAME).GetComponent<Text>();
        PASSWORD = GameObject.FindGameObjectWithTag(GameConstants.LOGIN_PASSWORD).GetComponent<Text>();
    }

    private void Start()
    {
        login_btn.onClick.AddListener(LoginUser);
        createOne_btn.onClick.AddListener(CreateOneBtn);
    }

    private void CreateOneBtn()
    {
        //Change Scene
        SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
    }
    private void LoginUser()
    {
        string _username = USERNAME.text;
        string _password = PASSWORD.text;

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

        Debug.Log("Authorizing Player.....");
        new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(_username).SetPassword(_password).Send((response) =>
        {
            Register.userId = response.UserId;
            if (!response.HasErrors)
            {
                Debug.Log("Player Authenticated...");
                Database.LoadPlayerDataFromGameSpark();

                //change scene
                SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
                ShowToast.MyShowToastMethod("Player Logged In!");
            }
            else
            {
                Debug.Log("Error Authenticating Player...");
                ShowToast.MyShowToastMethod("Error in Authentication!");
            }
        });
    }
}
