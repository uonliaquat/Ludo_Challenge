using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{

    public static string Game;
    public static string PlayerColor;
    public static int NoOfPlayers;
    public static string GameType;


    private GameObject board;
    private GameObject[] player;
    private GameObject[] arrow;
    public GameObject[,] marker;
    private GameObject[] player_image;
    public Sprite[] ludoBoards;
    public Sprite[] glow;
    public Sprite[] markerSprite;
    private GameObject gameManager;
    public static Text Player1Name, Player2Name, Player3Name, Player4Name;
    private static Canvas YouWon, YouLose, EndGame, MainCanvas;
    private static Image congratualtionsImage;
    private static Text endGameWinnerText, youWonCoinsText;
    private GameObject startMenuManager;
    private Button youWon_btn, endGame_btn, youLose_btn;
    private bool isGameRunning;

    public Sprite default_pic;

    private void Awake()
    {

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
    }


    private void Update()
    {
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded)
            {
                startMenuManager.GetComponent<UploadAndRetieveProfilePic>().isOpponnetsImageDownloaded = false;
                SetOpponentsImage();
            }
        }
    }

    void SetBoard()
    {
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            switch (PlayerColor)
            {
                case "Red":
                    board.GetComponent<Image>().sprite = ludoBoards[0];
                    player[0].GetComponent<Image>().sprite = glow[0];
                    player[1].GetComponent<Image>().sprite = glow[1];
                    player[2].GetComponent<Image>().sprite = glow[2];
                    player[3].GetComponent<Image>().sprite = glow[3];
                    break;
                case "Blue":
                    board.GetComponent<Image>().sprite = ludoBoards[1];
                    player[0].GetComponent<Image>().sprite = glow[1];
                    player[1].GetComponent<Image>().sprite = glow[2];
                    player[2].GetComponent<Image>().sprite = glow[3];
                    player[3].GetComponent<Image>().sprite = glow[0];
                    break;
                case "Yellow":
                    board.GetComponent<Image>().sprite = ludoBoards[2];
                    player[0].GetComponent<Image>().sprite = glow[2];
                    player[1].GetComponent<Image>().sprite = glow[3];
                    player[2].GetComponent<Image>().sprite = glow[0];
                    player[3].GetComponent<Image>().sprite = glow[1];
                    break;
                case "Green":
                    board.GetComponent<Image>().sprite = ludoBoards[3];
                    player[0].GetComponent<Image>().sprite = glow[3];
                    player[1].GetComponent<Image>().sprite = glow[0];
                    player[2].GetComponent<Image>().sprite = glow[1];
                    player[3].GetComponent<Image>().sprite = glow[2];
                    break;
            }
        }
    }

    void SetPlayerImage()
    {
        SetImageSize();
        if (Game == GameConstants.LUDO_CHALLENGE)
        {
            if (GameType == GameConstants.LOCAL_MULTIPLAYER || GameType == GameConstants.PLAY_WITH_COMPUTER)
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
            else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
            {

                if (NoOfPlayers == GameConstants.TWO_PLAYERS)
                {
                    if (PlayerPrefs.HasKey(Register.userId + "displayImage"))
                    {
                        player_image[0].GetComponent<Image>().sprite = Database.GetPlayerDisplayImage(StartMenu.texture);
                    }
                    else
                    {
                        player_image[0].GetComponent<Image>().sprite = default_pic;
                    }

                    if (MakeAMatch.opponents_image_id != null && MakeAMatch.opponents_image_id != "0")
                    {
                        startMenuManager.GetComponent<UploadAndRetieveProfilePic>().DownloadDisplayImage(MakeAMatch.opponents_image_id);
                    }
                    else
                    {
                        player_image[2].GetComponent<Image>().sprite = default_pic;
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
            else if(NoOfPlayers == 4){
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
                            if(Player2Name.text == MakeAMatch.playerNames[i]){
                                gameManager.GetComponent<PlayerActivation>().ActivateGlow(1);
                                gameManager.GetComponent<PlayerActivation>().ActivateArrows(1);
                                GameController.playerTurn = 1;
                            }
                            else if(Player3Name.text == MakeAMatch.playerNames[i]){
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
        if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            Player1Name.text = MakeAMatch.displayName;
            if (NoOfPlayers == 2)
            {

                if (NoOfPlayers == 2)
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
            }
        }
    }


    public static void EndGameMethod()
    {
        MainCanvas.GetComponent<CanvasGroup>().interactable = false;
        if (GameType == GameConstants.LOCAL_MULTIPLAYER)
        {
            congratualtionsImage.enabled = true;
            endGameWinnerText.text = CheckWin.playerWon;
            EndGame.enabled = true;

        }
        else if (GameType == GameConstants.PLAY_WITH_COMPUTER)
        {
            congratualtionsImage.enabled = false;
            endGameWinnerText.text = CheckWin.playerWon;
            EndGame.enabled = true;

            if (GameController.playerTurn == 0)
            {
                Database.setVsComputerWins(Register.userId);
            }
            else
            {
                Database.setVsComputerLoses(Register.userId);
            }
        }
        else if (GameType == GameConstants.ONLINE_MULTIPLAYER)
        {
            if (CheckWin.playerWon == MakeAMatch.displayName)
            {
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

                YouWon.enabled = true;
                Database.setVsMultiplayerWins(Register.userId);

            }
            else
            {
                YouLose.enabled = true;
                Database.setVsMultiplayerLoses(Register.userId);

            }
        }
        else if (GameType == GameConstants.PLAY_WITH_FREINDS)
        {

        }
    }

    public void BackToMenu()
    {
        MainCanvas.GetComponent<CanvasGroup>().interactable = true;
        YouWon.enabled = false;
        YouLose.enabled = false;
        EndGame.enabled = false;

        //Change Scene
        SceneManager.LoadScene(GameConstants.STARTMENU_SCENE);
    }


    public void SetOpponentsImage()
    {

        if (NoOfPlayers == 2)
        {
            Rect rec = new Rect(0, 0, startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.width,
            startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage.height);
            player_image[2].GetComponent<Image>().sprite =
            Sprite.Create(startMenuManager.GetComponent<UploadAndRetieveProfilePic>().downloadedImage, rec, new Vector2(0.5f, 0.5f), 100);
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



}

