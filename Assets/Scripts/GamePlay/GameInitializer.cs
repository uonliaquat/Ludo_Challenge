using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;

using Assets.SimpleAndroidNotifications;

public class GameInitializer : MonoBehaviour
{

    public static string Game;
    public static string PlayerColor;
    public static int NoOfPlayers;
    public static string GameType;


    private GameObject board;
    public GameObject[] player;
    private GameObject[] arrow;
    public GameObject[,] marker;
    private GameObject[] player_image;
    public Sprite[] ludoBoards;
    public Sprite salBoard;
    public Sprite[] glow;
    public Sprite[] markerSprite;
    private GameObject gameManager;
    public static Text Player1Name, Player2Name, Player3Name, Player4Name;
    public static Canvas YouWon, YouLose, EndGame, MainCanvas;
    private static Image congratualtionsImage;
    private static Text endGameWinnerText, youWonCoinsText;
    private GameObject startMenuManager;
    private Button youWon_btn, endGame_btn, youLose_btn, chatSend_btn;
    private bool isGameRunning;
    private int opponentsImageCount;
    public Image player1ProgressBox, player2ProgressBox, player3ProgressBox, player4ProgressBox;
    public static float fillAmount;
    private int amount;

    private static Text youWonCanvasWin_text, youWonCanvasLose_text, youLoseCanvasWin_text, youLoseCanvasLose_text, messageToSend_chat,
    player2MessageText, player3MessageText, player4MessageText;
    private GameObject player2MessageBox, player3MessageBox, player4MessageBox;
    public static GameObject chatField, tapToChat_btn;
    public static bool player2Message, player3Message, player4Message;
    public int backPressCount;

    public Sprite default_pic;
    public AudioSource markerSource, messageSource, diceSource, diceSix, markerKill, markerClear, alarm, dialogSource;
    private GameObject stop1, stop2, stop3, stop4;
    private Canvas exitGame_canvas;
    private Button exitGameCanvasYes_btn, exitGameCanvasNo_btn;
    public Canvas chat_canvas;
    private Button chatCanvasBack_btn;
    private Button chatCanvas_btn1, chatCanvas_btn2, chatCanvas_btn3, chatCanvas_btn4, chatCanvas_btn5, chatCanvas_btn6, chatCanvas_btn7, chatCanvas_btn8, chatCanvas_btn9,
    chatCanvas_btn10, chatCanvas_btn11, chatCanvas_btn12, chatCanvas_btn13, chatCanvas_btn14, chatCanvas_btn15, chatCanvas_btn16, chatCanvas_btn17, chatCanvas_btn18, chatCanvas_btn19,
    chatCanvas_btn20, chatCanvas_btn21, chatCanvas_btn22;
    public static string messageToSend;
    private GameObject gamePlayCoinsObject;
    private Text gamePlayCoins_text;
    public GameObject player1PointsObject, player2PointsObject, player3PointsObject, player4PointsObject;
    public Text player1Points_text, player2Points_text, player3Points_text, player4Points_text;
    public static SpriteRenderer overlap_image;
    private bool progressBar_Cooroutine;
    private bool isAlarming;
    private float timer;
    public static int points;
    public static bool player2_out, player3_out, player4_out;
    private bool wasMusicPlaying_before;

    private void Awake()
    {
        stop1 = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_STOPS[0]);
        stop2 = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_STOPS[1]);
        stop3 = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_STOPS[2]);
        stop4 = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_STOPS[3]);

        overlap_image = GameObject.FindGameObjectWithTag(GameConstants.OVERLAP).GetComponent<SpriteRenderer>();
        player1PointsObject = GameObject.FindGameObjectWithTag(GameConstants.PLAYER1_POINTS_OBJECT);
        player2PointsObject = GameObject.FindGameObjectWithTag(GameConstants.PLAYER2_POINTS_OBJECT);
        player3PointsObject = GameObject.FindGameObjectWithTag(GameConstants.PLAYER3_POINTS_OBJECT);
        player4PointsObject = GameObject.FindGameObjectWithTag(GameConstants.PLAYER4_POINTS_OBJECT);
        player1Points_text = GameObject.FindGameObjectWithTag(GameConstants.PLAYER1_POINTS_TEXT).GetComponent<Text>();
        player2Points_text = GameObject.FindGameObjectWithTag(GameConstants.PLAYER2_POINTS_TEXT).GetComponent<Text>();
        player3Points_text = GameObject.FindGameObjectWithTag(GameConstants.PLAYER3_POINTS_TEXT).GetComponent<Text>();
        player4Points_text = GameObject.FindGameObjectWithTag(GameConstants.PLAYER4_POINTS_TEXT).GetComponent<Text>();
        gamePlayCoinsObject = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_COINS);
        gamePlayCoins_text = GameObject.Find(GameConstants.GAMEPLAY_COINS_TEXT).GetComponent<Text>();
        chat_canvas = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT).GetComponent<Canvas>();
        chatCanvasBack_btn = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BACK_BUTTON).GetComponent<Button>();
        chatCanvas_btn1 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON1).GetComponent<Button>();
        chatCanvas_btn2 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON2).GetComponent<Button>();
        chatCanvas_btn3 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON3).GetComponent<Button>();
        chatCanvas_btn4 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON4).GetComponent<Button>();
        chatCanvas_btn5 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON5).GetComponent<Button>();
        chatCanvas_btn6 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON6).GetComponent<Button>();
        chatCanvas_btn7 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON7).GetComponent<Button>();
        chatCanvas_btn8 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON8).GetComponent<Button>();
        chatCanvas_btn9 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON9).GetComponent<Button>();
        chatCanvas_btn10 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON10).GetComponent<Button>();
        chatCanvas_btn11 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON11).GetComponent<Button>();
        chatCanvas_btn12 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON12).GetComponent<Button>();
        chatCanvas_btn13 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON13).GetComponent<Button>();
        chatCanvas_btn14 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON14).GetComponent<Button>();
        chatCanvas_btn15 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON15).GetComponent<Button>();
        chatCanvas_btn16 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON16).GetComponent<Button>();
        chatCanvas_btn17 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON17).GetComponent<Button>();
        chatCanvas_btn18 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON18).GetComponent<Button>();
        chatCanvas_btn19 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON19).GetComponent<Button>();
        chatCanvas_btn20 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON20).GetComponent<Button>();
        chatCanvas_btn21 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON21).GetComponent<Button>();
        chatCanvas_btn22 = GameObject.FindGameObjectWithTag(GameConstants.CANVAS_CHAT_BUTTON22).GetComponent<Button>();
        exitGame_canvas = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_CANVAS_EXIT_GAME).GetComponent<Canvas>();
        exitGameCanvasYes_btn = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_CANVAS_EXIT_GAME_YES_BUTTON).GetComponent<Button>();
        exitGameCanvasNo_btn = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_CANVAS_EXIT_GAME_NO_BUTTON).GetComponent<Button>();
        player1ProgressBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER1_PROGRESSBOX).GetComponent<Image>();
        player2ProgressBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER2_PROGRESSBOX).GetComponent<Image>();
        player3ProgressBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER3_PROGRESSBOX).GetComponent<Image>();
        player4ProgressBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER4_PROGRESSBOX).GetComponent<Image>();
        player2MessageBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER2_MESSAGE_BOX);
        player3MessageBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER3_MESSAGE_BOX);
        player4MessageBox = GameObject.FindGameObjectWithTag(GameConstants.PLAYER4_MESSAGE_BOX);
        player2MessageText = GameObject.FindGameObjectWithTag(GameConstants.PLAYER2_MESSAGE_TEXT).GetComponent<Text>();
        player3MessageText = GameObject.FindGameObjectWithTag(GameConstants.PLAYER3_MESSAGE_TEXT).GetComponent<Text>();
        player4MessageText = GameObject.FindGameObjectWithTag(GameConstants.PLAYER4_MESSAGE_TEXT).GetComponent<Text>();
        chatField = GameObject.FindGameObjectWithTag(GameConstants.CHAT_FIELD);
        //chatSend_btn = GameObject.FindGameObjectWithTag(GameConstants.CHAT_SEND_BUTTON).GetComponent<Button>();
        tapToChat_btn = GameObject.FindGameObjectWithTag(GameConstants.TAP_TO_CHAT_BUTTON);
        //messageToSend_chat = GameObject.FindGameObjectWithTag(GameConstants.CHAT_MESSAGE_TO_SEND).GetComponent<Text>();
        youWonCanvasWin_text = GameObject.FindGameObjectWithTag(GameConstants.YOUWON_CANVAS_WINS_TEXT).GetComponent<Text>();
        youWonCanvasLose_text = GameObject.FindGameObjectWithTag(GameConstants.YOUWON_CANVAS_LOSES_TEXT).GetComponent<Text>();
        youLoseCanvasWin_text = GameObject.FindGameObjectWithTag(GameConstants.YOULOSE_CANVAS_WINS_TEXT).GetComponent<Text>();
        youLoseCanvasLose_text = GameObject.FindGameObjectWithTag(GameConstants.YOULOSE_CANVAS_LOSES_TEXT).GetComponent<Text>();
        youLose_btn = GameObject.FindGameObjectWithTag(GameConstants.YOULOSE_BUTTON).GetComponent<Button>();
        endGame_btn = GameObject.FindGameObjectWithTag(GameConstants.ENDGAME_BUTTON).GetComponent<Button>();
        youWon_btn = GameObject.FindGameObjectWithTag(GameConstants.YOUWON_BUTTON).GetComponent<Button>();
        startMenuManager = GameObject.FindGameObjectWithTag(GameConstants.START_MENU_MANAGER);
        YouWon = GameObject.FindGameObjectWithTag(GameConstants.YOUWON_CANVAS).GetComponent<Canvas>();
        YouLose = GameObject.FindGameObjectWithTag(GameConstants.YOULOSE_CANVAS).GetComponent<Canvas>();
        EndGame = GameObject.FindGameObjectWithTag(GameConstants.ENDGAME_CANVAS).GetComponent<Canvas>();
        MainCanvas = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_CANVAS_MAIN).GetComponent<Canvas>();
        congratualtionsImage = GameObject.FindGameObjectWithTag(GameConstants.ENDGAME_CANVAS_CONGRATULATIONS_IMAGE).GetComponent<Image>();
        endGameWinnerText = GameObject.FindGameObjectWithTag(GameConstants.ENDGAME_CANVAS_WINNER_TEXT).GetComponent<Text>();
        Player1Name = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_PLAYER1_NAME).GetComponent<Text>();
        Player2Name = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_PLAYER2_NAME).GetComponent<Text>();
        Player3Name = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_PLAYER3_NAME).GetComponent<Text>();
        Player4Name = GameObject.FindGameObjectWithTag(GameConstants.GAMEPLAY_PLAYER4_NAME).GetComponent<Text>();
        youWonCoinsText = GameObject.FindGameObjectWithTag(GameConstants.YOUWON_CANVAS_COINS_TEXT).GetComponent<Text>();
        board = GameObject.FindGameObjectWithTag(GameConstants.BOARD);

        //chatField.SetActive(false);
        player2MessageBox.SetActive(false);
        player3MessageBox.SetActive(false);
        player4MessageBox.SetActive(false);




        player = new GameObject[4];
        player_image = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            player[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER[i]);
            player_image[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_IMAGE[i]);
        }

        marker = new GameObject[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                marker[i, j] = GameObject.FindGameObjectWithTag(GameConstants.MARKER[i, j]);
            }
        }

        arrow = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            arrow[i] = GameObject.FindGameObjectWithTag(GameConstants.ARROW[i]);
        }

        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

    }

    // Use this for initialization
    void Start()
    {
        //overlap_image.enabled = false;
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            gamePlayCoins_text.text = "" + Database.GetPlayerCoins(Register.userId);
        }
        DeativateGameObjects();
        SetMarkersPosition();

        SetBoard();
        SetPlayerNames();
        SetPlayerImage();
        SetPlayerMarker();
        SetNoOfPlayers();
        setPlayer();


        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            OnlineMultiplayer.ChallengeTurnTakenListener();
        }


        endGame_btn.onClick.AddListener(BackToMenu);
        youWon_btn.onClick.AddListener(BackToMenu);
        youLose_btn.onClick.AddListener(BackToMenu);
        tapToChat_btn.GetComponent<Button>().onClick.AddListener(TapToChatBtn);
        //chatSend_btn.onClick.AddListener(ChatSendBtn);




        chatCanvasBack_btn.onClick.AddListener(ChatCanvasBackBtn);
        chatCanvas_btn1.onClick.AddListener(ChatCanvasBtn1);
        chatCanvas_btn2.onClick.AddListener(ChatCanvasBtn2);
        chatCanvas_btn3.onClick.AddListener(ChatCanvasBtn3);
        chatCanvas_btn4.onClick.AddListener(ChatCanvasBtn4);
        chatCanvas_btn5.onClick.AddListener(ChatCanvasBtn5);
        chatCanvas_btn6.onClick.AddListener(ChatCanvasBtn6);
        chatCanvas_btn7.onClick.AddListener(ChatCanvasBtn7);
        chatCanvas_btn8.onClick.AddListener(ChatCanvasBtn8);
        chatCanvas_btn9.onClick.AddListener(ChatCanvasBtn9);
        chatCanvas_btn10.onClick.AddListener(ChatCanvasBtn10);
        chatCanvas_btn11.onClick.AddListener(ChatCanvasBtn11);
        chatCanvas_btn12.onClick.AddListener(ChatCanvasBtn12);
        chatCanvas_btn13.onClick.AddListener(ChatCanvasBtn13);
        chatCanvas_btn14.onClick.AddListener(ChatCanvasBtn14);
        chatCanvas_btn15.onClick.AddListener(ChatCanvasBtn15);
        chatCanvas_btn16.onClick.AddListener(ChatCanvasBtn16);
        chatCanvas_btn17.onClick.AddListener(ChatCanvasBtn17);
        chatCanvas_btn18.onClick.AddListener(ChatCanvasBtn18);
        chatCanvas_btn19.onClick.AddListener(ChatCanvasBtn19);
        chatCanvas_btn20.onClick.AddListener(ChatCanvasBtn20);
        chatCanvas_btn21.onClick.AddListener(ChatCanvasBtn21);
        chatCanvas_btn22.onClick.AddListener(ChatCanvasBtn22);

        opponentsImageCount = 0;
        fillAmount = 0.92f;
        amount = 100;
        player2Message = false;
        player3Message = false;
        player4Message = false;
        if(GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER){
            tapToChat_btn.SetActive(false);
            gamePlayCoinsObject.SetActive(false);
            player1PointsObject.SetActive(false);
            player2PointsObject.SetActive(false);
            player3PointsObject.SetActive(false);
            player4PointsObject.SetActive(false);
        }
        wasMusicPlaying_before = false;

        if (Music.isMusicPlaying)
        {
            wasMusicPlaying_before = true;
        }
        Music.isMusicPlaying = false;
        progressBar_Cooroutine = true;
        isAlarming = false;
        player2_out = false;
        player3_out = false;
        player4_out = false;
        backPressCount = 0;
        messageToSend = "";
        points = 5;
        timer = Time.deltaTime / 100;



        exitGameCanvasYes_btn.onClick.AddListener(ExitGameYesBtn);
        exitGameCanvasNo_btn.onClick.AddListener(ExitGameNoBtn);

    }

    private void Update()
    {
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (NoOfPlayers == GameConstants.TWO_PLAYERS)
            {
                if (startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded)
                {
                    startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded = false;
                    SetOpponentsImage();
                }
            }
            else if (NoOfPlayers == GameConstants.FOUR_PLAYERS)
            {
                SetOpponentsImage();
            }
        }

        CheckIncomingMessages();
        ProgressBox();
        OnBackPress();
        CheckifSurvived_4PlayerMultiplayer();



        if (GameType == GameConstants.ONLINE_MULTIPLAYER && progressBar_Cooroutine)
        {
            progressBar_Cooroutine = false;
            StartCoroutine(FillAmountDelay(timer));
        }
    }


    private void ChatCanvasBackBtn()
    {
        chat_canvas.enabled = false;
        tapToChat_btn.SetActive(true);
    }


    private void ChatCanvasBtn1()
    {
        messageToSend = "Hi!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn2()
    {
        messageToSend = "Hello!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn3()
    {
        messageToSend = "Play Fast!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn4()
    {
        messageToSend = "No Please!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn5()
    {
        messageToSend = "Okay!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn6()
    {
        messageToSend = "I need to go, Sorry!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn7()
    {
        messageToSend = "Don’t run away!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn8()
    {
        messageToSend = "Some urgent work, Bye!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn9()
    {
        messageToSend = "Bye! Bye!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn10()
    {
        messageToSend = "Why you hit me?";
        ChatSendBtn();
    }
    private void ChatCanvasBtn11()
    {
        messageToSend = "Game is not over yet!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn12()
    {
        messageToSend = "You can’t beat me!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn13()
    {
        messageToSend = "Hahahahaha!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn14()
    {
        messageToSend = "Today is My Day!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn15()
    {
        messageToSend = "All the best!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn16()
    {
        messageToSend = "I am the Best!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn17()
    {
        messageToSend = "Boom Boom";
        ChatSendBtn();
    }
    private void ChatCanvasBtn18()
    {
        messageToSend = "Ludo Challenge is Awesome!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn19()
    {
        messageToSend = "Yeah!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn20()
    {
        messageToSend = "Oops!";
        ChatSendBtn();
    }
    private void ChatCanvasBtn21()
    {
        messageToSend = "OMG";
        ChatSendBtn();
    }
    private void ChatCanvasBtn22()
    {
        messageToSend = "LOL";
        ChatSendBtn();
    }


    private void ExitGameYesBtn()
    {
        exitGame_canvas.enabled = false;
        if (wasMusicPlaying_before)
        {
            Music.isMusicPlaying = true;
        }
        if (GameType == GameConstants.LOCAL_MULTIPLAYER)
        {

            if (Game == GameConstants.LUDO_CHALLENGE)
            {
                SceneManager.LoadScene(GameConstants.MAINMENU_SCENE);
            }
            else if (Game == GameConstants.SNAKES_AND_LADDER)
            {
                SceneManager.LoadScene(GameConstants.MAIN_MENU_SAL_SCENE);
            }
        }
        else if (GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            youLoseCanvasWin_text.text = "" + Database.getVsComputerWins(Register.userId);
            youLoseCanvasLose_text.text = "" + Database.getVsComputerLoses(Register.userId);
            YouLose.enabled = true;
        }
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            messageToSend = "EndGame";
            ChatSendBtn();

            //if (Advertisement.IsReady())
            //{
            //    Advertisement.Show();
            //}
        }
    }
    private void ExitGameNoBtn()
    {
        exitGame_canvas.enabled = false;
    }

    private void TapToChatBtn()
    {
        tapToChat_btn.SetActive(false);
        chat_canvas.enabled = true;

        //chatField.SetActive(true);
        //messageToSend_chat.text = "";
    }

    private void ChatSendBtn()
    {
        if (messageToSend == "EndGame")
        {
            string message = "////";
            message = message + " " + MakeAMatch.displayName + "   " + messageToSend;
            if (GameController.playerTurn == 0)
            {
                OnlineMultiplayer.SendValues(0, -1, 0, 0, GameConstants.TWO_PLAYER_CHALLENGE_DATA_EVENT);
            }
            MakeAMatch.ChatOnChallengeRequest(MakeAMatch.challengeId, message);

            SetValues_YouLose();
        }

        if (Database.GetPlayerCoins(Register.userId) >= 10)
        {
            string message = "////";
            message = message + " " + MakeAMatch.displayName + "   " + messageToSend;
            MakeAMatch.ChatOnChallengeRequest(MakeAMatch.challengeId, message);
            chat_canvas.enabled = false;
            tapToChat_btn.SetActive(true);

            int coins = Database.GetPlayerCoins(Register.userId);
            coins = coins - 10;
            Database.SetPlayerCoins(Register.userId, coins);
            gamePlayCoins_text.text = "" + coins;
        }
        else
        {
            ShowToast.MyShowToastMethod("You don't have enough coins!");
        }

    }

    void SetBoard()
    {
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            GameObject[] player_glow = new GameObject[4];
            for (int i = 0; i < 4; i++)
            {
                player_glow[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_GLOW[i]);
            }
            switch (PlayerColor)
            {
                case "Red":
                    board.GetComponent<Image>().sprite = ludoBoards[0];
                    player_glow[0].GetComponent<Image>().sprite = glow[0];
                    player_glow[1].GetComponent<Image>().sprite = glow[1];
                    player_glow[2].GetComponent<Image>().sprite = glow[2];
                    player_glow[3].GetComponent<Image>().sprite = glow[3];


                    if (GameType != GameConstants.ONLINE_MULTIPLAYER)
                    {
                        //Red
                        Player1Name.color = Color.red;

                        //Blue
                        Player2Name.color = Color.blue;

                        //Yellow
                        Player3Name.color = Color.yellow;

                        //Green
                        Player4Name.color = Color.green;
                    }

                    break;
                case "Blue":
                    board.GetComponent<Image>().sprite = ludoBoards[1];
                    player_glow[0].GetComponent<Image>().sprite = glow[1];
                    player_glow[1].GetComponent<Image>().sprite = glow[2];
                    player_glow[2].GetComponent<Image>().sprite = glow[3];
                    player_glow[3].GetComponent<Image>().sprite = glow[0];


                    if (GameType != GameConstants.ONLINE_MULTIPLAYER)
                    {
                        Player2Name.color = Color.yellow;

                        Player3Name.color = Color.green;

                        Player4Name.color = Color.red;

                        Player1Name.color = Color.blue;
                    }


                    break;
                case "Yellow":
                    board.GetComponent<Image>().sprite = ludoBoards[2];
                    player_glow[0].GetComponent<Image>().sprite = glow[2];
                    player_glow[1].GetComponent<Image>().sprite = glow[3];
                    player_glow[2].GetComponent<Image>().sprite = glow[0];
                    player_glow[3].GetComponent<Image>().sprite = glow[1];

                    if (GameType != GameConstants.ONLINE_MULTIPLAYER)
                    {
                        Player3Name.color = Color.red;

                        Player4Name.color = Color.blue;

                        Player1Name.color = Color.yellow;

                        Player2Name.color = Color.green;
                    }

                    break;
                case "Green":
                    board.GetComponent<Image>().sprite = ludoBoards[3];
                    player_glow[0].GetComponent<Image>().sprite = glow[3];
                    player_glow[1].GetComponent<Image>().sprite = glow[0];
                    player_glow[2].GetComponent<Image>().sprite = glow[1];
                    player_glow[3].GetComponent<Image>().sprite = glow[2];

                    if (GameType != GameConstants.ONLINE_MULTIPLAYER)
                    {
                        Player4Name.color = Color.yellow;

                        Player1Name.color = Color.green;

                        Player2Name.color = Color.red;

                        Player3Name.color = Color.blue;
                    }

                    break;
            }
        }
        else if (Game == GameConstants.SNAKES_AND_LADDER)
        {
            board.GetComponent<Image>().sprite = salBoard;
        }
    }

    void SetPlayerImage()
    {
        SetImageSize();
        if (GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            if (Game == GameConstants.LUDO_CHALLENGE)
            {
                switch (PlayerColor)
                {
                    case "Red":
                        player_image[0].GetComponent<Image>().sprite = markerSprite[0];
                        player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                        player_image[2].GetComponent<Image>().sprite = markerSprite[2];
                        player_image[3].GetComponent<Image>().sprite = markerSprite[3];
                        break;
                    case "Blue":
                        player_image[0].GetComponent<Image>().sprite = markerSprite[1];
                        player_image[1].GetComponent<Image>().sprite = markerSprite[2];
                        player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                        player_image[3].GetComponent<Image>().sprite = markerSprite[0];
                        break;
                    case "Yellow":
                        player_image[0].GetComponent<Image>().sprite = markerSprite[2];
                        player_image[1].GetComponent<Image>().sprite = markerSprite[3];
                        player_image[2].GetComponent<Image>().sprite = markerSprite[0];
                        player_image[3].GetComponent<Image>().sprite = markerSprite[1];
                        break;
                    case "Green":
                        player_image[0].GetComponent<Image>().sprite = markerSprite[3];
                        player_image[1].GetComponent<Image>().sprite = markerSprite[0];
                        player_image[2].GetComponent<Image>().sprite = markerSprite[1];
                        player_image[3].GetComponent<Image>().sprite = markerSprite[2];
                        break;
                }
            }

            else if (Game == GameConstants.SNAKES_AND_LADDER)
            {
                if (NoOfPlayers == GameConstants.TWO_PLAYERS)
                {
                    switch (PlayerColor)
                    {
                        case "Red":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[0];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[2];
                            break;
                        case "Blue":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[3];
                            break;
                        case "Green":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                            break;
                        case "Yellow":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[0];
                            break;
                    }
                }
                else if (NoOfPlayers == GameConstants.THREE_PLAYERS)
                {
                    switch (PlayerColor)
                    {
                        case "Red":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[0];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[2];
                            break;
                        case "Blue":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                            break;
                        case "Green":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[2];
                            break;
                        case "Yellow":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[0];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                            break;
                    }
                }
                else if (NoOfPlayers == GameConstants.FOUR_PLAYERS)
                {
                    switch (PlayerColor)
                    {
                        case "Red":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[0];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[3].GetComponent<Image>().sprite = markerSprite[2];
                            break;
                        case "Blue":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[3].GetComponent<Image>().sprite = markerSprite[0];
                            break;
                        case "Green":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[1];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[3].GetComponent<Image>().sprite = markerSprite[0];
                            break;
                        case "Yellow":
                            player_image[0].GetComponent<Image>().sprite = markerSprite[2];
                            player_image[1].GetComponent<Image>().sprite = markerSprite[0];
                            player_image[2].GetComponent<Image>().sprite = markerSprite[3];
                            player_image[3].GetComponent<Image>().sprite = markerSprite[1];
                            break;
                    }
                }
            }
        }
        else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (Game == GameConstants.LUDO_CHALLENGE)
            {

                if (NoOfPlayers == GameConstants.TWO_PLAYERS)
                {
                    if (LoginWithFB.FacebookLoggedIn)
                    {
                        player_image[0].GetComponent<Image>().sprite = StartMenu.displayImage.sprite;
                        StartCoroutine(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadFBImage(MakeAMatch.opponents_image_ids[0]));
                    }
                    else
                    {
                        if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
                        {
                            player_image[0].GetComponent<Image>().sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
                        }
                        else
                        {
                            player_image[0].GetComponent<Image>().sprite = default_pic;
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            if (MakeAMatch.opponents_name[i] != MakeAMatch.displayName)
                            {
                                if (MakeAMatch.opponents_image_ids[i] != "0")
                                {
                                    startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_ids[i]);
                                    break;
                                }
                                else
                                {
                                    player_image[2].GetComponent<Image>().sprite = default_pic;
                                    break;
                                }
                            }
                        }
                    }
                }

                else if (NoOfPlayers == GameConstants.FOUR_PLAYERS)
                {
                    if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
                    {
                        player_image[0].GetComponent<Image>().sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
                    }
                    else
                    {
                        player_image[0].GetComponent<Image>().sprite = default_pic;
                    }


                    for (int i = 0; i < 4; i++)
                    {
                        if (MakeAMatch.opponents_image_ids[i] != "0")
                        {
                            if (MakeAMatch.opponents_name[i] != MakeAMatch.displayName)
                            {
                                opponentsImageCount = opponentsImageCount + 1;
                                startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_ids[i]);
                            }
                        }
                    }
                }
            }
            else if (Game == GameConstants.SNAKES_AND_LADDER)
            {
                if (NoOfPlayers == GameConstants.TWO_PLAYERS)
                {
                    
                    if (LoginWithFB.FacebookLoggedIn)
                    {
                        player_image[0].GetComponent<Image>().sprite = StartMenu.displayImage.sprite;
                        StartCoroutine(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadFBImage(MakeAMatch.opponents_image_ids[0]));
                    }
                    else
                    {
                        if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
                        {
                            player_image[0].GetComponent<Image>().sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
                        }
                        else
                        {
                            player_image[0].GetComponent<Image>().sprite = default_pic;
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            if (MakeAMatch.opponents_name[i] != MakeAMatch.displayName)
                            {
                                if (MakeAMatch.opponents_image_ids[i] != "0")
                                {
                                    startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_ids[i]);
                                    break;
                                }
                                else
                                {
                                    player_image[1].GetComponent<Image>().sprite = default_pic;
                                    break;
                                }
                            }
                        }
                    }
                }

                else if (NoOfPlayers == GameConstants.FOUR_PLAYERS)
                {
                    if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
                    {
                        player_image[0].GetComponent<Image>().sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
                    }
                    else
                    {
                        player_image[0].GetComponent<Image>().sprite = default_pic;
                    }


                    for (int i = 0; i < 4; i++)
                    {
                        if (MakeAMatch.opponents_image_ids[i] != "0")
                        {
                            if (MakeAMatch.opponents_name[i] != MakeAMatch.displayName)
                            {
                                opponentsImageCount = opponentsImageCount + 1;
                                startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_ids[i]);
                            }
                        }
                    }
                }

            }
        }
    }

    void SetPlayerMarker()
    {
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            switch (PlayerColor)
            {
                case "Red":
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            marker[i, j].GetComponent<Image>().sprite = markerSprite[i];
                        }
                    }
                    break;
                case "Blue":
                    for (int i = 0; i < 4; i++)
                    {
                        marker[0, i].GetComponent<Image>().sprite = markerSprite[1];
                        marker[1, i].GetComponent<Image>().sprite = markerSprite[2];
                        marker[2, i].GetComponent<Image>().sprite = markerSprite[3];
                        marker[3, i].GetComponent<Image>().sprite = markerSprite[0];
                    }
                    break;
                case "Yellow":
                    for (int i = 0; i < 4; i++)
                    {
                        marker[0, i].GetComponent<Image>().sprite = markerSprite[2];
                        marker[1, i].GetComponent<Image>().sprite = markerSprite[3];
                        marker[2, i].GetComponent<Image>().sprite = markerSprite[0];
                        marker[3, i].GetComponent<Image>().sprite = markerSprite[1];
                    }
                    break;
                case "Green":
                    for (int i = 0; i < 4; i++)
                    {
                        marker[0, i].GetComponent<Image>().sprite = markerSprite[3];
                        marker[1, i].GetComponent<Image>().sprite = markerSprite[0];
                        marker[2, i].GetComponent<Image>().sprite = markerSprite[1];
                        marker[3, i].GetComponent<Image>().sprite = markerSprite[2];
                    }
                    break;
            }
        }
        else if (Game == GameConstants.SNAKES_AND_LADDER)
        {
            if (NoOfPlayers == GameConstants.TWO_PLAYERS)
            {
                switch (PlayerColor)
                {
                    case "Red":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[0];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[2];
                        break;
                    case "Blue":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[3];
                        break;
                    case "Green":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[1];
                        break;
                    case "Yellow":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[0];
                        break;
                }
            }
            else if (NoOfPlayers == GameConstants.THREE_PLAYERS)
            {
                switch (PlayerColor)
                {
                    case "Red":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[0];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[2];
                        break;
                    case "Blue":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[3];
                        break;
                    case "Green":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[2];
                        break;
                    case "Yellow":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[0];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[3];
                        break;
                }
            }
            else{
                switch (PlayerColor)
                {
                    case "Red":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[0];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[3, 0].GetComponent<Image>().sprite = markerSprite[2];
                        break;
                    case "Blue":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[3, 0].GetComponent<Image>().sprite = markerSprite[0];
                        break;
                    case "Green":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[1];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[3, 0].GetComponent<Image>().sprite = markerSprite[0];
                        break;
                    case "Yellow":
                        marker[0, 0].GetComponent<Image>().sprite = markerSprite[2];
                        marker[1, 0].GetComponent<Image>().sprite = markerSprite[0];
                        marker[2, 0].GetComponent<Image>().sprite = markerSprite[3];
                        marker[3, 0].GetComponent<Image>().sprite = markerSprite[1];
                        break;
                }
            }
        }
    }

    void SetNoOfPlayers()
    {
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            if (NoOfPlayers == GameConstants.TWO_PLAYERS)
            {
                player[1].SetActive(false);
                player[3].SetActive(false);
            }
            else if (NoOfPlayers == GameConstants.THREE_PLAYERS)
            {
                player[3].SetActive(false);
            }
        }
        else{
            if (NoOfPlayers == GameConstants.TWO_PLAYERS)
            {
                player[2].SetActive(false);
                player[3].SetActive(false);
            }
            else if (NoOfPlayers == GameConstants.THREE_PLAYERS)
            {
                player[3].SetActive(false);
            }
        }
    }

    void setPlayer()
    {

        if (GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            gameManager.GetComponent<PlayerActivation>().ActivateDice(0);
            gameManager.GetComponent<PlayerActivation>().ActivateGlow(0);
            gameManager.GetComponent<PlayerActivation>().ActivateArrows(0);
        }
        else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (NoOfPlayers == 2)
            {
                if (Game == GameConstants.LUDO_CHALLENGE)
                {
                    if (MakeAMatch.userId == OnlineMultiplayer.playerTurn_UserId)
                    {
                        gameManager.GetComponent<PlayerActivation>().ActivateDice(0);
                        gameManager.GetComponent<PlayerActivation>().ActivateGlow(0);
                        gameManager.GetComponent<PlayerActivation>().ActivateArrows(0);
                        GameController.playerTurn = 0;
                    }
                    else
                    {
                        gameManager.GetComponent<PlayerActivation>().ActivateGlow(2);
                        gameManager.GetComponent<PlayerActivation>().ActivateArrows(2);
                        GameController.playerTurn = 2;
                    }
                }
                else if (Game == GameConstants.SNAKES_AND_LADDER)
                {
                    if (MakeAMatch.userId == OnlineMultiplayer.playerTurn_UserId)
                    {
                        gameManager.GetComponent<PlayerActivation>().ActivateDice(0);
                        gameManager.GetComponent<PlayerActivation>().ActivateGlow(0);
                        gameManager.GetComponent<PlayerActivation>().ActivateArrows(0);
                        GameController.playerTurn = 0;
                    }
                    else
                    {
                        gameManager.GetComponent<PlayerActivation>().ActivateGlow(1);
                        gameManager.GetComponent<PlayerActivation>().ActivateArrows(1);
                        GameController.playerTurn = 1;
                    }
                }
            }
            else if (NoOfPlayers == 4)
            {
                if (MakeAMatch.userId == OnlineMultiplayer.playerTurn_UserId)
                {
                    gameManager.GetComponent<PlayerActivation>().ActivateDice(0);
                    gameManager.GetComponent<PlayerActivation>().ActivateGlow(0);
                    gameManager.GetComponent<PlayerActivation>().ActivateArrows(0);
                    GameController.playerTurn = 0;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (MakeAMatch.playerIDs[i] == OnlineMultiplayer.playerTurn_UserId)
                        {
                            if (Player2Name.text == MakeAMatch.playerNames[i])
                            {
                                gameManager.GetComponent<PlayerActivation>().ActivateGlow(1);
                                gameManager.GetComponent<PlayerActivation>().ActivateArrows(1);
                                GameController.playerTurn = 1;
                            }
                            else if (Player3Name.text == MakeAMatch.playerNames[i])
                            {
                                gameManager.GetComponent<PlayerActivation>().ActivateGlow(2);
                                gameManager.GetComponent<PlayerActivation>().ActivateArrows(2);
                                GameController.playerTurn = 2;
                            }
                            else if (Player4Name.text == MakeAMatch.playerNames[i])
                            {
                                gameManager.GetComponent<PlayerActivation>().ActivateGlow(3);
                                gameManager.GetComponent<PlayerActivation>().ActivateArrows(3);
                                GameController.playerTurn = 3;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }


    public static void SetGame(string game, string gameType, string color, int noOfPlayers)
    {
        Game = game;
        GameType = gameType;
        PlayerColor = color;
        NoOfPlayers = noOfPlayers;
    }

    private void SetPlayerNames()
    {
        if(GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER){
            Player1Name.text = MainMenu.player1Name;
            Player2Name.text = MainMenu.player2Name;
            Player3Name.text = MainMenu.player3Name;
            Player4Name.text = MainMenu.player4Name;
            if (GameType == GameConstants.PLAY_WITH_COMPUTER)
            {
                Player3Name.transform.Rotate(new Vector3(0, 0, 180));
                Player4Name.transform.Rotate(new Vector3(0, 0, 180));
            }
        }

        else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            Player1Name.text = MakeAMatch.displayName;
            if (NoOfPlayers == 2)
            {
                if (Game == GameConstants.LUDO_CHALLENGE)
                {
                    if (MakeAMatch.playerNames[0] != MakeAMatch.displayName)
                    {
                        Player3Name.text = MakeAMatch.playerNames[0];
                    }
                    else
                    {
                        Player3Name.text = MakeAMatch.playerNames[1];
                    }
                }
                else if (Game == GameConstants.SNAKES_AND_LADDER)
                {
                    if (MakeAMatch.playerNames[0] != MakeAMatch.displayName)
                    {
                        Player2Name.text = MakeAMatch.playerNames[0];
                    }
                    else
                    {
                        Player2Name.text = MakeAMatch.playerNames[1];
                    }
                }

                Player3Name.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            }
            else if (NoOfPlayers == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (MakeAMatch.playerNames[i] == MakeAMatch.displayName)
                    {
                        i = i + 1;
                        if (i >= 4)
                        {
                            i = 0;
                        }
                        Player2Name.text = MakeAMatch.playerNames[i];
                        i = i + 1;
                        if (i >= 4)
                        {
                            i = 0;
                        }
                        Player3Name.text = MakeAMatch.playerNames[i];
                        i = i + 1;
                        if (i >= 4)
                        {
                            i = 0;
                        }
                        Player4Name.text = MakeAMatch.playerNames[i];
                        break;
                    }
                }
                Player3Name.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                Player4Name.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            }
        }
    }


    public static void EndGameMethod()
    {
        GameController.gameRunning = false;
        GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
        MainCanvas.GetComponent<CanvasGroup>().interactable = false;
        if (GameType == GameConstants.LOCAL_MULTIPLAYER)
        {
            //overlap_image.enabled = true;
            congratualtionsImage.enabled = true;
            endGameWinnerText.text = CheckWin.playerWon + " Won!";
            EndGame.enabled = true;
            game_manager.GetComponent<PlayerActivation>().DeactivateAllGlow();
            game_manager.GetComponent<PlayerActivation>().DeactivateAllArrows();
            game_manager.GetComponent<GameController>().dice.GetComponent<Dice>().enabled = false;

        }
        else if (GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            //overlap_image.enabled = true;
            congratualtionsImage.enabled = false;
            endGameWinnerText.text = CheckWin.playerWon + " Won!";
            EndGame.enabled = true;

            if (Game == GameConstants.LUDO_CHALLENGE)
            {
                if (GameController.playerTurn == 0)
                {
                    Database.setVsComputerWins(Register.userId);
                    Debug.Log("Vs Computer Wins: " + Database.getVsComputerWins(Register.userId));
                }
                else
                {
                    Database.setVsComputerLoses(Register.userId);
                    Debug.Log("Vs Computer Loses: " + Database.getVsComputerLoses(Register.userId));
                }
            }
            else if (Game == GameConstants.SNAKES_AND_LADDER)
            {
                if (GameController.playerTurn == 0)
                {
                    Database.setVsComputerWinsSAL(Register.userId);
                    Debug.Log("Vs Computer Wins: " + Database.getVsComputerWinsSAL(Register.userId));
                }
                else
                {
                    Database.setVsComputerLosesSAL(Register.userId);
                    Debug.Log("Vs Computer Loses: " + Database.getVsComputerLosesSAL(Register.userId));
                }
            }
        }
        else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (CheckWin.playerWon == MakeAMatch.displayName)
            {

                SetValues_YouWin();
            }
            else
            {
                SetValues_YouLose();
            }
        }
        else if (GameType == GameConstants.PLAY_WITH_FREINDS)
        {

        }
    }


    private void END_GAME()
    {
        if (Game == GameConstants.LOCAL_MULTIPLAYER)
        {

        }
        else if (Game == GameConstants.ONLINE_MULTIPLAYER)
        {

        }
        else if (Game == GameConstants.ONLINE_MULTIPLAYER)
        {

        }

    }


    public static void SetValues_YouLose()
    {
        if (Register.isSoundPlaying)
        {
            GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
            game_manager.GetComponent<GameInitializer>().dialogSource.Play();
        }
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            Database.setVsMultiplayerLoses(Register.userId);
            youLoseCanvasWin_text.text = "" + Database.getVsMultiplayerWins(Register.userId);
            youLoseCanvasLose_text.text = "" + Database.getVsComputerLoses(Register.userId);
            Debug.Log("Wons: " + Database.getVsMultiplayerWins(Register.userId));
            Debug.Log("Loses: " + Database.getVsMultiplayerLoses(Register.userId));
        }
        else if (Game == GameConstants.SNAKES_AND_LADDER)
        {
            Database.setVsMultiplayerLosesSAL(Register.userId);
            youLoseCanvasWin_text.text = "" + Database.getVsMultiplayerWinsSAL(Register.userId);
            youLoseCanvasLose_text.text = "" + Database.getVsComputerLosesSAL(Register.userId);
            Debug.Log("Wons: " + Database.getVsMultiplayerWinsSAL(Register.userId));
            Debug.Log("Loses: " + Database.getVsMultiplayerLosesSAL(Register.userId));
        }
        YouLose.enabled = true;
        //overlap_image.enabled = true;
    }

    public static void SetValues_YouWin()
    {
        if (Register.isSoundPlaying)
        {
            GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
            game_manager.GetComponent<GameInitializer>().dialogSource.Play();
        }
        int coins = 0;
        if (MainMenu.roomForPlayers == 2)
        {
            coins = MainMenu.matchCost * 2;
        }
        else if (MainMenu.roomForPlayers == 4)
        {
            coins = MainMenu.matchCost * 4;
        }

        youWonCoinsText.text = "" + coins;

        int available_coins = Database.GetPlayerCoins(Register.userId);
        coins = coins + available_coins;
        Database.SetPlayerCoins(Register.userId, coins);

        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            Database.setVsMultiplayerWins(Register.userId);
            youWonCanvasWin_text.text = "" + Database.getVsMultiplayerWins(Register.userId);
            youWonCanvasLose_text.text = "" + Database.getVsMultiplayerLoses(Register.userId);
            Debug.Log("Wons: " + Database.getVsMultiplayerWins(Register.userId));
            Debug.Log("Loses: " + Database.getVsMultiplayerLoses(Register.userId));
        }
        else if (Game == GameConstants.SNAKES_AND_LADDER)
        {
            Database.setVsMultiplayerWinsSAL(Register.userId);
            youWonCanvasWin_text.text = "" + Database.getVsMultiplayerWinsSAL(Register.userId);
            youWonCanvasLose_text.text = "" + Database.getVsMultiplayerLosesSAL(Register.userId);
            Debug.Log("Wons: " + Database.getVsMultiplayerWinsSAL(Register.userId));
            Debug.Log("Loses: " + Database.getVsMultiplayerLosesSAL(Register.userId));
        }
        YouWon.enabled = true;
        //overlap_image.enabled = true;
    }

    public void BackToMenu()
    {
        GameController.playerTurn = 0;
        if (wasMusicPlaying_before)
        {
            Music.isMusicPlaying = true;
        }

        MainCanvas.GetComponent<CanvasGroup>().interactable = true;
        YouWon.enabled = false;
        YouLose.enabled = false;
        EndGame.enabled = false;

        if (!StartMenu.playAsGuest)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
        }


        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            //Change Scene
            SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
        }
        else if (Game == GameConstants.SNAKES_AND_LADDER)
        {
            //Change Scene
            SceneManager.LoadScene(GameConstants.START_MENU_SAL_SCENE);
        }
    }


    public void SetOpponentsImage()
    {

        if (NoOfPlayers == GameConstants.TWO_PLAYERS)
        {
            if (Game == GameConstants.LUDO_CHALLENGE)
            {
                    Rect rec = new Rect(0, 0, startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.width,
                                        startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.height);
                    player_image[2].GetComponent<Image>().sprite =
                                       Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage, rec, new Vector2(0.5f, 0.5f), 100);
            }
            else if (Game == GameConstants.SNAKES_AND_LADDER)
            {
                Rect rec = new Rect(0, 0, startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.width,
                                    startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.height);
                player_image[1].GetComponent<Image>().sprite =
                                   Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage, rec, new Vector2(0.5f, 0.5f), 100);
            }
        }
        else if (NoOfPlayers == GameConstants.FOUR_PLAYERS)
        {
            for (int i = 0; i < 3; i++)
            {
                if (startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImagesDownloaded[i])
                {
                    startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImagesDownloaded[i] = false;
                    for (int j = 0; j < MakeAMatch.opponents_image_ids.Count; j++)
                    {
                        if (startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImageURLS[i].Contains(MakeAMatch.opponents_image_ids[j]))
                        {
                            Rect rec = new Rect(0, 0, startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImagePlayers[i].width,
                                                startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImagePlayers[i].height);
                            if (MakeAMatch.opponents_name[j] == Player2Name.text)
                            {
                                Debug.Log("Player 2 Done");
                                player_image[1].GetComponent<Image>().sprite =
                                           Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImagePlayers[i], rec, new Vector2(0.5f, 0.5f), 100);
                            }
                            else if (MakeAMatch.opponents_name[j] == Player3Name.text)
                            {
                                Debug.Log("Player 3 Done");
                                player_image[2].GetComponent<Image>().sprite =
                                           Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImagePlayers[i], rec, new Vector2(0.5f, 0.5f), 100);
                            }

                            else if (MakeAMatch.opponents_name[j] == Player4Name.text)
                            {
                                Debug.Log("Player 4 Done");
                                player_image[3].GetComponent<Image>().sprite =
                                           Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadImagePlayers[i], rec, new Vector2(0.5f, 0.5f), 100);
                            }
                        }
                    }

                }
            }
        }
    }


    public void SetImageSize()
    {
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            for (int i = 0; i < 4; i++)
            {
                player_image[i].GetComponent<RectTransform>().sizeDelta = new Vector2(75, 70);
                if (i >= 2)
                {
                    player_image[i].GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                }
            }
        }
        else if (GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            for (int i = 0; i < 4; i++)
            {
                player_image[i].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 70);
                if (i >= 2)
                {
                    player_image[i].GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 0));
                }
            }
        }
    }



    private void CheckIncomingMessages(){
        if(GameType == GameConstants.ONLINE_MULTIPLAYER){
            if(messageToSend != MakeAMatch.chat_message){
                if (player2Message)
                {
                    if (Register.isSoundPlaying)
                    {
                        messageSource.Play();
                    }
                    player2Message = false;
                    player2MessageText.text = MakeAMatch.chat_message;
                    player2MessageBox.SetActive(true);
                    StartCoroutine(DisableChatBox(5, 2));

                }
                else if (player3Message)
                {
                    if (Register.isSoundPlaying)
                    {
                        messageSource.Play();
                    }
                    player3Message = false;
                    player3MessageText.text = MakeAMatch.chat_message;
                    player3MessageBox.SetActive(true);
                    StartCoroutine(DisableChatBox(5, 3));
                }
                else if (player4Message)
                {
                    if (Register.isSoundPlaying)
                    {
                        messageSource.Play();
                    }
                    player4Message = false;
                    player4MessageText.text = MakeAMatch.chat_message;
                    player4MessageBox.SetActive(true);
                    StartCoroutine(DisableChatBox(5, 4));
                }
            }

        }
    }


    IEnumerator DisableChatBox(float timer, int p_no){
        yield return new WaitForSeconds(timer);
        if (p_no == 2)
        {
            player2MessageBox.SetActive(false);
        }
        else if (p_no == 3)
        {
            player3MessageBox.SetActive(false);
        }
        else if (p_no == 4)
        {
            player4MessageBox.SetActive(false);
        }

    }



    public void DeativateGameObjects(){
        //DeactivateMarkers
        if(Game == GameConstants.SNAKES_AND_LADDER){
            for (int i = 0; i < 4; i++){
                for (int j = 1; j < 4; j++){
                    marker[i, j].SetActive(false);
                }
            }
            stop1.SetActive(false);
            stop2.SetActive(false);
            stop3.SetActive(false);
            stop4.SetActive(false);
        }

        if (GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            player1ProgressBox.enabled = false;
            player2ProgressBox.enabled = false;
            player3ProgressBox.enabled = false;
            player4ProgressBox.enabled = false;
        }
    }

    private void SetMarkersPosition(){
        if(Game == GameConstants.SNAKES_AND_LADDER){
            marker[0, 0].GetComponent<RectTransform>().localPosition = new Vector2(-120, -240);
            marker[1, 0].GetComponent<RectTransform>().localPosition = new Vector2(120, -240);
            marker[2, 0].GetComponent<RectTransform>().localPosition = new Vector2(120, 240);
            marker[3, 0].GetComponent<RectTransform>().localPosition = new Vector2(-120, 240);

            for (int i = 0; i < 4; i++)
            {
                GameObject markerPosition = GameObject.FindGameObjectWithTag(GameConstants.MARKER_POSITION[i, 0]);
                markerPosition.GetComponent<RectTransform>().localPosition = new Vector2(-355, -345);
            }
        }
    }



    private void ProgressBox(){
        if (NoOfPlayers == GameConstants.TWO_PLAYERS)
        {
            if (Game == GameConstants.LUDO_CHALLENGE)
            {
                if (GameController.playerTurn == 0)
                {
                    var p1 = player1ProgressBox.color;
                    var p3 = player3ProgressBox.color;
                    p1.a = 1f;
                    p3.a = 0f;
                    player1ProgressBox.color = p1;
                    player3ProgressBox.color = p3;
                    player1ProgressBox.fillAmount = fillAmount;
                }
                else
                {
                    var p1 = player1ProgressBox.color;
                    var p3 = player3ProgressBox.color;
                    p1.a = 0f;
                    p3.a = 1f;
                    player1ProgressBox.color = p1;
                    player3ProgressBox.color = p3;
                    player3ProgressBox.fillAmount = fillAmount;
                }
            }
            else
            {

                if (GameController.playerTurn == 0)
                {
                    var p1 = player1ProgressBox.color;
                    var p2 = player2ProgressBox.color;
                    p1.a = 1f;
                    p2.a = 0f;
                    player1ProgressBox.color = p1;
                    player2ProgressBox.color = p2;
                    player1ProgressBox.fillAmount = fillAmount;
                }
                else
                {
                    var p1 = player1ProgressBox.color;
                    var p2 = player2ProgressBox.color;
                    p1.a = 0f;
                    p2.a = 1f;
                    player1ProgressBox.color = p1;
                    player2ProgressBox.color = p2;
                    player2ProgressBox.fillAmount = fillAmount;
                }
            }
        }
        else{
            var p1 = player1ProgressBox.color;
            var p2 = player2ProgressBox.color;
            var p3 = player3ProgressBox.color;
            var p4 = player4ProgressBox.color;
            if (GameController.playerTurn == 0)
            {
                p1.a = 1f;
                p2.a = 0f;
                p3.a = 0f;
                p4.a = 0f;
                player1ProgressBox.color = p1;
                player2ProgressBox.color = p2;
                player3ProgressBox.color = p3;
                player4ProgressBox.color = p4;
                player1ProgressBox.fillAmount = fillAmount;
            }
            else if(GameController.playerTurn == 1)
            {
                p1.a = 0f;
                p2.a = 1f;
                p3.a = 0f;
                p4.a = 0f;
                player1ProgressBox.color = p1;
                player2ProgressBox.color = p2;
                player3ProgressBox.color = p3;
                player4ProgressBox.color = p4;
                player2ProgressBox.fillAmount = fillAmount;
            }
            else if (GameController.playerTurn == 2)
            {
                p1.a = 0f;
                p2.a = 0f;
                p3.a = 1f;
                p4.a = 0f;
                player1ProgressBox.color = p1;
                player2ProgressBox.color = p2;
                player3ProgressBox.color = p3;
                player4ProgressBox.color = p4;
                player3ProgressBox.fillAmount = fillAmount;
            }
            else if (GameController.playerTurn == 3)
            {
                p1.a = 0f;
                p2.a = 0f;
                p3.a = 0f;
                p4.a = 1f;
                player1ProgressBox.color = p1;
                player2ProgressBox.color = p2;
                player3ProgressBox.color = p3;
                player4ProgressBox.color = p4;
                player4ProgressBox.fillAmount = fillAmount;
            }
        }
    }

    public IEnumerator FillAmountDelay(float timer){
        yield return new WaitForSeconds(timer);
        fillAmount = fillAmount - (Time.deltaTime/20);

        progressBar_Cooroutine = true;

        if (fillAmount <= 0.4 && !isAlarming)
        {
            if (GameController.playerTurn == 0)
            {
                isAlarming = true;
                alarm.Play();
            }

        }

        if (fillAmount <= 0.085f)
        {
            alarm.Stop();
            fillAmount = 0.92f;
            if (GameController.playerTurn == 0)
            {
                isAlarming = false;
                ChangeTurn(0);
                int x = 0;
                Int32.TryParse(player1Points_text.text, out x);
                x--;
                player1Points_text.text = "" + x;
                if(x == 0){
                    messageToSend = "EndGame";
                    ChatSendBtn();
                }
                OnlineMultiplayer.SendValues(0, -1, 0, x, GameConstants.TWO_PLAYER_CHALLENGE_DATA_EVENT);
            }
        }
    }

    public void ChangeTurn(int r)
    {
        GameObject gameController = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
        if(r == 1){
            gameController.GetComponent<GameController>().dice = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[GameController.playerTurn]);
            gameController.GetComponent<GameController>().dice.GetComponent<Dice>().diceValue = -1;
        }
        GameController.playerTurn = gameManager.GetComponent<PlayerActivation>().ChangePlayer(GameController.playerTurn);
        gameController.GetComponent<GameController>().dice = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[GameController.playerTurn]);
        gameController.GetComponent<GameController>().checkLoop_AI_Dice = false;
        gameController.GetComponent<GameController>().checkLoop_AI_Marker = false;
        GameController.GAME_STATE = GameConstants.DICE_ROLL;
        Debug.Log("Player Turn: " + GameController.playerTurn);
    }

    public void OnBackPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitGame_canvas.enabled = true;
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


    private void CheckifSurvived_4PlayerMultiplayer()
    {
        if (player2_out && player3_out && player4_out)
        {
            player2_out = false;
            SetValues_YouWin();
        }
    }

}

