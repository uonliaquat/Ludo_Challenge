using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Api.Messages;
using UnityEngine.Advertisements;

using GameSparks.Core;

public class StartMenu : MonoBehaviour
{

    string subject = "Get Ludo Challenge Now for free! and play with you friends";
    string body = "Actual text (Link)";

#if UNITY_IPHONE

    [DllImport("__Internal")]
    private static extern void sampleMethod (string iosPath, string message);

    [DllImport("__Internal")]
    private static extern void sampleTextMethod (string message);

#endif

    private Button play_btn, settings_btn, exit_btn;
    private Button settingsCanvasBack_btn, settingsCanvasEditProfile_btn, editProfileCanvasBack_btn, editProfileCanvasContinue_btn, profileBox_btn, statsCanvasBack_btn,
    editProfileCanvasUserImage_btn, exitCanvasYes_btn, exitCanvasNo_btn, share_btn, like_btn, rate_btn, settingsCanvasLike_btn, sound_btn, music_btn, regsiterYourAccount_btn,
    logOutLogIn_btn, gameRules_btn, moreGames_btn, gameRulesBack_btn, spinCanvasSpin_btn, spin_btn, spinWinDialog_btn, ludoToSal_btn, salToLudo_btn;
    public Canvas settings_canvas, editProfile_canvas, stats_canvas, exit_canvas, gameRules_canvas, spin_canvas, spinWinDialog_canvas;
    public static Canvas main_canvas;
    private Text editProfileCanvas_displayName;
    public Image editProfileCanvas_userImage, coinImage, statsCoinImage;
    public static Texture2D texture;
    public static string displayImage_string;
    private Image countryImage, statsCanvas_displayImage, statsCanvas_countryImage, spinWintext_image;
    public static Image displayImage;
    private Text DisplayName, CountryName, NoOfCoins, statsCanvas_displayName, statsCanvas_countryName, statsCanvas_NoOfCoins, guestText;
    private Text vsComputerWins, vsComputerLoses, vsMultiplayerWins, vsMultiplayerLoses, vsComputerWinsSAL, vsComputerLosesSAL, vsMultiplayerWinsSAL, vsMultiplayerLosesSAL;
    public static bool playAsGuest;
    public Sprite[] music_sprites, sound_sprites;
    private GameObject spin_wheel;
    public static Canvas challenge_canvas;
    public static Text challenge_msg, acceptChallange_text;
    public static Button challengeYes_btn, challangeNo_btn;
    private Canvas dailyBonus_canvas;
    private Text dailyBonusCoins_text;
    private Button dailyBonusOk_btn;

    //public Sprite[] spin_sprites;
    public AudioSource audioSource;
    public int backPressCount;
    public static string challenger_id;

    public AudioSource notificationSource;


    public static bool startGame;
    private GameObject game_manager;
    private Button ad_btn, spinWinDialogOk_btn;
    private Text spinWinDialogCoins_text;
    public AudioSource dialogSource;
    private Button getSpinByWatchingAd_btn, spinCanvasBack_btn;
    private bool getOneMoreSpin;

    private Canvas watchAdBonus_canvas;
    private Text watchAdBonusCoins_text;
    private Button watchAdBonusOk_btn;
    private int ADCoins;
    private int dailyBonusCoins;
    private Text spinTimeRemaining;
    private string spin_time_remaining;
    private int hours, minutes, seconds;
    private bool startTimer;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag(GameConstants.SAL_TO_LUDO_BUTTON) != null)
        {
            salToLudo_btn = GameObject.FindGameObjectWithTag(GameConstants.SAL_TO_LUDO_BUTTON).GetComponent<Button>();
        }
        if (GameObject.FindGameObjectWithTag(GameConstants.LUDO_TO_SAL_BUTTON) != null)
        {
            ludoToSal_btn = GameObject.FindGameObjectWithTag(GameConstants.LUDO_TO_SAL_BUTTON).GetComponent<Button>();
        }

        if (GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS_OK_BUTTON) != null)
        {
            dailyBonusOk_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS_OK_BUTTON).GetComponent<Button>();
        }
        if (GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS_COINS_TEXT) != null)
        {
            dailyBonusCoins_text = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS_COINS_TEXT).GetComponent<Text>();
        }
        if (GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS) != null)
        {
            dailyBonus_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS).GetComponent<Canvas>();
        }

        spinTimeRemaining = GameObject.FindGameObjectWithTag(GameConstants.GET_SPIN_BY_WATCHING_AD_REMAINING_TIME_TEXT).GetComponent<Text>();
        watchAdBonusOk_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_AD_BONUS_OK_BUTTON).GetComponent<Button>();
        watchAdBonus_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_AD_BONUS).GetComponent<Canvas>();
        watchAdBonusCoins_text = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_AD_BONUS_COINS_TEXT).GetComponent<Text>();
        spinCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SPIN_CANVAS_BACK_BUTTON).GetComponent<Button>();
        getSpinByWatchingAd_btn = GameObject.FindGameObjectWithTag(GameConstants.GET_SPIN_BY_WATCHING_AD_BUTTON).GetComponent<Button>();
        spinWinDialogCoins_text = GameObject.FindGameObjectWithTag(GameConstants.SPIN_WIN_DIALOG_NO_OF_COINS_TEXT).GetComponent<Text>();
        spinWinDialogOk_btn = GameObject.FindGameObjectWithTag(GameConstants.SPIN_WIN_DIALOG_OK_BUTTON).GetComponent<Button>();
        ad_btn = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_AD_BUTTON).GetComponent<Button>();
        game_manager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
       //acceptChallange_text = GameObject.Find("AcceptChallange").GetComponent<Text>();
        //spinWinDialog_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_SPIN_WIN_DIALOG_BUTTON).GetComponent<Button>();
        //spinWintext_image = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_SPIN_WIN_DIALOG_TEXT_IMAGE).GetComponent<Image>();
        spinWinDialog_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_SPIN_WIN_DIALOG).GetComponent<Canvas>();
        spin_btn = GameObject.FindGameObjectWithTag(GameConstants.SPIN_BUTTON).GetComponent<Button>();
        spinCanvasSpin_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_SPIN_SPIN_BUTTON).GetComponent<Button>();
        spin_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_SPIN).GetComponent<Canvas>();
        spin_wheel = GameObject.FindGameObjectWithTag(GameConstants.SPIN_ANIM);
        gameRules_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_GAME_RULES).GetComponent<Canvas>();
        gameRulesBack_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_GAME_RULES_BACK_BUTTON).GetComponent<Button>();
        guestText = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_GUEST_TEXT).GetComponent<Text>();
        statsCoinImage = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_STATS_COIN_IMAGE).GetComponent<Image>();
        coinImage = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_COIN_IMAGE).GetComponent<Image>();
        gameRules_btn = GameObject.FindGameObjectWithTag(GameConstants.GAME_RULES_BUTTON).GetComponent<Button>();
        moreGames_btn = GameObject.FindGameObjectWithTag(GameConstants.MORE_GAMES_BUTTON).GetComponent<Button>();
        logOutLogIn_btn = GameObject.FindGameObjectWithTag(GameConstants.LOGOUT_LOGIN_BUTTON).GetComponent<Button>();
        regsiterYourAccount_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVS_REGISTER_ACCOUNT_BUTTON).GetComponent<Button>();
        music_btn = GameObject.FindGameObjectWithTag(GameConstants.MUSIC_BUTTON).GetComponent<Button>();
        sound_btn = GameObject.FindGameObjectWithTag(GameConstants.SOUND_BUTTON).GetComponent<Button>();
        settingsCanvasLike_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS_LIKE_BUTTON).GetComponent<Button>();
        share_btn = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_SHARE_BUTTON).GetComponent<Button>();
        like_btn = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_LIKE_BUTTON).GetComponent<Button>();
        rate_btn = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_RATE_BUTTON).GetComponent<Button>();
        play_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_PLAY_BUTTON).GetComponent<Button>();
        settings_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_BUTTON).GetComponent<Button>();
        settings_canvas = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS).GetComponent<Canvas>();
        main_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_MAIN_CANVAS).GetComponent<Canvas>();
        settingsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS_BACK_BUTTON).GetComponent<Button>();
        settingsCanvasEditProfile_btn = GameObject.FindGameObjectWithTag(GameConstants.SETTINGS_CANVAS_EDITPROFILE_BUTTON).GetComponent<Button>();
        editProfileCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_BACK_BUTTON).GetComponent<Button>();
        editProfileCanvasContinue_btn = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_CONTINUE_BUTTON).GetComponent<Button>();
        editProfile_canvas = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS).GetComponent<Canvas>();
        editProfileCanvas_displayName = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_DISPLAY_NAME).GetComponent<Text>();
        editProfileCanvasUserImage_btn = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_USERIMAGE_BUTTON).GetComponent<Button>();
        editProfileCanvas_userImage = GameObject.FindGameObjectWithTag(GameConstants.EDITPROFILE_CANVAS_USERIMAGE_BUTTON).GetComponent<Image>();
        displayImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_DISPLAY_IMAGE).GetComponent<Image>();
        DisplayName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_DISPLAY_NAME).GetComponent<Text>();
        CountryName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_COUNTRY_NAME).GetComponent<Text>();
        NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_NO_OF_COINS).GetComponent<Text>();
        countryImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_COUNTRY_IMAGE).GetComponent<Image>();
        statsCanvas_displayName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_DISPLAY_NAME).GetComponent<Text>();
        statsCanvas_countryName = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_COUNTRY_NAME).GetComponent<Text>();
        statsCanvas_NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_NOOFCOINS).GetComponent<Text>();
        statsCanvas_countryImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_COUNTRY_IMAGE).GetComponent<Image>();
        profileBox_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_PROFILEBOX_BUTTON).GetComponent<Button>();
        stats_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS).GetComponent<Canvas>();
        statsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_BACK_BUTTON).GetComponent<Button>();
        statsCanvas_displayImage = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_STATS_CANVAS_DISPLAY_IMAGE).GetComponent<Image>();
        vsComputerWins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSCOMPUTER_WINS).GetComponent<Text>();
        vsComputerLoses = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSCOMPUTER_LOSES).GetComponent<Text>();
        vsMultiplayerWins = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSMULTIPLAYER_WINS).GetComponent<Text>();
        vsMultiplayerLoses = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_VSMULTIPLAYER_LOSES).GetComponent<Text>();
        vsComputerWinsSAL = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_SAL_VSCOMPUTER_WIN).GetComponent<Text>();
        vsComputerLosesSAL = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_SAL_VSCOMPUTER_LOSE).GetComponent<Text>();
        vsMultiplayerWinsSAL = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_SAL_VSMULTIPLAYER_WIN).GetComponent<Text>();
        vsMultiplayerLosesSAL = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_SAL_VSMULTIPLAYER_LOSE).GetComponent<Text>();
        exit_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_BUTTON).GetComponent<Button>();
        exitCanvasYes_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS_YES_BUTTON).GetComponent<Button>();
        exitCanvasNo_btn = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS_NO_BUTTON).GetComponent<Button>();
        exit_canvas = GameObject.FindGameObjectWithTag(GameConstants.EXIT_CANVAS).GetComponent<Canvas>();
        //challangeNo_btn = GameObject.Find("NO").GetComponent<Button>();
        //challenge_msg = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_CANVAS_CHALLENGE_MESSAGE).GetComponent<Text>();
        //challenge_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_CANVAS_CHALLENGE_REQUEST).GetComponent<Canvas>();
        //challengeYes_btn = GameObject.Find("YES").GetComponent<Button>();


        spin_wheel.GetComponent<Animator>().enabled = false;
        spin_wheel.GetComponent<SpriteRenderer>().enabled = false;
        moreGames_btn.interactable = false;

        LoadPlayerData();
        Set_Wins_Loses();

        CheckIfPlayAsGuestOrNot();

        if (Database.GetMusicStatus() == GameConstants.MUSIC_PLAYING_TRUE)
        {
            music_btn.GetComponent<Image>().sprite = music_sprites[0];

        }
        else
        {
            music_btn.GetComponent<Image>().sprite = music_sprites[1];
        }

        if (Database.GetSoundStatus() == GameConstants.SOUND_PLAYING_TRUE)
        {
            sound_btn.GetComponent<Image>().sprite = sound_sprites[0];
        }
        else
        {
            sound_btn.GetComponent<Image>().sprite = sound_sprites[1];
        }



    }

    private void Start()
    {
        displayImage_string = "None";

        if (GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS_OK_BUTTON) != null)
        {
            dailyBonusOk_btn.onClick.AddListener(DailyBonusOkBtn);
        }
        watchAdBonusOk_btn.onClick.AddListener(WatchAdBonusOkBtn);
        spinCanvasBack_btn.onClick.AddListener(SpinCanvasBackBtn);
        getSpinByWatchingAd_btn.onClick.AddListener(GetSpinByWatchingAdBtn);
        spinWinDialogOk_btn.onClick.AddListener(SpinWinDialogOkButton);
        ad_btn.onClick.AddListener(AdBtn);
        //challangeNo_btn.onClick.AddListener(ChallengeNoBtn);
        //challengeYes_btn.onClick.AddListener(ChallengeYesBtn);
        //spinWinDialog_btn.onClick.AddListener(SpinWinDialogBtn);
        gameRulesBack_btn.onClick.AddListener(GameRulesBackBtn);
        play_btn.onClick.AddListener(PlayBtn);
        settings_btn.onClick.AddListener(SettingsBtn);
        settingsCanvasBack_btn.onClick.AddListener(SettingsBackBtn);
        settingsCanvasEditProfile_btn.onClick.AddListener(SettingsEditProfileBtn);
        editProfileCanvasBack_btn.onClick.AddListener(EditProfileBakcBtn);
        editProfileCanvasContinue_btn.onClick.AddListener(EditProfileContinueBtn);
        editProfileCanvasUserImage_btn.onClick.AddListener(EditProfileUserImageBtn);
        profileBox_btn.onClick.AddListener(ProfileBoxBtn);
        statsCanvasBack_btn.onClick.AddListener(StatsBackBtn);
        exit_btn.onClick.AddListener(ExitBtn);
        exitCanvasNo_btn.onClick.AddListener(ExitNoBtn);
        exitCanvasYes_btn.onClick.AddListener(ExitYesBtn);

        like_btn.onClick.AddListener(LikeBtn);
        settingsCanvasLike_btn.onClick.AddListener(LikeBtn);
        music_btn.onClick.AddListener(MusicBtn);
        sound_btn.onClick.AddListener(SoundBtn);
        regsiterYourAccount_btn.onClick.AddListener(RegisterYourAccountBtn);
        logOutLogIn_btn.onClick.AddListener(LogInLogOutBtn);
        gameRules_btn.onClick.AddListener(GameRulesBtn);
        spin_btn.onClick.AddListener(SpinBtn);
        spinCanvasSpin_btn.onClick.AddListener(SpinCanvasSpinBtn);
        share_btn.onClick.AddListener(OnAndroidTextSharingClick);
        rate_btn.onClick.AddListener(RateUs);

        if (GameObject.FindGameObjectWithTag(GameConstants.LUDO_TO_SAL_BUTTON) != null)
        {
            ludoToSal_btn.onClick.AddListener(LudoToSalBtn);
        }



        //SAL
        if (GameObject.FindGameObjectWithTag(GameConstants.SAL_TO_LUDO_BUTTON) != null)
        {
            salToLudo_btn.onClick.AddListener(SalToLudoBtn);
        }

        backPressCount = 0;
        FacebookLoggedInMethod();
        startGame = false;
        getOneMoreSpin = false;
        startTimer = false;
        spin_time_remaining = "---";
        ADCoins = 0;
        hours = 23;
        minutes = 59;
        seconds = 60;

        if (GameObject.FindGameObjectWithTag(GameConstants.CANVAS_DAILY_BONUS) != null)
        {
            DailyBonus();
        }

        //GetSavedSystemTime();
    }


    private void Update()
    {
        //OnBackPress();
        if (startGame)
        {
            startGame = false;
            StartCoroutine(StartGame());
        }
        if (game_manager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded)
        {
            if (!LoginWithFB.FacebookLoggedIn)
            {
                MainMenu.searchAnim.GetComponent<Animator>().enabled = false;
                Debug.Log("Image Downloaded");
                game_manager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded = false;
                Rect rec = new Rect(0, 0, game_manager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.width,
                                    game_manager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.height);
                MainMenu.searchAnim.GetComponent<SpriteRenderer>().sprite =
                        Sprite.Create(game_manager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage, rec, new Vector2(0.5f, 0.5f), 100);
            }
        }

        //if (startTimer)
        //{
        //    StartCoroutine(SpinTimer());
        //    Database.SetSystemHour(Register.userId, DateTime.Now.Hour);
        //    Database.SetSystemMinutes(Register.userId, DateTime.Now.Minute);
        //    Database.SetSystemSeconds(Register.userId, DateTime.Now.Second);
        //    startTimer = false;
        //}
        //spinTimeRemaining.text = spin_time_remaining;
        //Debug.Log(DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second);


    }


    IEnumerator SpinTimer(){
        yield return new WaitForSeconds(1);
        if (hours == 0 && minutes == 0 && seconds == 0)
        {
            hours = 23;
            minutes = 59;
            seconds = 59;
            spinTimeRemaining.text = "---";
        }
        else
        {
            seconds--;
            if (seconds == 0)
            {
                seconds = 60;
                minutes--;
            }
            if (minutes == 0)
            {
                minutes = 59;
                hours--;
            }
            spin_time_remaining = hours + ":" + minutes + ":" + seconds;
            StartCoroutine(SpinTimer());
        }
    }



    private void WatchAdBonusOkBtn()
    {
        watchAdBonus_canvas.enabled = false;
        int coins = Database.GetPlayerCoins(Register.userId);
        coins = coins + ADCoins;
        Database.SetPlayerCoins(Register.userId, coins);
        NoOfCoins.text = "" + coins;
        statsCanvas_NoOfCoins.text = "" + coins;

    }



    private void DailyBonusOkBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }

        string current_date = DateTime.Now.Date.Day.ToString();
        Database.SetDailyBonusCoins(Register.userId, dailyBonusCoins);
        int existing_coins = Database.GetPlayerCoins(Register.userId);
        dailyBonusCoins = existing_coins + dailyBonusCoins;
        Database.SetPlayerCoins(Register.userId, dailyBonusCoins);
        Database.SetDailyBonusDate(Register.userId, current_date);

        dailyBonus_canvas.enabled = false;
        NoOfCoins.text = "" + Database.GetPlayerCoins(Register.userId);
        statsCanvas_NoOfCoins.text = "" + Database.GetPlayerCoins(Register.userId);
    }



    private void SpinCanvasBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        spin_canvas.enabled = false;
        spin_wheel.GetComponent<SpriteRenderer>().enabled = false;
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
    }

    private void GetSpinByWatchingAdBtn()
    {
        if (!playAsGuest)
        {
            if (Register.isSoundPlaying)
            {
                audioSource.Play();
            }
            string current_date = System.DateTime.Now.Date.ToString();
            string saved_date = Database.GetSpinAdDate(Register.userId);

            if (Database.GetSpinAdDate(Register.userId) == "0" || current_date != saved_date)
            {
                Database.SetSpinAdDate(Register.userId, current_date);
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    Advertisement.Show("rewardedVideo");
                    spin_canvas.enabled = true;
                    getOneMoreSpin = true;
                }
            }
            else
            {
                ShowToast.MyShowToastMethod("You can only get 1 spin free in 24 hours!");
                getOneMoreSpin = false;
            }
        }
        else
        {
            ShowToast.MyShowToastMethod("Login first to get Spin!");
            getOneMoreSpin = false;
        }
    }

    private void SpinWinDialogOkButton()
    {
        SpinWinDialogBtn();
    }

    private void AdBtn()
    {
        if (!playAsGuest)
        {
            if (Register.isSoundPlaying)
            {
                audioSource.Play();
            }
            string current_date = System.DateTime.Now.Date.ToString();
            string saved_date = Database.GetAdDate(Register.userId);

            if (Database.GetAdDate(Register.userId) == "0" || current_date != saved_date)
            {
                Database.SetAdDate(Register.userId, current_date);
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
                }
            }
            else
            {
                ShowToast.MyShowToastMethod("You can only watch ad once in 24 hours!");
            }
        }
        else
        {
            ShowToast.MyShowToastMethod("Login first to watch Ad!");
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("You got 100 coins!");

                int random = UnityEngine.Random.Range(0, 8);
                if (random == 0)
                {
                    Debug.Log("50");
                    watchAdBonusCoins_text.text = "" + 50;
                    ADCoins = 50;
                }
                else if (random == 1)
                {
                    Debug.Log("100");
                    watchAdBonusCoins_text.text = "" + 100;
                    ADCoins = 100;
                }
                else if (random == 2)
                {
                    Debug.Log("200");
                    watchAdBonusCoins_text.text = "" + 200;
                    ADCoins = 200;
                }
                else if (random == 3)
                {
                    Debug.Log("300");
                    watchAdBonusCoins_text.text = "" + 300;
                    ADCoins = 300;
                }
                else if (random == 4)
                {
                    Debug.Log("500");
                    watchAdBonusCoins_text.text = "" + 500;
                    ADCoins = 500;
                }
                else if (random == 5)
                {
                    Debug.Log("800");
                    watchAdBonusCoins_text.text = "" + 800;
                    ADCoins = 800;

                }
                else if (random == 6)
                {
                    Debug.Log("1000");
                    watchAdBonusCoins_text.text = "" + 1000;
                    ADCoins = 1000;
                }
                else if (random == 7)
                {
                    Debug.Log("1500");
                    watchAdBonusCoins_text.text = "" + 1500;
                    ADCoins = 1500;

                }

                watchAdBonus_canvas.enabled = true;
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped!");
                ShowToast.MyShowToastMethod("You missed some coins!");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad Failed to Luanch!");
                ShowToast.MyShowToastMethod("Ad Failed To Launch!");
                break;
        }
    }

    private void ChallengeNoBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        challenge_canvas.enabled = false;
        List<string> ids = new List<string>();
        ids.Add(challenger_id);
        new SendFriendMessageRequest().SetFriendIds(ids).SetMessage(LoginWithFB.displayName_FB + " doesn't want to Play!").Send((response) =>
        {
            MakeAMatch.UserAccountDetails();
            MakeAMatch.ChallengeSatrtedListener();
            MakeAMatch.MatchFoundListener();
            MakeAMatch.MatchNotFoundListener();
            MakeAMatch.ChatOnChallegeListener();

            if (!response.HasErrors)
            {

            }
            else
            {
                Debug.Log("Message Not Sent!");
            }
        });
    }

    private void ChallengeYesBtn(){
        challengeYes_btn.interactable = false;
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        MakeAMatch.UserAccountDetails();
        MakeAMatch.ChallengeSatrtedListener();
        MakeAMatch.MatchFoundListener();
        MakeAMatch.MatchNotFoundListener();
        MakeAMatch.ChatOnChallegeListener();


        string match_key = "";
        if (FacebookFriendList.Challenge_Game_Name == GameConstants.LUDO_CHALLENGE)
        {
            match_key = GameConstants.TWO_PLAYERS_MATCH_100;
        }
        else
        {
            match_key = GameConstants.SAL_TWO_PLAYERS_MATCH_100;
        }
        string jsonString = "{\"$in\":[\"" + challenger_id + "\"]}";
        GSRequestData customQuery = new GSRequestData().AddJSONStringAsObject("players.playerId", jsonString);
        new MatchmakingRequest().SetSkill(100).SetMatchShortCode(match_key).SetCustomQuery(customQuery).Send((response) =>
        {
            
            if (!response.HasErrors)
            {
                string game = "";
                if (FacebookFriendList.Challenge_Game_Name == GameConstants.LUDO_CHALLENGE){
                    game = GameConstants.LUDO_CHALLENGE;
                }
                else
                {
                    game = GameConstants.SNAKES_AND_LADDER;
                }
                GameInitializer.SetGame(game, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
                //challenge_canvas.enabled = false;
            }
            else
            {
                ShowToast.MyShowToastMethod("Error Accepting Request");
                main_canvas.GetComponent<CanvasGroup>().interactable = true;
                challenge_canvas.enabled = false;
            }
        });
    }

    private void LudoToSalBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        Register.Game = GameConstants.SNAKES_AND_LADDER;
        SceneManager.LoadScene(GameConstants.START_MENU_SAL_SCENE);
        PlayerActivation.canMoveMarker = true;
    }

    private void SalToLudoBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        Register.Game = GameConstants.LUDO_CHALLENGE;
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    }

    private void SpinWinDialogBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        spinWinDialog_canvas.enabled = false;
        spin_wheel.GetComponent<SpriteRenderer>().enabled = false;
        spin_wheel.GetComponent<Animator>().enabled = false;
        spin_canvas.enabled = false;
    }


    private void SpinBtn()
    {
        if (!playAsGuest)
        {
            if (Register.isSoundPlaying)
            {
                audioSource.Play();
            }
            spin_canvas.enabled = true;
            main_canvas.GetComponent<CanvasGroup>().interactable = false;
            spin_wheel.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
			ShowToast.MyShowToastMethod("Login first to get Spin!");
        }

    }

    private void SpinCanvasSpinBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }


        if (!playAsGuest)
        {
            if (Register.isSoundPlaying)
            {
                audioSource.Play();
            }
            string current_date = System.DateTime.Now.Date.ToString();
            string saved_date = Database.GetDate(Register.userId);

            if (Database.GetDate(Register.userId) == "0" || current_date != saved_date)
            {
                //test
                Database.SetDate(Register.userId, current_date);
                spin_wheel.GetComponent<Animator>().enabled = true;
                int timer = UnityEngine.Random.Range(4, 8);
                StartCoroutine(StopSpinWheel(timer));
                getOneMoreSpin = false;
                startTimer = true;
            }
            else if (getOneMoreSpin)
            {
                Database.SetDate(Register.userId, current_date);
                spin_wheel.GetComponent<Animator>().enabled = true;
                int timer = UnityEngine.Random.Range(4, 8);
                StartCoroutine(StopSpinWheel(timer));
                getOneMoreSpin = false;
            }
            else
            {
                ShowToast.MyShowToastMethod("You can only spin once in 24 hours!");
            }
        }
        else
        {
            ShowToast.MyShowToastMethod("Login first to Get Spin!");
        }


    }


    private void RegisterYourAccountBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene(GameConstants.REGISTER_SCENE);
    }

    private void LogInLogOutBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        new EndSessionRequest().Send((response) =>
        {
            if (response.HasErrors)
            {
                Debug.Log("Error");
                ShowToast.MyShowToastMethod("Error Logging Out!");
                GS.Reset();
            }
            else
            {
                Debug.Log("Successful");
                ShowToast.MyShowToastMethod("Logged Out!");
                Database.SetLoginStatus(GameConstants.LOGGED_OUT);
                SceneManager.LoadScene(GameConstants.REGISTER_SCENE);

            }
        });

    }


    private void GameRulesBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        settings_canvas.enabled = true;
        gameRules_canvas.enabled = false;
    }


    private void GameRulesBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        settings_canvas.enabled = false;
        gameRules_canvas.enabled = true;
    }

    private void MusicBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (music_btn.GetComponent<Image>().sprite == music_sprites[0])
        {
            music_btn.GetComponent<Image>().sprite = music_sprites[1];
            Music.isMusicPlaying = false;
            Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_FALSE);
        }

        else
        {
            music_btn.GetComponent<Image>().sprite = music_sprites[0];
            Music.isMusicPlaying = true;
            Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_TRUE);

        }
    }

    private void SoundBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (sound_btn.GetComponent<Image>().sprite == sound_sprites[0])
        {
            sound_btn.GetComponent<Image>().sprite = sound_sprites[1];
            Register.isSoundPlaying = false;
            Database.SetSoundStatus(GameConstants.SOUND_PLAYING_FALSE);
        }
        else
        {
            sound_btn.GetComponent<Image>().sprite = sound_sprites[0];
            Register.isSoundPlaying = true;
            Database.SetSoundStatus(GameConstants.SOUND_PLAYING_TRUE);
        }
    }


    private void LikeBtn()
    {

    }

    private void ExitBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        exit_canvas.enabled = true;
    }

    private void ExitNoBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        exit_canvas.enabled = false;
    }

    private void ExitYesBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        exit_canvas.enabled = false;
        Application.Quit();
    }

    private void PlayBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        //change scene
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            SceneManager.LoadScene(GameConstants.MAINMENU_SCENE);
        }
        else{
            SceneManager.LoadScene(GameConstants.MAIN_MENU_SAL_SCENE);
        }
    }

    private void SettingsBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        settings_canvas.enabled = true;
    }

    private void SettingsBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        settings_canvas.enabled = false;
    }

    private void SettingsEditProfileBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        editProfileCanvas_displayName.text = DisplayName.text;
        Debug.Log(DisplayName.text);
        settings_canvas.enabled = false;
        editProfile_canvas.enabled = true;
    }

    private void EditProfileBakcBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        editProfile_canvas.enabled = false;
        settings_canvas.enabled = true;
    }
    private void EditProfileContinueBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        int noOfCoins;
        string path = Database.GetPlayerDisplayImagePath(Register.userId);
        int.TryParse(NoOfCoins.text, out noOfCoins);
        string displayName = editProfileCanvas_displayName.text;
        Database.setPlayerDataInGameSpark(displayName, CountryName.text, path);
        Database.setPlayerDisplayImageinGameSpark(displayImage_string);
        Database.setPlayerDataInLocalDatabase(displayName, CountryName.text, noOfCoins, Register.userId);
        LoadPlayerData();

        editProfile_canvas.enabled = false;
        main_canvas.GetComponent<CanvasGroup>().interactable = true;


        Texture2D tex = new Texture2D(texture.width / 2, texture.height / 2, TextureFormat.Alpha8, false);
        tex = duplicateTexture(texture);
        tex.Compress(false);

        Database.UploadDisplayImageInGameSpark(tex.EncodeToJPG(50));


    }


    private void EditProfileUserImageBtn()
    {
        OpenGallery(10000);

        if (texture != null)
        {
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            editProfileCanvas_userImage.sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        }
        displayImage_string = Texture2DToBase64(texture);

    }


    private void ProfileBoxBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        stats_canvas.enabled = true;
    }


    private void StatsBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        stats_canvas.enabled = false;
    }


    private void OpenGallery(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {

            if (path != null)
            {
                Database.SetPlayerDisplayImagePath(Register.userId, path);
                texture = new Texture2D(NativeGallery.LoadImageAtPath(path, maxSize).width / 2, NativeGallery.LoadImageAtPath(path, maxSize).height / 2, TextureFormat.Alpha8, false);
                texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    ShowToast.MyShowToastMethod("Couldn't load Picture!");
                    return;
                }
            }
        }, "Select a PNG image", "image/jpg", maxSize);
    }




    public static string Texture2DToBase64(Texture2D texture)
    {
        byte[] imageData = texture.EncodeToPNG();
        return Convert.ToBase64String(imageData);
    }

    public static Texture2D Base64ToTexture2D(string encodedData)
    {
        byte[] imageData = Convert.FromBase64String(encodedData);

        int width, height;
        GetImageSize(imageData, out width, out height);

        Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
        tex.hideFlags = HideFlags.HideAndDontSave;
        tex.filterMode = FilterMode.Point;
        tex.LoadImage(imageData);

        return tex;
    }

    public static void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }


    private static int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8) | imageData[offset + 1];
    }

    private void Set_Wins_Loses()
    {
        Debug.Log("Set Win Loses Method");
        Debug.Log(Register.userId);
        vsComputerWins.text = "" + Database.getVsComputerWins(Register.userId);
        vsComputerLoses.text = "" + Database.getVsComputerLoses(Register.userId);
        vsMultiplayerWins.text = "" + Database.getVsMultiplayerWins(Register.userId);
        vsMultiplayerLoses.text = "" + Database.getVsMultiplayerLoses(Register.userId);
        vsComputerWinsSAL.text = "" + Database.getVsComputerWinsSAL(Register.userId);
        vsComputerLosesSAL.text = "" + Database.getVsComputerLosesSAL(Register.userId);
        vsMultiplayerWinsSAL.text = "" + Database.getVsMultiplayerWinsSAL(Register.userId);
        vsMultiplayerLosesSAL.text = "" + Database.getVsMultiplayerLosesSAL(Register.userId);
    }


    private void LoadPlayerData()
    {
        editProfileCanvas_displayName.text = Database.GetPlayerDisplayName(Register.userId);

        DisplayName.text = Database.GetPlayerDisplayName(Register.userId);
        CountryName.text = Database.GetPlayerCountryName(Register.userId);
        NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
        countryImage.sprite = Database.LoadCountryImage(CountryName.text);

        statsCanvas_displayName.text = Database.GetPlayerDisplayName(Register.userId);
        statsCanvas_countryName.text = Database.GetPlayerCountryName(Register.userId);
        statsCanvas_NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
        statsCanvas_countryImage.sprite = Database.LoadCountryImage(CountryName.text);

        if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
        {
            editProfileCanvas_userImage.sprite = Database.GetPlayerDisplayImage(texture);
            displayImage.sprite = Database.GetPlayerDisplayImage(texture);
            statsCanvas_displayImage.sprite = Database.GetPlayerDisplayImage(texture);
        }

    }



    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }


    IEnumerator StopSpinWheel(float timer)
    {
        yield return new WaitForSeconds(timer);

        //main_canvas.GetComponent<CanvasGroup>().interactable = true;
        spin_wheel.GetComponent<Animator>().enabled = false;

        spin_wheel.GetComponent<Animator>().enabled = false;
        spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 25);
        //spin_canvas.GetComponent<CanvasGroup>().interactable = false;

        StartCoroutine(spinWinDialogEnumerator());
        int win_coins = UnityEngine.Random.Range(0, 8);
        int coins = Database.GetPlayerCoins(Register.userId);
        if (win_coins == 0)
        {
            Debug.Log("50");
            coins = coins + 50;
            spinWinDialogCoins_text.text = "50";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 45 + 10);
        }
        else if (win_coins == 1)
        {
            Debug.Log("100");
            coins = coins + 100;
            spinWinDialogCoins_text.text = "100";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 90 - 25);
        }
        else if (win_coins == 2)
        {
            Debug.Log("200");
            coins = coins + 200;
            spinWinDialogCoins_text.text = "200";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 135 - 25);
        }
        else if (win_coins == 3)
        {
            Debug.Log("300");
            coins = coins + 300;
            spinWinDialogCoins_text.text = "300";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 180 - 25);
        }
        else if (win_coins == 4)
        {
            Debug.Log("500");
            coins = coins + 500;
            spinWinDialogCoins_text.text = "500";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 225 - 25);
        }
        else if (win_coins == 5)
        {
            Debug.Log("800");
            coins = coins + 800;
            spinWinDialogCoins_text.text = "800";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 270 - 25);
        }
        else if (win_coins == 6)
        {
            Debug.Log("1000");
            coins = coins + 1000;
            spinWinDialogCoins_text.text = "1000";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 315 - 25);
        }
        else if (win_coins == 7)
        {
            Debug.Log("1500");
            coins = coins + 1500;
            spinWinDialogCoins_text.text = "1500";
            spin_wheel.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, spin_wheel.GetComponent<Transform>().rotation.z + 360 - 25);
        }

        Database.SetPlayerCoins(Register.userId, coins);

        NoOfCoins.text = "" + Database.GetPlayerCoins(Register.userId);
        statsCanvas_NoOfCoins.text = "" + Database.GetPlayerCoins(Register.userId);
    }

    IEnumerator spinWinDialogEnumerator(){
        yield return new WaitForSeconds(1.5f);
        if (Register.isSoundPlaying)
        {
            dialogSource.Play();

            spin_canvas.enabled = false;
            spin_wheel.GetComponent<SpriteRenderer>().enabled = false;
            spinWinDialog_canvas.enabled = true;
        }
    }



    private void FacebookLoggedInMethod(){
        if(LoginWithFB.FacebookLoggedIn){
            DisplayName.text = LoginWithFB.displayName_FB;
            statsCanvas_displayName.text = LoginWithFB.displayName_FB;
            CountryName.text = LoginWithFB.countryName;
            statsCanvas_countryName.text = LoginWithFB.countryName;
            countryImage.sprite = Database.LoadCountryImage(CountryName.text);
            statsCanvas_countryImage.sprite = Database.LoadCountryImage(CountryName.text);
            NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
            statsCanvas_NoOfCoins.text = (Database.GetPlayerCoins(Register.userId)).ToString();
            displayImage.sprite = Sprite.Create(LoginWithFB.FB_Image, new Rect(0, 0, 100, 100), new Vector2(0, 0));
            statsCanvas_displayImage.sprite = Sprite.Create(LoginWithFB.FB_Image, new Rect(0, 0, 100, 100), new Vector2(0, 0));
            FacebookFriendList.ReceiveChallenge();
        }
    }

    public IEnumerator StartGame()
    {
        //MainMenu.searchAnim.GetComponent<Animator>().enabled = false;
        if (!LoginWithFB.FacebookLoggedIn)
        {
            for (int i = 0; i < 2; i++)
            {
                if (MakeAMatch.opponents_name[i] != MakeAMatch.displayName)
                {
                    if (MakeAMatch.opponents_image_ids[i] != "0")
                    {
                        game_manager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_ids[i]);
                        break;
                    }
                }
            }
            MainMenu.searchingForPlayer_canvas.enabled = false;
            MainMenu.searchingForPlayer_anim.SetActive(false);
            MainMenu.searchingForPlayerTimeRemaining_text.enabled = false;
        }
        else
        {
            game_manager.GetComponent<UploadAndRetieveProfilePic>().DownloadImage(MakeAMatch.FB_opponentsImageURL);
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GamePlay");
        main_canvas.GetComponent<CanvasGroup>().interactable = true;

    }

    public void CheckIfPlayAsGuestOrNot()
    {
        if (playAsGuest)
        {
            DisplayName.enabled = false;
            CountryName.enabled = false;
            NoOfCoins.enabled = false;
            countryImage.enabled = false;
            coinImage.enabled = false;
            statsCanvas_displayName.enabled = false;
            statsCanvas_countryName.enabled = false;
            statsCanvas_NoOfCoins.enabled = false;
            statsCanvas_countryImage.enabled = false;
            statsCoinImage.enabled = false;
            guestText.enabled = true;
            settingsCanvasEditProfile_btn.interactable = false;
            logOutLogIn_btn.interactable = false;
            ad_btn.interactable = false;
            if (Register.RegisterScreen)
            {
                guestText.text = Register.GuestName;
                displayImage.sprite = Register.guestImage.sprite;
                statsCanvas_displayImage.sprite = Register.guestImage.sprite;
            }
            else{
                guestText.text = Login.GuestName;
                displayImage.sprite = Login.guestImage.sprite;
                statsCanvas_displayImage.sprite = Login.guestImage.sprite;
            }
            profileBox_btn.enabled = false;
        }
        else
        {
            DisplayName.enabled = true;
            CountryName.enabled = true;
            NoOfCoins.enabled = true;
            countryImage.enabled = true;
            coinImage.enabled = true;
            statsCanvas_displayName.enabled = true;
            statsCanvas_countryName.enabled = true;
            statsCanvas_NoOfCoins.enabled = true;
            statsCanvas_countryImage.enabled = true;
            statsCoinImage.enabled = true;
            guestText.enabled = false;
            settingsCanvasEditProfile_btn.interactable = true;
            logOutLogIn_btn.interactable = true;
        }
        if(LoginWithFB.FacebookLoggedIn){
            settingsCanvasEditProfile_btn.interactable = false;
        }
    }


    public void OnAndroidTextSharingClick()
    {

        StartCoroutine(ShareAndroidText());
    }


    IEnumerator ShareAndroidText()
    {
        yield return new WaitForEndOfFrame();
        //execute the below lines if being run on a Android device
        #if UNITY_ANDROID
        //Reference of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        //Reference of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Text Sharing ");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
        currentActivity.Call("startActivity", jChooser);
        #endif
    }


    public void RateUs()
    {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=YOUR_ID");
        #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
        #endif
    }

    public void OnBackPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                backPressCount++;
                if (backPressCount == 0)
                {
                    ShowToast.MyShowToastMethod("Press again to exit Game!!");
                }
        }
        if (backPressCount >= 2)
        {
            //Change Scene
            Application.Quit();
        }
    }

    //void OnApplicationPause(bool pauseState)
    //{
    //    if (pauseState)
    //    {
    //        string current_date = System.DateTime.Now.Date.ToString();
    //        Database.SetDailyBonusDate(Register.userId, current_date);
    //    }
    //}


    private void DailyBonus(){
        dailyBonusCoins = 0;
        if (!playAsGuest)
        {
            string current_date = DateTime.Now.Date.Day.ToString();
            string saved_date = Database.GetDailyBonusDate(Register.userId);

            if (saved_date == "0")
            {
                dailyBonusCoins = 50;
                dailyBonusCoins_text.text = "" + dailyBonusCoins;
                dailyBonus_canvas.enabled = true;
          
            }
            else if (current_date != saved_date)
            {
                int c_date = 0, s_date = 0;
                Int32.TryParse(current_date, out c_date);
                Int32.TryParse(saved_date, out s_date);
                int difference = c_date - s_date;
                if (difference == 1 || difference == -1)
                {
                    dailyBonusCoins = Database.GetDailyBonusCoins(Register.userId);
                    dailyBonusCoins = dailyBonusCoins + 50;
                }
                else{
                    
                    dailyBonusCoins = 50;
                }

                dailyBonusCoins_text.text = "" + dailyBonusCoins;
                dailyBonus_canvas.enabled = true;
            }
        }
    }


    private void GetSavedSystemTime()
    {
        string current_date = System.DateTime.Now.Date.ToString();
        string saved_date = Database.GetDate(Register.userId);
        if (current_date == saved_date)
        {
            int _hours = Database.GetSystemHour(Register.userId);
            int _minutes = Database.GetSystemMinutes(Register.userId);
            int _seconds = Database.GetSystemSeconds(Register.userId);
            Debug.Log("Saved Hours: " + _hours);
            Debug.Log("Saved Minutes: " + _minutes);
            Debug.Log("Saved Seconds: " + _seconds);

            if (_hours != -1)
            {
                startTimer = true;
                int currentHours = DateTime.Now.Hour;
                int currentMinutes = DateTime.Now.Minute;
                int currentSeconds = DateTime.Now.Second;

                Debug.Log("Current Hours: " + currentHours);
                Debug.Log("Current Minutes: " + currentMinutes);
                Debug.Log("Current Seconds: " + currentSeconds);

                hours = _hours - currentHours;
                if (hours < 0)
                {
                    hours = hours * -1;
                }
                hours = 23 - hours;

                minutes = _minutes - currentMinutes;
                if (minutes < 0)
                {
                    minutes = minutes * -1;
                }
                minutes = 60 - minutes;
                Debug.Log("Final Minutes: " + minutes);

                seconds = _seconds - currentSeconds;
                if (seconds < 0)
                {
                    seconds = seconds * -1;
                }
                seconds = 60 - seconds;
            }
        }


    }



}



