using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
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
    playWithComputer_btn1, playWithComputer_btn2, playWithComputer_btn3, playWithComputer_btn4, mainMenuBack_btn;

    public static Button messageBox_btn;

    public static CanvasGroup main_canvas, selectYourColor2PlayersOption1_Fields, selectYourColor2PlayersOption2_Fields,
    selectYourColor3PlayersOption1_Fields, selectYourColor3PlayersOption2_Fields;

    private Canvas localMultiplayer_canvas, selectYourColor2Players_canvas, selectYourColor3Players_canvas, selectYourColor4Players_canvas, playWithComputer_canvas,
    onlineMultiplayer_canvas, room2Players_canvas, room4Players_canvas, stats_canvas, notEnoughCoins_canvas;
    public static Canvas searchingForPlayer_canvas, messageBox_canvas;

    private Image displayImage, countryImage, statsCanvas_displayImage, statsCanvas_countryImage;

    private Text DisplayName, CountryName, NoOfCoins, statsCanvas_displayName, statsCanvas_countryName, statsCanvas_NoOfCoins, selectYourColor2PlayersOption1Player1_name,
    selectYourColor2PlayersOption1Player2_name, selectYourColor2PlayersOption2Player1_name, selectYourColor2PlayersOption2Player2_name, 
    selectYourColor3PlayersOption1Player1_name, selectYourColor3PlayersOption1Player2_name, selectYourColor3PlayersOption1Player3_name, 
    selectYourColor3PlayersOption2Player1_name, selectYourColor3PlayersOption2Player2_name, selectYourColor3PlayersOption2Player3_name,
    selectYourColor4PlayersPlayer1_name, selectYourColor4PlayersPlayer2_name, selectYourColor4PlayersPlayer3_name, selectYourColor4PlayersPlayer4_name,
    vsComputerWins, vsComputerLoses, vsMultiplayerWins, vsMultiplayerLoses;

    public static Text messageBox_text;

    private int checkClick, playWithComputer_players;
    public static GameObject searchingForPlayer_anim;
    private string playWithComputer_color;
    public static int matchCost;
    public static int roomForPlayers;
    public static string displayImage_string = null;
    public static bool disableMessageBox;

    private void Awake()
    {
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
        onlineMultiplayerCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.ONLINEMULTIPLAYER_CANVAS_BACK_BUTTON).GetComponent<Button>();

        searchingForPlayer_anim.SetActive(false);


        LoadPlayerData();
        Set_Wins_Loses();
    }

    private void Start()
    {
        room4Players_canvas_cost100_btn.onClick.AddListener(delegate { Room4Players(100, GameConstants.FOUR_PLAYERS_MATCH_100); });

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
        room2Players_canvas_cost100_btn.onClick.AddListener(delegate { Room2Players(100, GameConstants.TWO_PLAYERS_MATCH_100); });
        room2Players_canvas_cost500_btn.onClick.AddListener(delegate { Room2Players(500, GameConstants.TWO_PLAYERS_MATCH_500); });
        room2Players_canvas_cost5000_btn.onClick.AddListener(delegate { Room2Players(5000, GameConstants.TWO_PLAYERS_MATCH_5000); });
        room2Players_canvas_cost25000_btn.onClick.AddListener(delegate { Room2Players(25000, GameConstants.TWO_PLAYERS_MATCH_25000); });
        room2Players_canvas_cost50000_btn.onClick.AddListener(delegate { Room2Players(50000, GameConstants.TWO_PLAYERS_MATCH_50000); });
        room2Players_canvas_cost100000_btn.onClick.AddListener(delegate { Room2Players(100000, GameConstants.TWO_PLAYERS_MATCH_100000); });
        room2Players_canvas_cost250000_btn.onClick.AddListener(delegate { Room2Players(250000, GameConstants.TWO_PLAYERS_MATCH_250000); });
        room2Players_canvas_cost500000_btn.onClick.AddListener(delegate { Room2Players(500000, GameConstants.TWO_PLAYERS_MATCH_500000); });
        room2Players_canvas_cost750000_btn.onClick.AddListener(delegate { Room2Players(750000, GameConstants.TWO_PLAYERS_MATCH_750000); });


        playAnotherRoom_btn.onClick.AddListener(PlayAnotherRoomBtn);
        room2PlayersBack_btn.onClick.AddListener(Room2PlayersBackBtn);

        disableMessageBox = false;
    }

    private void Update()
    {
        if(disableMessageBox){
            disableMessageBox = false;
            StartCoroutine(DisableMessageBox());
        }
    }

    private void MessageBoxBtn()
    {
        main_canvas.interactable = true;
        messageBox_canvas.enabled = false;
    }

    private void MainMenuBackBtn(){
        //change scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    }

    private void PlayWithComputerBtn1()
    {
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.RED;
    }

    private void PlayWithComputerBtn2()
    {
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.BLUE;
    }

    private void PlayWithComputerBtn3()
    {
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_color = GameConstants.GREEN;
    }

    private void PlayWithComputerBtn4()
    {
        playWithComputer_btn1.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn2.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn3.GetComponent<Image>().sprite = checkBox_sprite[1];
        playWithComputer_btn4.GetComponent<Image>().sprite = checkBox_sprite[0];
        playWithComputer_color = GameConstants.YELLOW;
    }


    private void PlayWithComputerBackBtn()
    {
        playWithComputer_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }
    private void PlayWithComputerPlayBtn()
    {
        int noOfPlayers = playWithComputer_players;
        string game = GameConstants.LUDO_CHALLENGE;
        string gameType = GameConstants.PLAY_WITH_COMPUTER;
        string color = playWithComputer_color;

        string player1Name = "You";
        string player2Name = "Computer";
        string player3Name = "Computer";
        string player4Name = "Computer";


    }

    private void SelectYourColor4PlayersBackBtn()
    {
        selectYourColor4Players_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }


    private void SelectYourColor4PlayersPlayBtn()
    {
        int noOfPlayers = GameConstants.FOUR_PLAYERS;
        string game = GameConstants.LUDO_CHALLENGE;
        string gameType = GameConstants.LOCAL_MULTIPLAYER;
        string color = GameConstants.RED;

        string player1Name = "Player 1";
        string player2Name = "Player 2";
        string player3Name = "Player 3";
        string player4Name = "Player 4";
        if (selectYourColor4PlayersPlayer1_name.text != null)
        {
            player1Name = selectYourColor4PlayersPlayer1_name.text;
        }
        if (selectYourColor4PlayersPlayer2_name.text != null)
        {
            player2Name = selectYourColor4PlayersPlayer2_name.text;
        }
        if (selectYourColor4PlayersPlayer3_name.text != null)
        {
            player3Name = selectYourColor4PlayersPlayer3_name.text;
        }
        if (selectYourColor4PlayersPlayer4_name.text != null)
        {
            player4Name = selectYourColor4PlayersPlayer4_name.text;
        }
    }

    private void SelectYourColor3PlayersOption1Btn()
    {
        selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor3PlayersOption1_Fields.interactable = true;
        selectYourColor3PlayersOption2_Fields.interactable = false;
    }

    private void SelectYourColor3PlayersOption2Btn()
    {
        selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor3PlayersOption1_Fields.interactable = false;
        selectYourColor3PlayersOption2_Fields.interactable = true;
    }


    private void SelectYouColor3PlayersBackBtn()
    {
        localMultiplayer_canvas.enabled = true;
        selectYourColor3Players_canvas.enabled = false;
    }

    private void SelectYouColor3PlayersPlayBtn()
    {
        int noOfPlayers = GameConstants.THREE_PLAYERS;
        string game = GameConstants.LUDO_CHALLENGE;
        string gameType = GameConstants.LOCAL_MULTIPLAYER;

        string player1Name = "Player 1";
        string player2Name = "Player 2";
        string player3Name = "Player 3";


        if (selectYourColor3PlayersOption1_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor3PlayersOption1Player1_name.text != null)
            {
                player1Name = selectYourColor3PlayersOption1Player1_name.text;
            }
            if (selectYourColor3PlayersOption1Player2_name.text != null)
            {
                player2Name = selectYourColor3PlayersOption1Player2_name.text;
            }
            if (selectYourColor3PlayersOption1Player3_name.text != null)
            {
                player3Name = selectYourColor3PlayersOption1Player3_name.text;
            }
            string color = GameConstants.RED;
        }
        else if (selectYourColor3PlayersOption2_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor3PlayersOption2Player1_name.text != null)
            {
                player1Name = selectYourColor3PlayersOption2Player1_name.text;
            }
            if (selectYourColor3PlayersOption2Player2_name.text != null)
            {
                player2Name = selectYourColor3PlayersOption2Player2_name.text;
            }
            if (selectYourColor3PlayersOption2Player3_name.text != null)
            {
                player3Name = selectYourColor3PlayersOption2Player3_name.text;
            }

            string color = GameConstants.BLUE;
        }
    }

    private void SelectYourColor2PlayersPlayButton()
    {
        int noOfPlayers = GameConstants.TWO_PLAYERS;
        string game = GameConstants.LUDO_CHALLENGE;
        string gameType = GameConstants.LOCAL_MULTIPLAYER;

        string player1Name = "Player 1";
        string player2Name = "Player 2";

        if (selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor2PlayersOption1Player1_name.text != null)
            {
                player1Name = selectYourColor2PlayersOption1Player1_name.text;
            }
            if (selectYourColor2PlayersOption1Player2_name.text != null)
            {
                player2Name = selectYourColor2PlayersOption1Player2_name.text;
            }
            string color = GameConstants.RED;

        }
        else if (selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite == checkBox_sprite[0])
        {

            if (selectYourColor2PlayersOption2Player1_name.text != null)
            {
                player1Name = selectYourColor2PlayersOption2Player1_name.text;
            }
            if (selectYourColor2PlayersOption2Player2_name.text != null)
            {
                player2Name = selectYourColor2PlayersOption2Player2_name.text;
            }


            string color = GameConstants.BLUE;
        }

    }

    private void SelectYourColor2PlayersOption1Btn(){
        selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor2PlayersOption1_Fields.interactable = true;
        selectYourColor2PlayersOption2_Fields.interactable = false;
    }

    private void SelectYourColor2PlayersOption2Btn()
    {
        selectYourColor2PlayersOption1_btn.GetComponent<Image>().sprite = checkBox_sprite[1];
        selectYourColor2PlayersOption2_btn.GetComponent<Image>().sprite = checkBox_sprite[0];
        selectYourColor2PlayersOption1_Fields.interactable = false;
        selectYourColor2PlayersOption2_Fields.interactable = true;
    }



    private void LocalMultiplayerBtn(){
        checkClick = 0;
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void PlayWithComputerBtn()
    {
        checkClick = 1;
        main_canvas.GetComponent<CanvasGroup>().interactable = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void LocalMultiplayerBackBtn(){
        main_canvas.GetComponent<CanvasGroup>().interactable = true;
        localMultiplayer_canvas.enabled = false;
    }

    private void LocalMultiplayer2PlayersBtn()
    {
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor2Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_players = 2;
            playWithComputer_canvas.enabled = true;

        }
    }

    private void LocalMultiplayer3PlayersBtn()
    {
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor3Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_players = 3;
            playWithComputer_canvas.enabled = true;
        }
    }

    private void LocalMultiplayer4PlayersBtn()
    {
        localMultiplayer_canvas.enabled = false;
        if (checkClick == 0)
        {
            selectYourColor4Players_canvas.enabled = true;
        }
        else
        {
            playWithComputer_players = 4;
            playWithComputer_canvas.enabled = true;
        }

    }


    private void SelectYourColor2PlayersBackBtn()
    {
        selectYourColor2Players_canvas.enabled = false;
        localMultiplayer_canvas.enabled = true;
    }

    private void OnlineMultiplayerBackBtn(){
        main_canvas.interactable = true;
        onlineMultiplayer_canvas.enabled = false;
    }

    private void StatsBackBtn(){
        main_canvas.interactable = true;
        stats_canvas.enabled = false;
    }

    private void ProfileBoxBtn(){
        main_canvas.interactable = false;
        stats_canvas.enabled = true;
    }

    private void OnlineMultiplayerBtn(){
        main_canvas.interactable = false;
        onlineMultiplayer_canvas.enabled = true;
    }

    private void OnlineMultiplayer2PlayersBtn(){
        onlineMultiplayer_canvas.enabled = false;
        room2Players_canvas.enabled = true;   
    }

    private void OnlineMultiplayer4PlayersBtn()
    {
        onlineMultiplayer_canvas.enabled = false;
        room4Players_canvas.enabled = true;
    }
    private void Room2PlayersBackBtn(){
        room2Players_canvas.enabled = false;
        main_canvas.interactable = true;
    }


    private void Room2Players(int cost, string match_key)
    {
        roomForPlayers = 2;
        matchCost = cost;
        MakeMatch(cost, match_key);

    }

    private void Room4Players(int cost, string match_key)
    {
        roomForPlayers = 4;
        matchCost = cost;
        MakeMatch(cost, match_key);

    }


    private void PlayAnotherRoomBtn(){
        notEnoughCoins_canvas.enabled = false;
        if(roomForPlayers == 2){
            room2Players_canvas.enabled = true;
        }
        else if(roomForPlayers == 4){
            room4Players_canvas.enabled = true;
        }
    }

    private void MakeMatch(int costOfMatch, string match){
        int coins = Database.GetPlayerCoins(Register.userId);
        if (coins >= costOfMatch)
        {
            MakeAMatch.MakeMatch(costOfMatch, match);
            room2Players_canvas.enabled = false;
            room4Players_canvas.enabled = false;
            searchingForPlayer_canvas.enabled = true;
            searchingForPlayer_anim.SetActive(true);
        }
        else
        {
            room2Players_canvas.enabled = false;
            room4Players_canvas.enabled = false;
            notEnoughCoins_canvas.enabled = true;
        }

    }

    private void Set_Wins_Loses(){
        vsComputerWins.text = "" + Database.getVsComputerWins(Register.userId);
        vsComputerLoses.text = "" + Database.getVsComputerLoses(Register.userId);
        vsMultiplayerWins.text = "" + Database.getVsMultiplayerWins(Register.userId);
        vsMultiplayerLoses.text = "" + Database.getVsMultiplayerLoses(Register.userId);
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


}
