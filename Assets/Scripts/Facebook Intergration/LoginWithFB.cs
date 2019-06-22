using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Core;


public class LoginWithFB : MonoBehaviour
{

    public static Button loginWithFB_btn;
    public static string displayName_FB;
    public static string countryName;
    public static bool FacebookLoggedIn;
    public static string fb_id, id;
    public static string url;

    public static Texture2D FB_Image;

    private void Awake()
    {
        loginWithFB_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_LOGIN_WITH_FB_BUTTON).GetComponent<Button>();
    }

    private void Start()
    {
        loginWithFB_btn.onClick.AddListener(LoginWithFBBtn);
        FacebookLoggedIn = false;
    }

    private void LoginWithFBBtn()
    {
        Debug.Log("Connecting Facebook With GameSparks...");// first check if FB is ready, and then login //
                                                            // if it's not ready we just init FB and use the login method as the callback for the init method //
        if (!FB.IsInitialized)
        {
            Debug.Log("Initializing Facebook...");
            FB.Init(ConnectGameSparksToGameSparks, null);
        }
        else
        {
            FB.ActivateApp();
            ConnectGameSparksToGameSparks();
        }
    }


    private void ConnectGameSparksToGameSparks()
    {
        loginWithFB_btn.interactable = false;
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("Logging Into Facebook...");
            var perms = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(perms, (result) =>
            {
                if (FB.IsLoggedIn)
                {
                    Debug.Log("Logged In, Connecting GS via FB..");
                    new GameSparks.Api.Requests.FacebookConnectRequest()
                     .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
                                  .SetSyncDisplayName(true)
                                  .SetDoNotLinkToCurrentPlayer(true)// we don't want to create a new account so link to the player that is currently logged in
                                  .SetSwitchIfPossible(true)//this will switch to the player with this FB account id they already have an account from a separate login
                     .Send((fbauth_response) =>
                    {
                        if (!fbauth_response.HasErrors)
                        {
                            new AccountDetailsRequest().Send((response) =>
                            {
                                fb_id = response.ExternalIds.GetString("FB");
                                id = response.UserId;
                                Debug.Log("Ludo Challenge Authenticated With Facebook!");
                                ShowToast.MyShowToastMethod("Ludo Challenge Authenticated With FB!");
                                FacebookLoggedIn = true;
                                displayName_FB = fbauth_response.DisplayName;
                                countryName = Register.countryName.text;
                                url = "http://graph.facebook.com/" + LoginWithFB.fb_id + "/picture?width=100&height=100";
                                StartCoroutine(DownloadFBImage(url));
                                Database.SetLoginStatus(GameConstants.LOGGED_IN_WITH_FB);

                                StartMenu.playAsGuest = false;

                            });
                        }
                        else
                        {
                            Debug.LogWarning(fbauth_response.Errors.JSON);//if we have errors, print them out
                            loginWithFB_btn.interactable = true;
                        }
                    });
                }
                else
                {
                    Debug.LogWarning("Facebook Login Failed:" + result.Error);
                    ShowToast.MyShowToastMethod("Facebook Login Failed!");
                    FacebookLoggedIn = false;
                    loginWithFB_btn.interactable = true;
                }
            });// lastly call another method to login, and when logged in we have a callback
        }
        else
        {
            LoginWithFBBtn();// if we are still not connected, then try to process again
        }
    }

    public IEnumerator DownloadFBImage(string downloadUrl)
    {
        Debug.Log("FB Image Downloding Started");
        Debug.Log(downloadUrl);
        var www = new WWW(downloadUrl);
        yield return www;
        FB_Image = new Texture2D(100, 100, TextureFormat.Alpha8, false);
        www.LoadImageIntoTexture(FB_Image);
        Debug.Log("FB Image Downloded");
        loginWithFB_btn.interactable = true;

        Register.userId = id;
        //Change Scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    }
}
