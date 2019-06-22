using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;


public class MainMenu : MonoBehaviour
{

    public Sprite[] checkBox_sprite;

    private Button onlineMultiplayer_btn, onlineMultiplayer_canvas_2players_btn, onlineMultiplayer_canvas_4players_btn,
    room2Players_canvas_cost100_btn, room2Players_canvas_cost500_btn, room2Players_canvas_cost5000_btn,
    room2Players_canvas_cost25000_btn, room2Players_canvas_cost50000_btn, room2Players_canvas_cost100000_btn,
    room2Players_canvas_cost250000_btn, room2Players_canvas_cost500000_btn, room2Players_canvas_cost750000_btn,
    room4Players_canvas_cost100_btn, room4Players_canvas_cost500_btn, room4Players_canvas_cost5000_btn,
    room4Players_canvas_cost25000_btn, room4Players_canvas_cost50000_btn, room4Players_canvas_cost100000_btn,
    room4Players_canvas_cost250000_btn, room4Players_canvas_cost500000_btn, room4Players_canvas_cost750000_btn,
    playAnotherRoom_btn, getMoreCoins_btn, room2PlayersBack_btn, profileBox_btn, statsCanvasBack_btn, onlineMultiplayerCanvasBack_btn,
    localMultiplayer_btn, localMultiplayer2Players_btn, localMultiplayer3Players_btn, localMultiplayer4Players_btn, localMultiplayerBack_btn,
    selectYourColor2PlayersBack_btn, selectYourColor2PlayersPlay_btn, selectYourColor2PlayersOption1_btn, selectYourColor2PlayersOption2_btn,
    selectYourColor3PlayersBack_btn, selectYourColor3PlayersPlay_btn, selectYourColor3PlayersOption1_btn, selectYourColor3PlayersOption2_btn,
    selectYourColor4PlayersBack_btn, selectYourColor4PlayersPlay_btn, playWithComputer_btn, playWithComputerBack_btn, playWithComputerPlay_btn,
    playWithComputer_btn1, playWithComputer_btn2, playWithComputer_btn3, playWithComputer_btn4, mainMenuBack_btn, room4PlayersBack_btn, loopHole_btn, 
    playWithFriends_btn, friendListCanvasBack_btn;

    public static Button messageBox_btn;
    private int loopHoleCount;

    public static CanvasGroup main_canvas, selectYourColor2PlayersOption1_Fields, selectYourColor2PlayersOption2_Fields,
    selectYourColor3PlayersOption1_Fields, selectYourColor3PlayersOption2_Fields;

    private Canvas localMultiplayer_canvas, selectYourColor2Players_canvas, selectYourColor3Players_canvas, selectYourColor4Players_canvas, playWithComputer_canvas,
    onlineMultiplayer_canvas, room2Players_canvas, room4Players_canvas, stats_canvas, notEnoughCoins_canvas;
    public static Canvas searchingForPlayer_canvas, messageBox_canvas, friendList_canvas;

    private Image displayImage, countryImage, statsCanvas_displayImage, statsCanvas_countryImage, coinsImage, statsCoinImage;

    private Text DisplayName, CountryName, NoOfCoins, statsCanvas_displayName, statsCanvas_countryName, statsCanvas_NoOfCoins, selectYourColor2PlayersOption1Player1_name,
    selectYourColor2PlayersOption1Player2_name, selectYourColor2PlayersOption2Player1_name, selectYourColor2PlayersOption2Player2_name,
    selectYourColor3PlayersOption1Player1_name, selectYourColor3PlayersOption1Player2_name, selectYourColor3PlayersOption1Player3_name,
    selectYourColor3PlayersOption2Player1_name, selectYourColor3PlayersOption2Player2_name, selectYourColor3PlayersOption2Player3_name,
    selectYourColor4PlayersPlayer1_name, selectYourColor4PlayersPlayer2_name, selectYourColor4PlayersPlayer3_name, selectYourColor4PlayersPlayer4_name,
    vsComputerWins, vsComputerLoses, vsMultiplayerWins, vsMultiplayerLoses, vsComputerWinsSAL, vsComputerLosesSAL, vsMultiplayerWinsSAL, vsMultiplayerLosesSAL, guestText;

    public static Text messageBox_text;

    private int checkClick, playWithComputer_players;
    public static GameObject searchingForPlayer_anim;
    private string playWithComputer_color;
    public static int matchCost;
    public static int roomForPlayers;
    public static string displayImage_string = null;
    public static bool disableMessageBox;

    public static string player1Name = "Player 1";
    public static string player2Name = "Player 2";
    public static string player3Name = "Player 3";
    public static string player4Name = "Player 4";

    public AudioSource audioSource;
    //public AudioClip buttonSound;
    public AudioSource notificationSource;
    //public AudioClip notificationSound;

    public static Canvas challenge_canvas, challengeResponse_canvas, doesntWantToPlay_canvas;
    public static Text challenge_msg, acceptChallange_text, doesntWantToPlay_text;
    public static Button challengeYes_btn, challangeNo_btn;

    public static List<string> friendName = new List<string>();
    public static List<string> friendProfileId = new List<string>();
    public static List<bool> onlineStatus = new List<bool>();
    public static List<string> player_id = new List<string>();
    public static string challenger_id;
    public static Button doesntWantToPlay_btn;
    public static GameObject searchAnim;
    public static  Text searchingForPlayerTimeRemaining_text;
    public static float timeLeftToSearchPlayer = 60.0f;
    public static bool isSearchingForPlayer;



    private void Awake()
    {
        doesntWantToPlay_btn = GameObject.Find("DoesntWantToPlayButton").GetComponent<Button>();
        doesntWantToPlay_text = GameObject.Find("DoesntWantToPlayText").GetComponent<Text>();
        doesntWantToPlay_canvas = GameObject.Find("Canvas(DoesntwanttoPlay!)").GetComponent<Canvas>();
        challengeYes_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_CHALLENGE_YES_BUTTON).GetComponent<Button>();
        challangeNo_btn = GameObject.Find("NO").GetComponent<Button>();
        challengeYes_btn = GameObject.Find("YES").GetComponent<Button>();
        challenge_msg = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_CHALLENGE_MESSAGE).GetComponent<Text>();
        challenge_canvas = GameObject.Find("Canvas(ChallengeRequest)").GetComponent<Canvas>();
        challengeResponse_canvas = GameObject.Find("Canvas(ChallengeRequestResponse)").GetComponent<Canvas>();
        acceptChallange_text = GameObject.Find("AcceptChallange").GetComponent<Text>();

        searchingForPlayerTimeRemaining_text = GameObject.FindGameObjectWithTag(GameConstants.SEARCHING_FOR_PLAYER_TIME_REMAINING).GetComponent<Text>();
        searchAnim = GameObject.FindGameObjectWithTag(GameConstants.SEARCH_ANIMATION);
        friendList_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_FRIEND_LIST).GetComponent<Canvas>();
        friendListCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_BACK_BUTTON).GetComponent<Button>();
        playWithFriends_btn = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_FREINDS_BUTTON).GetComponent<Button>();
        //loopHole_btn = GameObject.FindGameObjectWithTag(GameConstants.LOOP_HOLE).GetComponent<Button>();
        guestText = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_GUEST_TEXT).GetComponent<Text>();
        statsCoinImage = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_STATS_COIN_IMAGE).GetComponent<Image>();
        coinsImage = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_COIN_IMAGE).GetComponent<Image>();
        room4PlayersBack_btn = GameObject.FindGameObjectWithTag(GameConstants.ROOM_FOUR_PLAYERS_BACK_BUTTON).GetComponent<Button>();
        messageBox_text = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MESSAGE_BOX_TEXT).GetComponent<Text>();
        messageBox_canvas = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MESSAGE_BOX_CANVAS).GetComponent<Canvas>();
        messageBox_btn = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MESSAGE_BOX_BUTTON).GetComponent<Button>();
        mainMenuBack_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_BACK_BUTTON).GetComponent<Button>();
        playWithComputer_btn1 = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BUTTON1).GetComponent<Button>();
        playWithComputer_btn2 = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BUTTON2).GetComponent<Button>();
        playWithComputer_btn3 = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BUTTON3).GetComponent<Button>();
        playWithComputer_btn4 = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BUTTON4).GetComponent<Button>();
        playWithComputerBack_btn = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BACK_BUTTON).GetComponent<Button>();
        playWithComputerPlay_btn = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_PLAY_BUTTON).GetComponent<Button>();
        playWithComputer_canvas = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_CANVAS).GetComponent<Canvas>();
        playWithComputer_btn = GameObject.FindGameObjectWithTag(GameConstants.PLAY_WITH_COMPUTER_BUTTON).GetComponent<Button>();
        selectYourColor4PlayersPlayer1_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_PLAYER1_NAME).GetComponent<Text>();
        selectYourColor4PlayersPlayer2_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_PLAYER2_NAME).GetComponent<Text>();
        selectYourColor4PlayersPlayer3_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_PLAYER3_NAME).GetComponent<Text>();
        selectYourColor4PlayersPlayer4_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_PLAYER4_NAME).GetComponent<Text>();
        selectYourColor4PlayersBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_BACK_BUTTON).GetComponent<Button>();
        selectYourColor4PlayersPlay_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_PLAY_BUTTON).GetComponent<Button>();
        selectYourColor4Players_canvas = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_4PLAYERS_CANVAS).GetComponent<Canvas>();
        selectYourColor3PlayersOption1Player1_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER1_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption1Player2_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER2_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption1Player3_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER3_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption2Player1_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER1_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption2Player2_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER2_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption2Player3_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER3_NAME).GetComponent<Text>();
        selectYourColor3PlayersOption1_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION1_BUTTON).GetComponent<Button>();
        selectYourColor3PlayersOption2_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION2_BUTTON).GetComponent<Button>();
        selectYourColor3PlayersOption1_Fields = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION1_FIELDS).GetComponent<CanvasGroup>();
        selectYourColor3PlayersOption2_Fields = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_OPTION2_FIELDS).GetComponent<CanvasGroup>();
        selectYourColor3PlayersBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_BACK_BUTTON).GetComponent<Button>();
        selectYourColor3PlayersPlay_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_PLAY_BUTTON).GetComponent<Button>();
        selectYourColor3Players_canvas = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_3PLAYERS_CANVAS).GetComponent<Canvas>();
        selectYourColor2PlayersOption1Player1_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION1_PLAYER1_NAME).GetComponent<Text>();
        selectYourColor2PlayersOption1Player2_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION1_PLAYER2_NAME).GetComponent<Text>();
        selectYourColor2PlayersOption2Player1_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION2_PLAYER1_NAME).GetComponent<Text>();
        selectYourColor2PlayersOption2Player2_name = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION2_PLAYER2_NAME).GetComponent<Text>();
        selectYourColor2PlayersOption1_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION1_BUTTON).GetComponent<Button>();
        selectYourColor2PlayersOption2_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION2_BUTTON).GetComponent<Button>();
        selectYourColor2PlayersOption1_Fields = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION1_FIELDS).GetComponent<CanvasGroup>();
        selectYourColor2PlayersOption2_Fields = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_OPTION2_FIELDS).GetComponent<CanvasGroup>();
        selectYourColor2PlayersPlay_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_2PLAYERS_PLAY_BUTTON).GetComponent<Button>();
        selectYourColor2PlayersBack_btn = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_2PLAYERS_BACK_BUTTON).GetComponent<Button>();
        selectYourColor2Players_canvas = GameObject.FindGameObjectWithTag(GameConstants.SELECT_YOUR_COLOR_2PLAYERS_CANVAS).GetComponent<Canvas>();
        localMultiplayer_canvas = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_CANVAS).GetComponent<Canvas>();
        localMultiplayer_btn = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_BUTTON).GetComponent<Button>();
        localMultiplayerBack_btn = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_CANVAS_BACK_BUTTON).GetComponent<Button>();
        localMultiplayer2Players_btn = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_CANVAS_2PLAYERS_BUTTON).GetComponent<Button>();
        localMultiplayer3Players_btn = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_CANVAS_3PLAYERS_BUTTON).GetComponent<Button>();
        localMultiplayer4Players_btn = GameObject.FindGameObjectWithTag(GameConstants.LOCAL_MULTIPLAYER_CANVAS_4PLAYERS_BUTTON).GetComponent<Button>();
        onlineMultiplayer_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_ONLINE_MULTIPLAYER_BUTTON).GetComponent<Button>();
        onlineMultiplayer_canvas = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_ONLINE_MULTIPLAYER).GetComponent<Canvas>();
        main_canvas = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_MAIN).GetComponent<CanvasGroup>();
        onlineMultiplayer_canvas_2players_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_ONLINE_MULTIPLAYER_2PLAYERS_BUTTON).GetComponent<Button>();
        onlineMultiplayer_canvas_4players_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_ONLINE_MULTIPLAYER_4PLAYERS_BUTTON).GetComponent<Button>();
        room2Players_canvas = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_2PLAYERS_ROOM).GetComponent<Canvas>();
        room4Players_canvas = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_CANVAS_4PLAYERS_ROOM).GetComponent<Canvas>();
        room2Players_canvas_cost100_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST100_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost500_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST500_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost5000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST5000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost25000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST25000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost50000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST50000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost100000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST100000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost250000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST250000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost500000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST500000_BUTTON).GetComponent<Button>();
        room2Players_canvas_cost750000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_2PLAYERS_ROOM_COST750000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost100_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST100_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost500_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST500_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost5000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST5000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost25000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST25000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost50000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST50000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost100000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST100000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost250000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST250000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost500000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST500000_BUTTON).GetComponent<Button>();
        room4Players_canvas_cost750000_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_4PLAYERS_ROOM_COST750000_BUTTON).GetComponent<Button>();
        searchingForPlayer_canvas = GameObject.FindGameObjectWithTag(GameConstants.SEARCHING_FOR_PLAYER_CANVAS).GetComponent<Canvas>();
        searchingForPlayer_anim = GameObject.FindGameObjectWithTag(GameConstants.SEARCHING_FOR_PLAYER_ANIM);
        notEnoughCoins_canvas = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_NOTENOUGHCOINS_CANVAS).GetComponent<Canvas>();
        playAnotherRoom_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_NOTENOUGHCOINS_CANVAS_PLAYANOTHERROOM_BUTTON).GetComponent<Button>();
        getMoreCoins_btn = GameObject.FindGameObjectWithTag(GameConstants.STARTMENU_NOTENOUGHCOINS_CANVAS_GETMORECOINS_BUTTON).GetComponent<Button>();
        room2PlayersBack_btn = GameObject.FindGameObjectWithTag(GameConstants.ROOM2PLAYERS_BACK_BUTTON).GetComponent<Button>();
        stats_canvas = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS).GetComponent<Canvas>();
        profileBox_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_PROFILE_BOX_BUTTON).GetComponent<Button>();
        statsCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_BACK_BUTTON).GetComponent<Button>();
        displayImage = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_DISPLAY_IMAGE).GetComponent<Image>();
        DisplayName = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_DISPLAY_NAME).GetComponent<Text>();
        CountryName = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_COUNTRY_NAME).GetComponent<Text>();
        NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_COINS).GetComponent<Text>();
        countryImage = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_COUNTRY_IMAGE).GetComponent<Image>();
        statsCanvas_displayName = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_DISPLAY_NAME).GetComponent<Text>();
        statsCanvas_countryName = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_COUNTRY_NAME).GetComponent<Text>();
        statsCanvas_NoOfCoins = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_COINS).GetComponent<Text>();
        statsCanvas_countryImage = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_COUNTRY_IMAGE).GetComponent<Image>();
        statsCanvas_displayImage = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_STATS_CANVAS_DISPLAY_IMAGE).GetComponent<Image>();
        vsComputerWins = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_VSCOMPUTER_WINS).GetComponent<Text>();
        vsComputerLoses = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_VSCOMPUTER_LOSES).GetComponent<Text>();
        vsMultiplayerWins = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_VSMULTIPLAYER_WINS).GetComponent<Text>();
        vsMultiplayerLoses = GameObject.FindGameObjectWithTag(GameConstants.MAINMENU_VSMULTIPLAYER_LOSES).GetComponent<Text>();
        vsComputerWinsSAL = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_SAL_VSCOMPUTER_WIN).GetComponent<Text>();
        vsComputerLosesSAL = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_SAL_VSCOMPUTER_Lose).GetComponent<Text>();
        vsMultiplayerWinsSAL = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_SAL_VSMULTIPLAYER_WIN).GetComponent<Text>();
        vsMultiplayerLosesSAL = GameObject.FindGameObjectWithTag(GameConstants.MAIN_MENU_SAL_VSMULTIPLAYER_Lose).GetComponent<Text>();
        onlineMultiplayerCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.ONLINEMULTIPLAYER_CANVAS_BACK_BUTTON).GetComponent<Button>();

        searchingForPlayer_anim.SetActive(false);


        LoadPlayerData();
        Set_Wins_Loses();

        CheckIfPlayAsGuestOrNot();
    }

    private void Start()
    {
        //loopHole_btn.onClick.AddListener(LoopHoleBtn);
        doesntWantToPlay_btn.onClick.AddListener(DoesntWantToPlayBtn);
        challengeYes_btn.onClick.AddListener(ChallengeYesBtn);
        challangeNo_btn.onClick.AddListener(ChallengeNoBtn);
        room4PlayersBack_btn.onClick.AddListener(Room4PlayersBackBtn);
        messageBox_btn.onClick.AddListener(MessageBoxBtn);
        mainMenuBack_btn.onClick.AddListener(MainMenuBackBtn);
        playWithComputer_btn1.onClick.AddListener(PlayWithComputerBtn1);
        playWithComputer_btn2.onClick.AddListener(PlayWithComputerBtn2);
        playWithComputer_btn3.onClick.AddListener(PlayWithComputerBtn3);
        playWithComputer_btn4.onClick.AddListener(PlayWithComputerBtn4);
        playWithComputerBack_btn.onClick.AddListener(PlayWithComputerBackBtn);
        playWithComputerPlay_btn.onClick.AddListener(PlayWithComputerPlayBtn);
        playWithComputer_btn.onClick.AddListener(PlayWithComputerBtn);
        selectYourColor4PlayersBack_btn.onClick.AddListener(SelectYourColor4PlayersBackBtn);
        selectYourColor4PlayersPlay_btn.onClick.AddListener(SelectYourColor4PlayersPlayBtn);
        selectYourColor3PlayersOption1_btn.onClick.AddListener(SelectYourColor3PlayersOption1Btn);
        selectYourColor3PlayersOption2_btn.onClick.AddListener(SelectYourColor3PlayersOption2Btn);
        selectYourColor3PlayersBack_btn.onClick.AddListener(SelectYouColor3PlayersBackBtn);
        selectYourColor3PlayersPlay_btn.onClick.AddListener(SelectYouColor3PlayersPlayBtn);
        selectYourColor2PlayersPlay_btn.onClick.AddListener(SelectYourColor2PlayersPlayButton);
        selectYourColor2PlayersOption1_btn.onClick.AddListener(SelectYourColor2PlayersOption1Btn);
        selectYourColor2PlayersOption2_btn.onClick.AddListener(SelectYourColor2PlayersOption2Btn);
        selectYourColor2PlayersBack_btn.onClick.AddListener(SelectYourColor2PlayersBackBtn);
        onlineMultiplayer_btn.onClick.AddListener(OnlineMultiplayerBtn);
        onlineMultiplayer_canvas_2players_btn.onClick.AddListener(OnlineMultiplayer2PlayersBtn);
        onlineMultiplayer_canvas_4players_btn.onClick.AddListener(OnlineMultiplayer4PlayersBtn);
        profileBox_btn.onClick.AddListener(ProfileBoxBtn);
        statsCanvasBack_btn.onClick.AddListener(StatsBackBtn);
        onlineMultiplayerCanvasBack_btn.onClick.AddListener(OnlineMultiplayerBackBtn);
        localMultiplayer_btn.onClick.AddListener(LocalMultiplayerBtn);
        localMultiplayerBack_btn.onClick.AddListener(LocalMultiplayerBackBtn);
        localMultiplayer2Players_btn.onClick.AddListener(LocalMultiplayer2PlayersBtn);
        localMultiplayer3Players_btn.onClick.AddListener(LocalMultiplayer3PlayersBtn);
        localMultiplayer4Players_btn.onClick.AddListener(LocalMultiplayer4PlayersBtn);
        playAnotherRoom_btn.onClick.AddListener(PlayAnotherRoomBtn);
        room2PlayersBack_btn.onClick.AddListener(Room2PlayersBackBtn);
        playWithFriends_btn.onClick.AddListener(PlayWithFriendsBtn);
        friendListCanvasBack_btn.onClick.AddListener(FriendListBackBtn);

        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            room2Players_canvas_cost100_btn.onClick.AddListener(delegate { Room2Players(100, GameConstants.TWO_PLAYERS_MATCH_100); });
            room2Players_canvas_cost500_btn.onClick.AddListener(delegate { Room2Players(500, GameConstants.TWO_PLAYERS_MATCH_500); });
            room2Players_canvas_cost5000_btn.onClick.AddListener(delegate { Room2Players(5000, GameConstants.TWO_PLAYERS_MATCH_5000); });
            room2Players_canvas_cost25000_btn.onClick.AddListener(delegate { Room2Players(25000, GameConstants.TWO_PLAYERS_MATCH_25000); });
            room2Players_canvas_cost50000_btn.onClick.AddListener(delegate { Room2Players(50000, GameConstants.TWO_PLAYERS_MATCH_50000); });
            room2Players_canvas_cost100000_btn.onClick.AddListener(delegate { Room2Players(100000, GameConstants.TWO_PLAYERS_MATCH_100000); });
            room2Players_canvas_cost250000_btn.onClick.AddListener(delegate { Room2Players(250000, GameConstants.TWO_PLAYERS_MATCH_250000); });
            room2Players_canvas_cost500000_btn.onClick.AddListener(delegate { Room2Players(500000, GameConstants.TWO_PLAYERS_MATCH_500000); });
            room2Players_canvas_cost750000_btn.onClick.AddListener(delegate { Room2Players(750000, GameConstants.TWO_PLAYERS_MATCH_750000); });
        }
        else if (Register.Game == GameConstants.SNAKES_AND_LADDER)
        {
            room2Players_canvas_cost100_btn.onClick.AddListener(delegate { Room2Players(100, GameConstants.SAL_TWO_PLAYERS_MATCH_100); });
            room2Players_canvas_cost500_btn.onClick.AddListener(delegate { Room2Players(500, GameConstants.SAL_TWO_PLAYERS_MATCH_500); });
            room2Players_canvas_cost5000_btn.onClick.AddListener(delegate { Room2Players(5000, GameConstants.SAL_TWO_PLAYERS_MATCH_5000); });
            room2Players_canvas_cost25000_btn.onClick.AddListener(delegate { Room2Players(25000, GameConstants.SAL_TWO_PLAYERS_MATCH_25000); });
            room2Players_canvas_cost50000_btn.onClick.AddListener(delegate { Room2Players(50000, GameConstants.SAL_TWO_PLAYERS_MATCH_50000); });
            room2Players_canvas_cost100000_btn.onClick.AddListener(delegate { Room2Players(100000, GameConstants.SAL_TWO_PLAYERS_MATCH_100000); });
            room2Players_canvas_cost250000_btn.onClick.AddListener(delegate { Room2Players(250000, GameConstants.SAL_TWO_PLAYERS_MATCH_250000); });
            room2Players_canvas_cost500000_btn.onClick.AddListener(delegate { Room2Players(500000, GameConstants.SAL_TWO_PLAYERS_MATCH_500000); });
            room2Players_canvas_cost750000_btn.onClick.AddListener(delegate { Room2Players(750000, GameConstants.SAL_TWO_PLAYERS_MATCH_750000); });
        }

        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            room4Players_canvas_cost100_btn.onClick.AddListener(delegate { Room4Players(100, GameConstants.FOUR_PLAYERS_MATCH_100); });
            room4Players_canvas_cost500_btn.onClick.AddListener(delegate { Room4Players(500, GameConstants.FOUR_PLAYERS_MATCH_500); });
            room4Players_canvas_cost5000_btn.onClick.AddListener(delegate { Room4Players(5000, GameConstants.FOUR_PLAYERS_MATCH_5000); });
            room4Players_canvas_cost25000_btn.onClick.AddListener(delegate { Room4Players(25000, GameConstants.FOUR_PLAYERS_MATCH_25000); });
            room4Players_canvas_cost50000_btn.onClick.AddListener(delegate { Room4Players(50000, GameConstants.FOUR_PLAYERS_MATCH_50000); });
            room4Players_canvas_cost100000_btn.onClick.AddListener(delegate { Room4Players(100000, GameConstants.FOUR_PLAYERS_MATCH_100000); });
            room4Players_canvas_cost250000_btn.onClick.AddListener(delegate { Room4Players(250000, GameConstants.FOUR_PLAYERS_MATCH_250000); });
            room4Players_canvas_cost500000_btn.onClick.AddListener(delegate { Room4Players(500000, GameConstants.FOUR_PLAYERS_MATCH_500000); });
            room4Players_canvas_cost750000_btn.onClick.AddListener(delegate { Room4Players(750000, GameConstants.FOUR_PLAYERS_MATCH_750000); });
        }

        else if (Register.Game == GameConstants.SNAKES_AND_LADDER)
        {
            room4Players_canvas_cost100_btn.onClick.AddListener(delegate { Room4Players(100, GameConstants.SAL_FOUR_PLAYERS_MATCH_100); });
            room4Players_canvas_cost500_btn.onClick.AddListener(delegate { Room4Players(500, GameConstants.SAL_FOUR_PLAYERS_MATCH_500); });
            room4Players_canvas_cost5000_btn.onClick.AddListener(delegate { Room4Players(5000, GameConstants.SAL_FOUR_PLAYERS_MATCH_5000); });
            room4Players_canvas_cost25000_btn.onClick.AddListener(delegate { Room4Players(25000, GameConstants.SAL_FOUR_PLAYERS_MATCH_25000); });
            room4Players_canvas_cost50000_btn.onClick.AddListener(delegate { Room4Players(50000, GameConstants.SAL_FOUR_PLAYERS_MATCH_50000); });
            room4Players_canvas_cost100000_btn.onClick.AddListener(delegate { Room4Players(100000, GameConstants.SAL_FOUR_PLAYERS_MATCH_100000); });
            room4Players_canvas_cost250000_btn.onClick.AddListener(delegate { Room4Players(250000, GameConstants.SAL_FOUR_PLAYERS_MATCH_250000); });
            room4Players_canvas_cost500000_btn.onClick.AddListener(delegate { Room4Players(500000, GameConstants.SAL_FOUR_PLAYERS_MATCH_500000); });
            room4Players_canvas_cost750000_btn.onClick.AddListener(delegate { Room4Players(750000, GameConstants.SAL_FOUR_PLAYERS_MATCH_750000); });
        }


        disableMessageBox = false;
        isSearchingForPlayer = false;
        loopHoleCount = 0;

        //audioSource.clip = buttonSound;
        //notificationSource.clip = notificationSound;
        FacebookLoggedInMethod();

  

    }

    private void Update()
    {
        if (disableMessageBox)
        {
            disableMessageBox = false;
            StartCoroutine(DisableMessageBox());
        }

        if (isSearchingForPlayer)
        {
            timeLeftToSearchPlayer -= Time.deltaTime;
            searchingForPlayerTimeRemaining_text.text = "" + (int)timeLeftToSearchPlayer;
        }
        OnBackPress();
    
    }

    public void DoesntWantToPlayBtn()
    {
        main_canvas.interactable = true;
        doesntWantToPlay_canvas.enabled = false;
    }

    private void ChallengeNoBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
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

    private void ChallengeYesBtn()
    {
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
        new MatchmakingRequest().SetSkill(100).SetMatchShortCode(match_key).SetCustomQuery(customQuery).Send((response2) =>
        {
            if (!response2.HasErrors)
            {

                string game = "";
                if (FacebookFriendList.Challenge_Game_Name == GameConstants.LUDO_CHALLENGE)
                {
                    game = GameConstants.LUDO_CHALLENGE;
                }
                else
                {
                    game = GameConstants.SNAKES_AND_LADDER;
                }
                GameInitializer.SetGame(game, GameConstants.ONLINE_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
            }
            else
            {
                ShowToast.MyShowToastMethod("Error Accepting Request");
                main_canvas.interactable = true;
                challenge_canvas.enabled = false;
            }
        });
    }

    private void FriendListBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
        friendList_canvas.enabled = false;
        GameObject game_manager = GameObject.Find("content");
        foreach (Transform child in game_manager.transform)
        {
            Destroy(child.gameObject);
        }
        friendName.Clear();
        friendProfileId.Clear();
        onlineStatus.Clear();
        player_id.Clear();
        FacebookFriendList.friendCount = 0;
        FacebookFriendList.list_count = 1;

    }

    private void PlayWithFriendsBtn(){
        if(StartMenu.playAsGuest){
            ShowToast.MyShowToastMethod("Login with FB to play with your freinds");
        }
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        new ListGameFriendsRequest()
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("No Error");
                    GSEnumerable<ListGameFriendsResponse._Player> friends = response.Friends;
                    //GSData scriptData = response.ScriptData;
                    foreach (ListGameFriendsResponse._Player i in friends)
                    {

                        friendName.Add(i.DisplayName);
                        friendProfileId.Add(i.ExternalIds.GetString("FB"));
                        onlineStatus.Add((bool)i.Online);
                        player_id.Add(i.Id);

                    }
                    GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                    game_manager.GetComponent<FacebookFriendList>().GenerateItems(friendName.Count, friendName[0], friendProfileId[0], onlineStatus[0], player_id[0]);
                    friendList_canvas.enabled = true;
                }
                else
                {
                    friendList_canvas.enabled = false;
                    Debug.Log("Couldnt Load Friend List!");
                    ShowToast.MyShowToastMethod("Couldn't Load Friend List!");
                }
            });
    }


    private void LoopHoleBtn()
    {
        loopHoleCount++;
        if (loopHoleCount >= 12)
        {
            GameObject loopHole = GameObject.FindGameObjectWithTag(GameConstants.LOOP_HOLE);
            var color = loopHole.GetComponent<Image>().color;
            color.a = 1;
            loopHole.GetComponent<Image>().color = color;
        }
    }

    private void Room4PlayersBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
        room4Players_canvas.enabled = false;
    }

    private void MessageBoxBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
        messageBox_canvas.enabled = false;
    }

    private void MainMenuBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            //change scene
            SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
        }
        else
        {
            SceneManager.LoadScene(GameConstants.START_MENU_SAL_SCENE);
        }
    }

    private void PlayWithComputerBtn1()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.RED;
    }

    private void PlayWithComputerBtn2()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.BLUE;
    }

    private void PlayWithComputerBtn3()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.GREEN;
    }

    private void PlayWithComputerBtn4()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_color = GameConstants.YELLOW;
    }


    private void PlayWithComputerBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }
    private void PlayWithComputerPlayBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        string game = "";
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            game = GameConstants.LUDO_CHALLENGE;
        }
        else
        {
            game = GameConstants.SNAKES_AND_LADDER;
        }
        GameController.playerTurn = 0;

        player1Name = "You";
        player2Name = "Computer 1";
        player3Name = "Computer 2";
        player4Name = "Computer 3";
        if(playWithComputer_players == 2){
            player3Name = "Computer";
        }


        //Start Game
        GameInitializer.SetGame(game, GameConstants.PLAY_WITH_COMPUTER, playWithComputer_color, playWithComputer_players);
        SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);

    }

    private void SelectYourColor4PlayersBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor4Players_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }


    private void SelectYourColor4PlayersPlayBtn()
    {
        GameController.playerTurn = 0;
        player1Name = "Player 1";
        player2Name = "Player 2";
        player3Name = "Player 3";
        player4Name = "Player 4";
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        string game = "";
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            game = GameConstants.LUDO_CHALLENGE;
        }
        else
        {
            game = GameConstants.SNAKES_AND_LADDER;
        }
        if (selectYourColor4PlayersPlayer1_name.text != "")
        {
            player1Name = selectYourColor4PlayersPlayer1_name.text;
        }
        if (selectYourColor4PlayersPlayer2_name.text != "")
        {
            player2Name = selectYourColor4PlayersPlayer2_name.text;
        }
        if (selectYourColor4PlayersPlayer3_name.text != "")
        {
            player3Name = selectYourColor4PlayersPlayer3_name.text;
        }
        if (selectYourColor4PlayersPlayer4_name.text != "")
        {
            player4Name = selectYourColor4PlayersPlayer4_name.text;
        }

        //Start Game
        GameInitializer.SetGame(game, GameConstants.LOCAL_MULTIPLAYER, GameConstants.RED, GameConstants.FOUR_PLAYERS);
        SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
    }

    private void SelectYourColor3PlayersOption1Btn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor3PlayersOption1_Fields.interactable = true;
        selectYourColor3PlayersOption2_Fields.interactable = false;
    }

    private void SelectYourColor3PlayersOption2Btn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor3PlayersOption1_Fields.interactable = false;
        selectYourColor3PlayersOption2_Fields.interactable = true;
    }


    private void SelectYouColor3PlayersBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        localMultiplayer_canvas.enabled = true;
        selectYourColor3Players_canvas.enabled = false;
    }

    private void SelectYouColor3PlayersPlayBtn()
    {
        GameController.playerTurn = 0;
        player1Name = "Player 1";
        player2Name = "Player 2";
        player3Name = "Player 3";
        player4Name = "Player 4";
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        int noOfPlayers = GameConstants.THREE_PLAYERS;
        string game = "";
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            game = GameConstants.LUDO_CHALLENGE;
        }
        else
        {
            game = GameConstants.SNAKES_AND_LADDER;
        }
        string gameType = GameConstants.LOCAL_MULTIPLAYER;


        if (selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor3PlayersOption1Player1_name.text != "")
            {
                player1Name = selectYourColor3PlayersOption1Player1_name.text;
            }
            if (selectYourColor3PlayersOption1Player2_name.text != "")
            {
                player2Name = selectYourColor3PlayersOption1Player2_name.text;
            }
            if (selectYourColor3PlayersOption1Player3_name.text != "")
            {
                player3Name = selectYourColor3PlayersOption1Player3_name.text;
            }
            //Start Game
            GameInitializer.SetGame(game, GameConstants.LOCAL_MULTIPLAYER, GameConstants.RED, GameConstants.THREE_PLAYERS);
            SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
        }
        else if (selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor3PlayersOption2Player1_name.text != "")
            {
                player1Name = selectYourColor3PlayersOption2Player1_name.text;
            }
            if (selectYourColor3PlayersOption2Player2_name.text != "")
            {
                player2Name = selectYourColor3PlayersOption2Player2_name.text;
            }
            if (selectYourColor3PlayersOption2Player3_name.text != "")
            {
                player3Name = selectYourColor3PlayersOption2Player3_name.text;
            }

            string color = GameConstants.BLUE;
            //Start Game
            GameInitializer.SetGame(game, GameConstants.LOCAL_MULTIPLAYER, GameConstants.BLUE, GameConstants.THREE_PLAYERS);
            SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
        }


    }

    private void SelectYourColor2PlayersPlayButton()
    {
        GameController.playerTurn = 0;
        player1Name = "Player 1";
        player3Name = "Player 2";
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        int noOfPlayers = GameConstants.TWO_PLAYERS;
        string game = "";
        if (Register.Game == GameConstants.LUDO_CHALLENGE)
        {
            game = GameConstants.LUDO_CHALLENGE;
        }
        else
        {
            game = GameConstants.SNAKES_AND_LADDER;
        }
        string gameType = GameConstants.LOCAL_MULTIPLAYER;


        if (selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor2PlayersOption1Player1_name.text != "")
            {
                player1Name = selectYourColor2PlayersOption1Player1_name.text;
            }
            if (selectYourColor2PlayersOption1Player2_name.text != "")
            {
                if (Register.Game == GameConstants.LUDO_CHALLENGE)
                {
                    player3Name = selectYourColor2PlayersOption1Player2_name.text;
                }
                else
                {
                    player2Name = selectYourColor2PlayersOption1Player2_name.text;
                }
            }

            //Start Game
            GameInitializer.SetGame(game, GameConstants.LOCAL_MULTIPLAYER, GameConstants.RED, GameConstants.TWO_PLAYERS);
            SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);

        }
        else if (selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor2PlayersOption2Player1_name.text != "")
            {
                player1Name = selectYourColor2PlayersOption2Player1_name.text;
            }
            if (selectYourColor2PlayersOption2Player2_name.text != "")
            {
                if (Register.Game == GameConstants.LUDO_CHALLENGE)
                {
                    player3Name = selectYourColor2PlayersOption1Player2_name.text;
                }
                else
                {
                    player2Name = selectYourColor2PlayersOption1Player2_name.text;
                }
            }
            //Start Game
            GameInitializer.SetGame(game, GameConstants.LOCAL_MULTIPLAYER, GameConstants.BLUE, GameConstants.TWO_PLAYERS);
            SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
        }

    }

    private void SelectYourColor2PlayersOption1Btn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor2PlayersOption1_Fields.interactable = true;
        selectYourColor2PlayersOption2_Fields.interactable = false;
    }

    private void SelectYourColor2PlayersOption2Btn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor2PlayersOption1_Fields.interactable = false;
        selectYourColor2PlayersOption2_Fields.interactable = true;
    }



    private void LocalMultiplayerBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        checkClick = 0;
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void PlayWithComputerBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        checkClick = 1;
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void LocalMultiplayerBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        localMultiplayer_canvas.enabled = false;
    }

    private void LocalMultiplayer2PlayersBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_players = 2;
        playWithComputer_color = GameConstants.RED;
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor2Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_canvas.enabled = true;

        }
    }

    private void LocalMultiplayer3PlayersBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_players = 3;
        playWithComputer_color = GameConstants.RED;
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor3Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_canvas.enabled = true;
        }
    }

    private void LocalMultiplayer4PlayersBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        playWithComputer_players = 4;
        playWithComputer_color = GameConstants.RED;
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor4Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_canvas.enabled = true;
        }

    }


    private void SelectYourColor2PlayersBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        selectYourColor2Players_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void OnlineMultiplayerBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
        onlineMultiplayer_canvas.enabled = false;
    }

    private void StatsBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = true;
        stats_canvas.enabled = false;
    }

    private void ProfileBoxBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        main_canvas.interactable = false;
        stats_canvas.enabled = true;
    }

    private void OnlineMultiplayerBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (!StartMenu.playAsGuest)
        {
            main_canvas.interactable = false;
            onlineMultiplayer_canvas.enabled = true;
        }
        else
        {
            ShowToast.MyShowToastMethod("Login first to play Online!");
        }
    }

    private void OnlineMultiplayer2PlayersBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        onlineMultiplayer_canvas.enabled = false;
        room2Players_canvas.enabled = true;
    }

    private void OnlineMultiplayer4PlayersBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        if (LoginWithFB.FacebookLoggedIn)
        {
			ShowToast.MyShowToastMethod("You can't play with 4 players in FB mode!");
        }
        onlineMultiplayer_canvas.enabled = false;
        room4Players_canvas.enabled = true;
    }
    private void Room2PlayersBackBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        room2Players_canvas.enabled = false;
        main_canvas.interactable = true;
    }


    private void Room2Players(int cost, string match_key)
    {
        timeLeftToSearchPlayer = 60.0f;
        roomForPlayers = 2;
        matchCost = cost;
        MakeMatch(cost, match_key);

    }

    private void Room4Players(int cost, string match_key)
    {
        timeLeftToSearchPlayer = 150.0f;
        roomForPlayers = 4;
        matchCost = cost;
        MakeMatch(cost, match_key);

    }


    private void PlayAnotherRoomBtn()
    {
        if (Register.isSoundPlaying)
        {
            audioSource.Play();
        }
        notEnoughCoins_canvas.enabled = false;
        if (roomForPlayers == 2)
        {
            room2Players_canvas.enabled = true;
        }
        else if (roomForPlayers == 4)
        {
            room4Players_canvas.enabled = true;
        }
    }

    private void MakeMatch(int costOfMatch, string match)
    {
        int coins = Database.GetPlayerCoins(Register.userId);
        if (coins >= costOfMatch)
        {
            MakeAMatch.MakeMatch(costOfMatch, match);
            room2Players_canvas.enabled = false;
            room4Players_canvas.enabled = false;
            searchingForPlayer_canvas.enabled = true;
            searchingForPlayer_anim.SetActive(true);
            searchingForPlayerTimeRemaining_text.enabled = true;
            isSearchingForPlayer = true;
        }
        else
        {
            room2Players_canvas.enabled = false;
            room4Players_canvas.enabled = false;
            notEnoughCoins_canvas.enabled = true;
        }

    }

    private void Set_Wins_Loses()
    {
        Debug.Log("Set Win Loses Method");
        vsComputerWins.text = "" + Database.getVsComputerWins(Register.userId);
        vsComputerLoses.text = "" + Database.getVsComputerLoses(Register.userId);
        vsMultiplayerWins.text = "" + Database.getVsMultiplayerWins(Register.userId);
        vsMultiplayerLoses.text = "" + Database.getVsMultiplayerLoses(Register.userId);
        vsComputerWinsSAL.text = "" + Database.getVsComputerWinsSAL(Register.userId);
        vsComputerLosesSAL.text = "" + Database.getVsComputerLosesSAL(Register.userId);
        vsMultiplayerWinsSAL.text = "" + Database.getVsMultiplayerWinsSAL(Register.userId);
        vsMultiplayerLosesSAL.text = "" + Database.getVsMultiplayerLosesSAL(Register.userId);
    }

    IEnumerator DisableMessageBox()
    {
        yield return new WaitForSeconds(5f);
        main_canvas.interactable = true;
        messageBox_canvas.enabled = false;
    }

    private void LoadPlayerData()
    {

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
            displayImage.sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
            statsCanvas_displayImage.sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
        }

    }


    public void CheckIfPlayAsGuestOrNot()
    {
        if (StartMenu.playAsGuest)
        {
            DisplayName.enabled = false;
            CountryName.enabled = false;
            NoOfCoins.enabled = false;
            countryImage.enabled = false;
            coinsImage.enabled = false;
            statsCanvas_displayName.enabled = false;
            statsCanvas_countryName.enabled = false;
            statsCanvas_NoOfCoins.enabled = false;
            statsCanvas_countryImage.enabled = false;
            statsCoinImage.enabled = false;
            guestText.enabled = true;
            profileBox_btn.enabled = false;
            if (Register.RegisterScreen)
            {
                guestText.text = Register.GuestName;
                displayImage.sprite = Register.guestImage.sprite;
                statsCanvas_displayImage.sprite = Register.guestImage.sprite;
            }
            else
            {
                guestText.text = Login.GuestName;
                displayImage.sprite = Login.guestImage.sprite;
                statsCanvas_displayImage.sprite = Login.guestImage.sprite;
            }
        }
        else
        {
            DisplayName.enabled = true;
            CountryName.enabled = true;
            NoOfCoins.enabled = true;
            countryImage.enabled = true;
            coinsImage.enabled = true;
            statsCanvas_displayName.enabled = true;
            statsCanvas_countryName.enabled = true;
            statsCanvas_NoOfCoins.enabled = true;
            statsCanvas_countryImage.enabled = true;
            statsCoinImage.enabled = true;
            guestText.enabled = false;
        }
    }


    private void FacebookLoggedInMethod()
    {
        if (LoginWithFB.FacebookLoggedIn)
        {
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
        }
    }

    public void OnBackPress()
    {
        //Change Scene
        if (Input.GetKeyDown(KeyCode.Escape) && !searchingForPlayerTimeRemaining_text.enabled)
        {
            if (Register.Game == GameConstants.LUDO_CHALLENGE)
            {
                SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
            }
            else
            {
                SceneManager.LoadScene(GameConstants.START_MENU_SAL_SCENE);
            }
        }
    }


    void OnApplicationPause(bool pauseState)
    {
        if (pauseState)
        {
            string current_date = System.DateTime.Now.Date.ToString();
            Database.SetDailyBonusDate(Register.userId, current_date);
        }
    }

    public  IEnumerator StopWaitingForResponse(float timer){
        yield return new WaitForSeconds(timer);
        friendList_canvas.GetComponent<CanvasGroup>().interactable = true;
        FriendListBackBtn();
        friendList_canvas.enabled = false;
        challengeResponse_canvas.enabled = false;
        doesntWantToPlay_text.text = "No Response!";
        doesntWantToPlay_canvas.enabled = true;
    }


}
