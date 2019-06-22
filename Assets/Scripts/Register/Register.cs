using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Core;
using Facebook.Unity;

public class Register : MonoBehaviour
{

    private Button register_btn, login_btn, playAsGuest_btn, playAsGuestCanvasBack_btn, playAsGuestContinueBtn;
    private Text NAME, USERNAME, PASSWORD, EMAIL;
    public static Text countryName;
    public static string userId;
    public static string Game;
    public static bool isSoundPlaying;
    public AudioClip music;
    public AudioSource buttonAudioSource;
    public AudioClip buttonSound;
    private bool musicChecked;
    private Canvas exit_canvs;
    private Button exitCanvasYes_btn, exitCanvasNo_btn;
    private bool isExitCanvasEnabled;
    private Canvas checkLoginStatus_canvas, playAsGuest_canvas, defaultImages_canvas;
    private GameObject guestImage_btn, passwordEye, passwordObject;
    private GameObject defaultPic01, defaultPic02, defaultPic03, defaultPic04, defaultPic05, defaultPic06, defaultPic07, defaultPic08, defaultPic09, defaultPic10,
    defaultPic11, defaultPic12;
    public static Image guestImage;
    private Text guestName;
    public static string GuestName;
    public Sprite[] passwordEye_sprites;
    private int passwordEye_spriteCheck;
    public static bool RegisterScreen;
    private static AudioSource _instance;
    private GameObject music_manager;
    private Button exit_btn;
    private CanvasGroup main_canvas;
    private Button defaultPicturesBack_btn;


    private void Awake()
    {
        //DontDestroyOnLoad(this);
        defaultPicturesBack_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_DEFAULT_PICTUERS_BACK_BUTTON).GetComponent<Button>();
        music_manager = GameObject.FindGameObjectWithTag(GameConstants.MUSIC_MANAGER);
        defaultPic01 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC01);
        defaultPic02 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC02);
        defaultPic03 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC03);
        defaultPic04 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC04);
        defaultPic05 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC05);
        defaultPic06 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC06);
        defaultPic07 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC07);
        defaultPic08 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC08);
        defaultPic09 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC09);
        defaultPic10 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC10);
        defaultPic11 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC11);
        defaultPic12 = GameObject.FindGameObjectWithTag(GameConstants.DEFAULT_PIC12);
        passwordEye = GameObject.FindGameObjectWithTag(GameConstants.PASSWORD_EYE);
        main_canvas = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_MAIN_CANVAS).GetComponent<CanvasGroup>();
        exit_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_EXIT_BUTTON).GetComponent<Button>();
        passwordObject = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_PASSWORD_OBJECT);
        playAsGuestContinueBtn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_PLAY_AS_GUEST_CONTINUE_BUTTON).GetComponent<Button>();
        guestName = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_GUEST_NAME_TEXT).GetComponent<Text>();
        defaultImages_canvas = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_DEFAULT_IMAGES).GetComponent<Canvas>();
        guestImage = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_PLAY_AS_GUEST_GUEST_IMAGE).GetComponent<Image>();
        guestImage_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_PLAY_AS_GUEST_GUEST_FRAME_IMAGE);
        playAsGuest_canvas = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_PLAY_AS_GUEST).GetComponent<Canvas>();
        playAsGuestCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_PLAY_AS_GUEST_BACK_BUTTON).GetComponent<Button>();
        checkLoginStatus_canvas = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_CANVAS_CHECK_LOGIN_STATUS).GetComponent<Canvas>();
        exit_canvs = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_EXIT_CANVAS).GetComponent<Canvas>();
        exitCanvasYes_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_EXIT_CANVAS_YES_BUTTON).GetComponent<Button>();
        exitCanvasNo_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_EXIT_CANVAS_NO_BUTTON).GetComponent<Button>();
        playAsGuest_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_PLAY_AS_GUEST_BUTTON).GetComponent<Button>();
        register_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_BUTTON).GetComponent<Button>();
        login_btn = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_LOGIN_BUTTON).GetComponent<Button>();
        NAME = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_NAME).GetComponent<Text>();
        USERNAME = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_USERNAME).GetComponent<Text>();
        PASSWORD = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_PASSWORD).GetComponent<Text>();
        EMAIL = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_EMAIL).GetComponent<Text>();
        countryName = GameObject.FindGameObjectWithTag(GameConstants.REGISTER_COUNTRY_NAME).GetComponent<Text>();

        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        isExitCanvasEnabled = false;
        isSoundPlaying = true;
        //isMusicPlaying = true;
        defaultPicturesBack_btn.onClick.AddListener(DefaultPicturesCanvasBackBtn);
        register_btn.onClick.AddListener(RegisterUser);
        login_btn.onClick.AddListener(AlreadyHaveAnAccount);
        playAsGuest_btn.onClick.AddListener(PlayAsGuestBtn);
        exitCanvasYes_btn.onClick.AddListener(ExitCanvasYesButton);
        exitCanvasNo_btn.onClick.AddListener(ExitCanvasNoButton);
        exit_btn.onClick.AddListener(RegisterExitBtn);
        playAsGuestCanvasBack_btn.onClick.AddListener(PlayAsGuestCanvasBackBtn);
        guestImage_btn.GetComponent<Button>().onClick.AddListener(GuestImageBtn);
        defaultPic01.GetComponent<Button>().onClick.AddListener(DefaultPic01);
        defaultPic02.GetComponent<Button>().onClick.AddListener(DefaultPic02);
        defaultPic03.GetComponent<Button>().onClick.AddListener(DefaultPic03);
        defaultPic04.GetComponent<Button>().onClick.AddListener(DefaultPic04);
        defaultPic05.GetComponent<Button>().onClick.AddListener(DefaultPic05);
        defaultPic06.GetComponent<Button>().onClick.AddListener(DefaultPic06);
        defaultPic07.GetComponent<Button>().onClick.AddListener(DefaultPic07);
        defaultPic08.GetComponent<Button>().onClick.AddListener(DefaultPic08);
        defaultPic09.GetComponent<Button>().onClick.AddListener(DefaultPic09);
        defaultPic10.GetComponent<Button>().onClick.AddListener(DefaultPic10);
        defaultPic11.GetComponent<Button>().onClick.AddListener(DefaultPic11);
        defaultPic12.GetComponent<Button>().onClick.AddListener(DefaultPic12);
        playAsGuestContinueBtn.onClick.AddListener(PlayAsGuestContinueBtn);
        passwordEye.GetComponent<Button>().onClick.AddListener(PasswordEye);
        Game = GameConstants.LUDO_CHALLENGE;
        //audioSource.clip = music;
        //if (Database.GetMusicStatus() == "0" || Database.GetMusicStatus() == GameConstants.MUSIC_PLAYING_TRUE)
        //{
        //    audioSource.Play();
        //    isMusicPlaying = true;
        //    Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_TRUE);
        //}
        //else
        //{
        //    isMusicPlaying = false;
        //    Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_FALSE);
        //}
        if (Database.GetSoundStatus() == "0" || Database.GetSoundStatus() == GameConstants.SOUND_PLAYING_TRUE)
        {
            isSoundPlaying = true;
            Database.SetSoundStatus(GameConstants.SOUND_PLAYING_TRUE);
        }
        else{
            isSoundPlaying = false;
            Database.SetSoundStatus(GameConstants.SOUND_PLAYING_FALSE);
        }
        buttonAudioSource.clip = buttonSound;
        musicChecked = false;
        //playAsGuest_btn.interactable = false;
        //register_btn.interactable = false;
        //login_btn.interactable = false;
        //exit_btn.interactable = false;
        //LoginWithFB.loginWithFB_btn.interactable = false;
        GuestName = "Guest";
        passwordEye_spriteCheck = 0;
        //CheckIfUserisAlreadyLoggedIn();
        RegisterScreen = false;


    }



    private void RegisterExitBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        main_canvas.interactable = false;
        exit_canvs.enabled = true;
    }

    private void PlayAsGuestContinueBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        if (guestName.text != "")
        {
            GuestName = guestName.text;
        }
        
        //change scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
        RegisterScreen = true;
    }

    private void PasswordEye()
    {
        if (passwordEye_spriteCheck == 0)
        {
            passwordEye_spriteCheck = 1;
            passwordEye.GetComponent<Image>().sprite = passwordEye_sprites[1];
            passwordObject.GetComponent<InputField>().contentType = InputField.ContentType.Standard;
            passwordObject.GetComponent<InputField>().enabled = false;
            passwordObject.GetComponent<InputField>().enabled = true;
        }
        else if(passwordEye_spriteCheck == 1)
        {
            passwordEye_spriteCheck = 0;
            passwordEye.GetComponent<Image>().sprite = passwordEye_sprites[0];
            passwordObject.GetComponent<InputField>().contentType = InputField.ContentType.Password;
            passwordObject.GetComponent<InputField>().enabled = false;
            passwordObject.GetComponent<InputField>().enabled = true;
        }
    }

    private void DefaultPic01()
    {
        guestImage.sprite = defaultPic01.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic02()
    {
        guestImage.sprite = defaultPic02.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic03()
    {
        guestImage.sprite = defaultPic03.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic04()
    {
        guestImage.sprite = defaultPic04.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic05()
    {
        guestImage.sprite = defaultPic05.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic06()
    {
        guestImage.sprite = defaultPic06.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic07()
    {
        guestImage.sprite = defaultPic07.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic08()
    {
        guestImage.sprite = defaultPic08.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic09()
    {
        guestImage.sprite = defaultPic09.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic10()
    {
        guestImage.sprite = defaultPic10.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic11()
    {
        guestImage.sprite = defaultPic11.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }
    private void DefaultPic12()
    {
        guestImage.sprite = defaultPic12.GetComponent<Image>().sprite;
        defaultImages_canvas.enabled = false;
        playAsGuest_canvas.enabled = true;
    }



    private void GuestImageBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }

        playAsGuest_canvas.enabled = false;
        defaultImages_canvas.enabled = true;
    }

    private void PlayAsGuestCanvasBackBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        main_canvas.interactable = true;
        playAsGuest_canvas.enabled = false;
    }

    private void DefaultPicturesCanvasBackBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        playAsGuest_canvas.enabled = true;
        defaultImages_canvas.enabled = false;
    }

    private void ExitCanvasYesButton()
    {
        Application.Quit();
    }

    private void ExitCanvasNoButton()
    {
        if(isSoundPlaying){
            buttonAudioSource.Play();
        }
        main_canvas.interactable = true;
        exit_canvs.enabled = false;
        isExitCanvasEnabled = false;
    }

    //private void CheckIfUserisAlreadyLoggedIn()
    //{
    //    if (Application.internetReachability != NetworkReachability.NotReachable)
    //    {
    //        //internet reachable
    //        if (Database.GetLoginStatus() == GameConstants.LOGGED_IN_WITH_GAMESPARK)
    //        {
    //            checkLoginStatus_canvas.enabled = true;
    //            new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(Database.GetUserName()).SetPassword(Database.GetPassword()).Send((response) =>
    //            {
    //                Register.userId = response.UserId;
    //                if (!response.HasErrors)
    //                {
    //                    Debug.Log("Player Authenticated...");
    //                    Database.LoadPlayerDataFromGameSpark();

    //                    //change scene
    //                    checkLoginStatus_canvas.enabled = false;
    //                    SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    //                    ShowToast.MyShowToastMethod("Player Logged In!");
    //                }
    //                else
    //                {
    //                    checkLoginStatus_canvas.enabled = false;
    //                    Debug.Log("Error Authenticating Player...");
    //                    ShowToast.MyShowToastMethod("Error in Authentication!");
    //                    checkLoginStatus_canvas.enabled = false;
    //                    playAsGuest_btn.interactable = true;
    //                    register_btn.interactable = true;
    //                    login_btn.interactable = true;
    //                    exit_btn.interactable = true;
    //                    LoginWithFB.loginWithFB_btn.interactable = true;
    //                }
    //            });
    //        }
    //        else if (Database.GetLoginStatus() == GameConstants.LOGGED_IN_WITH_FB)
    //        {
    //            checkLoginStatus_canvas.enabled = true;
    //            if (!FB.IsInitialized)
    //            {
    //                Debug.Log("Initializing Facebook...");
    //                FB.Init(ConnectGameSparksToGameSparks, null);
    //            }
    //            else
    //            {
    //                FB.ActivateApp();
    //                ConnectGameSparksToGameSparks();
    //            }
    //        }
    //        else
    //        {
    //            checkLoginStatus_canvas.enabled = false;
    //            playAsGuest_btn.interactable = true;
    //            register_btn.interactable = true;
    //            login_btn.interactable = true;
    //            exit_btn.interactable = true;
    //            LoginWithFB.loginWithFB_btn.interactable = true;
    //        }
    //    }
    //    else
    //    {
    //        // internet not reachable
    //        Debug.Log("Internet Not Reachable");
    //        ShowToast.MyShowToastMethod("Internet Not Reachable!");
    //        checkLoginStatus_canvas.enabled = false;
    //        playAsGuest_btn.interactable = true;
    //        register_btn.interactable = true;
    //        login_btn.interactable = true;
    //        exit_btn.interactable = true;
    //        LoginWithFB.loginWithFB_btn.interactable = true;
    //    }

    //}

    private void PlayAsGuestBtn()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        main_canvas.interactable = false;
        playAsGuest_canvas.enabled = true;
        StartMenu.playAsGuest = true;
    }

    private void RegisterUser()
    {
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        StartMenu.playAsGuest = false;
        string _name = NAME.text;
        string _email = EMAIL.text;
        string _username = USERNAME.text;
        string _password = PASSWORD.text;
        string _countryName = countryName.text;
        if (_name == "")
        {
            ShowToast.MyShowToastMethod("Enter you Name!");
            return;
        }
        if (_email == "")
        {
            ShowToast.MyShowToastMethod("Enter you Email!");
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
        register_btn.interactable = false;
        GSRequestData gSRequestData = new GSRequestData();
        gSRequestData.Add("email", _email);
        new RegistrationRequest().SetDisplayName(_name).SetUserName(_username).SetPassword(_password).SetScriptData(gSRequestData).Send((response) =>
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
                register_btn.interactable = true;
                Database.SetLoginStatus(GameConstants.LOGGED_IN_WITH_GAMESPARK);
                Database.SetUserName(_username);
                Database.SetPassword(_password);
                Database.SetDisplayName(_name);
            }
            else if (response.Errors.GetString("ERROR") == "Email in use!")
            {
                ShowToast.MyShowToastMethod("Email already in use!");
                Debug.Log("Email already in use!");
                register_btn.interactable = true;
            }
            else
            {
                Debug.Log("Error Registering Player");
                ShowToast.MyShowToastMethod("Error Registering Player!");
                register_btn.interactable = true;
                Debug.Log(response.Errors.GetString("ERROR"));

            }
          

        });
    }



    //private void ConnectGameSparksToGameSparks()
    //{
    //    if (FB.IsInitialized)
    //    {
    //        FB.ActivateApp();
    //        Debug.Log("Logging Into Facebook...");
    //        var perms = new List<string>() { "public_profile", "email", "user_friends" };
    //        FB.LogInWithReadPermissions(perms, (result) =>
    //        {
    //            if (FB.IsLoggedIn)
    //            {
    //                Debug.Log("Logged In, Connecting GS via FB..");
    //                new GameSparks.Api.Requests.FacebookConnectRequest()
    //                 .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
    //                              .SetSyncDisplayName(true)
    //                              .SetDoNotLinkToCurrentPlayer(true)// we don't want to create a new account so link to the player that is currently logged in
    //                              .SetSwitchIfPossible(true)//this will switch to the player with this FB account id they already have an account from a separate login
    //                 .Send((fbauth_response) =>
    //                 {
    //                     if (!fbauth_response.HasErrors)
    //                     {
    //                         new AccountDetailsRequest().Send((response) =>
    //                         {
    //                             LoginWithFB.fb_id = response.ExternalIds.GetString("FB");
    //                             LoginWithFB.id = response.UserId;
    //                             Debug.Log("Ludo Challenge Authenticated With Facebook!");
    //                             ShowToast.MyShowToastMethod("Ludo Challenge Authenticated With FB!");
    //                             LoginWithFB.FacebookLoggedIn = true;
    //                             LoginWithFB.displayName_FB = fbauth_response.DisplayName;
    //                             LoginWithFB.countryName = Register.countryName.text;
    //                             LoginWithFB.url = "http://graph.facebook.com/" + LoginWithFB.fb_id + "/picture?width=100&height=100";
    //                             StartCoroutine(DownloadFBImage(LoginWithFB.url));
    //                             Database.SetLoginStatus(GameConstants.LOGGED_IN_WITH_FB);
    //                             userId = LoginWithFB.id;

    //                         });
    //                     }
    //                     else
    //                     {
    //                         Debug.LogWarning(fbauth_response.Errors.JSON);//if we have errors, print them out
    //                     }
    //                 });
    //            }
    //            else
    //            {
    //                exit_btn.interactable = true;
    //                checkLoginStatus_canvas.enabled = false;
    //                Debug.LogWarning("Facebook Login Failed:" + result.Error);
    //                ShowToast.MyShowToastMethod("Facebook Login Failed!");
    //                LoginWithFB.FacebookLoggedIn = false;
    //                checkLoginStatus_canvas.enabled = false;
    //                playAsGuest_btn.interactable = true;
    //                register_btn.interactable = true;
    //                login_btn.interactable = true;
    //                LoginWithFB.loginWithFB_btn.interactable = true;
    //            }
    //        });// lastly call another method to login, and when logged in we have a callback
    //    }
    //    else
    //    {
    //        if (!FB.IsInitialized)
    //        {
    //            Debug.Log("Initializing Facebook...");
    //            FB.Init(ConnectGameSparksToGameSparks, null);
    //        }
    //        else
    //        {
    //            FB.ActivateApp();
    //            ConnectGameSparksToGameSparks();
    //        }
    //    }
    //}

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


    private void AlreadyHaveAnAccount(){
        if (isSoundPlaying)
        {
            buttonAudioSource.Play();
        }
        //Change Scene
        checkLoginStatus_canvas.enabled = false;
        SceneManager.LoadScene(GameConstants.LOGIN_SCENE);
    }

    public void OnBackPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isExitCanvasEnabled){
                main_canvas.interactable = false;
                exit_canvs.enabled = true;
                isExitCanvasEnabled = true;
            }
        }
    }

}
