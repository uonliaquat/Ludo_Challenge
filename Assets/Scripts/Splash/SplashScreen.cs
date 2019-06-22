using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Core;
using Facebook.Unity;

public class SplashScreen : MonoBehaviour {
    private void Start()
    {
        CheckIfUserisAlreadyLoggedIn();
    }

    private IEnumerator ChangeScene(string Scene){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }

    private void CheckIfUserisAlreadyLoggedIn()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            //internet reachable
            if (Database.GetLoginStatus() == GameConstants.LOGGED_IN_WITH_GAMESPARK)
            {
                new AuthenticationRequest().SetUserName(Database.GetUserName()).SetPassword(Database.GetPassword()).Send((response) =>
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
                        Debug.Log("Error Logging in Player!");
                        ShowToast.MyShowToastMethod("Error Logging in Player!");
                        SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
                    }
                });
            }
            else if (Database.GetLoginStatus() == GameConstants.LOGGED_IN_WITH_FB)
            {
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
            else
            {
                StartCoroutine(ChangeScene(GameConstants.REGISTER_SCENE));
            }
        }
        else
        {
            // internet not reachable
            Debug.Log("Internet Not Reachable");
            ShowToast.MyShowToastMethod("Internet Not Reachable!");
            StartCoroutine(ChangeScene(GameConstants.REGISTER_SCENE));
        }

    }

    private void ConnectGameSparksToGameSparks()
    {
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
                                 LoginWithFB.fb_id = response.ExternalIds.GetString("FB");
                                 LoginWithFB.id = response.UserId;
                                 Debug.Log("Ludo Challenge Authenticated With Facebook!");
                                 ShowToast.MyShowToastMethod("Ludo Challenge Authenticated With FB!");
                                 LoginWithFB.FacebookLoggedIn = true;
                                 LoginWithFB.displayName_FB = fbauth_response.DisplayName;
                                 LoginWithFB.countryName = Register.countryName.text;
                                 LoginWithFB.url = "http://graph.facebook.com/" + LoginWithFB.fb_id + "/picture?width=100&height=100";
                                 StartCoroutine(DownloadFBImage(LoginWithFB.url));
                                 Database.SetLoginStatus(GameConstants.LOGGED_IN_WITH_FB);
                                 Register.userId = LoginWithFB.id;

                             });
                         }
                         else
                         {
                             Debug.LogWarning(fbauth_response.Errors.JSON);//if we have errors, print them out
                         }
                     });
                }
                else
                {
                    Debug.LogWarning("Facebook Login Failed:" + result.Error);
                    ShowToast.MyShowToastMethod("Facebook Login Failed!");
                    LoginWithFB.FacebookLoggedIn = false;
                    SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
                }
            });// lastly call another method to login, and when logged in we have a callback
        }
        else
        {
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
    }

    public IEnumerator DownloadFBImage(string downloadUrl)
    {
        Debug.Log("FB Image Downloding Started");
        Debug.Log(downloadUrl);
        var www = new WWW(downloadUrl);
        yield return www;
        LoginWithFB.FB_Image = new Texture2D(100, 100, TextureFormat.Alpha8, false);
        www.LoadImageIntoTexture(LoginWithFB.FB_Image);
        Debug.Log("FB Image Downloded");

        //Change Scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    }
}
