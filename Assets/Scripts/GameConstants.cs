using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {

    public static string BOARD = "Board";
    public static string LUDO_CHALLENGE = "LudoChallenge";
    public static string SNAKES_AND_LADDER = "SnakesAndLadder";
    public static string LOCAL_MULTIPLAYER = "LocalMultiplayer";
    public static string PLAY_WITH_COMPUTER = "PlayWithComputer";
    public static string PLAY_WITH_FREINDS = "PlayWithFriends";
    public static string ONLINE_MULTIPLAYER = "OnlineMultiplayer";
    public static string DICE_ROLL = "DiceRoll";
    public static string MARKER_SELECT = "MarkerSelect";
    public static string MARKER_MOVE = "MarkerMove";
    public static string CHANGE_PLAYER = "ChangePlayer";
    public static string CHECK_WIN = "CheckWin";
    public static string GAME_MANAGER = "GameManager";
    public static string START_GLOWING = "startGlowing";
    public static string START_BLINKING = "startBlinking";
    public static string RED = "Red";
    public static string BLUE = "Blue";
    public static string YELLOW = "Yellow";
    public static string GREEN = "Green";
    public static int TWO_PLAYERS = 2;
    public static int THREE_PLAYERS = 3;
    public static int FOUR_PLAYERS = 4;
    public static int PLAYER_1 = 0;
    public static int PLAYER_2 = 1;
    public static int PLAYER_3 = 2;
    public static int PLAYER_4 = 3;
    public static string REGISTER_NAME = "RegisterName";
    public static string REGISTER_USERNAME = "RegisterUserName";
    public static string REGISTER_PASSWORD = "RegisterPasssword";
    public static string REGISTER_BUTTON = "RegisterButton";
    public static string LOGIN_USERNAME = "LoginUsername";
    public static string LOGIN_PASSWORD = "LoginPassword";
    public static string LOGIN_BUTTON = "LoginButton";
    public static string REGISTER_LOGIN_BUTTON = "RegisterLoginButton";
    public static string LOGIN_SCENE = "Login";
    public static string STARTMENU_SCENE = "Start Menu";
    public static string MAINMENU_SCENE = "Main Menu";
    public static string REGISTER_SCENE = "Register";
    public static string GAMEPLAY_SCENE = "GamePlay";
    public static string REGISTER_COUNTRY_PIC = "RegisterCountryPic";
    public static string REGISTER_COUNTRY_NAME = "RegisterCountryName";
    public static string STARTMENU_PLAY_BUTTON = "StartMenuPlayButton";
    public static string MAINMENU_ONLINE_MULTIPLAYER_BUTTON = "MainMenuOnlineMultiplayerButton";
    public static string MAINMENU_CANVAS_ONLINE_MULTIPLAYER = "MainMenuCanvasOnlineMultiplayer";
    public static string MAINMENU_CANVAS_MAIN = "MainMenuCanvasMain";
    public static string MAINMENU_CANVAS_ONLINE_MULTIPLAYER_2PLAYERS_BUTTON = "MainMenuCanvasOnlineMultiplayer2PlayersButton";
    public static string MAINMENU_CANVAS_ONLINE_MULTIPLAYER_4PLAYERS_BUTTON = "MainMenuCanvasOnlineMultiplayer4PlayersButton";
    public static string MAINMENU_CANVAS_2PLAYERS_ROOM = "MainMenuCanvas2PlayersRoom";
    public static string MAINMENU_CANVAS_4PLAYERS_ROOM = "MainMenuCanvas4PlayersRoom";
    public static string CANVAS_2PLAYERS_ROOM_COST100_BUTTON = "Canvas2PlayersRoomCost100Button";
    public static string CANVAS_2PLAYERS_ROOM_COST500_BUTTON = "Canvas2PlayersRoomCost500Button";
    public static string CANVAS_2PLAYERS_ROOM_COST5000_BUTTON = "Canvas2PlayersRoomCost5000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST25000_BUTTON = "Canvas2PlayersRoomCost25000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST50000_BUTTON = "Canvas2PlayersRoomCost50000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST100000_BUTTON = "Canvas2PlayersRoomCost100000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST250000_BUTTON = "Canvas2PlayersRoomCost250000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST500000_BUTTON = "Canvas2PlayersRoomCost500000Button";
    public static string CANVAS_2PLAYERS_ROOM_COST750000_BUTTON = "Canvas2PlayersRoomCost750000Button";

    public static string CANVAS_4PLAYERS_ROOM_COST100_BUTTON = "Canvas4PlayersRoomCost100Button";
    public static string CANVAS_4PLAYERS_ROOM_COST500_BUTTON = "Canvas4PlayersRoomCost500Button";
    public static string CANVAS_4PLAYERS_ROOM_COST5000_BUTTON = "Canvas4PlayersRoomCost5000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST25000_BUTTON = "Canvas4PlayersRoomCost25000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST50000_BUTTON = "Canvas4PlayersRoomCost50000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST100000_BUTTON = "Canvas4PlayersRoomCost100000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST250000_BUTTON = "Canvas4PlayersRoomCost250000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST500000_BUTTON = "Canvas4PlayersRoomCost500000Button";
    public static string CANVAS_4PLAYERS_ROOM_COST750000_BUTTON = "Canvas4PlayersRoomCost750000Button";

    public static string GAMEPLAY_PLAYER1_NAME = "GamePlayPlayer1Name";
    public static string GAMEPLAY_PLAYER2_NAME = "GamePlayPlayer2Name";
    public static string GAMEPLAY_PLAYER3_NAME = "GamePlayPlayer3Name";
    public static string GAMEPLAY_PLAYER4_NAME = "GamePlayPlayer4Name";
    public static string SEARCHING_FOR_PLAYER_CANVAS = "CanvasSearchingForPlayer";
    public static string SEARCHING_FOR_PLAYER_ANIM = "SearchingForPlayerAnim";
    public static string TWO_PLAYER_CHALLENGE_DATA_EVENT =  "2_PLAYER_CHALLENGE_DATA";
    public static string LOAD_TWO_PLAYER_CHALLENGE_DATA_EVENT = "LOAD_2_PLAYER_CHALLENGE_DATA";
    public static string YOUWON_CANVAS = "YouWonCanvas";
    public static string YOUWON_CANVAS_COINS_TEXT = "YouWonCanvasCoinsText";
    public static string YOUWON_CANVAS_WINS_TEXT = "YouWonCanvasWinsText";
    public static string YOUWON_CANVAS_LOSES_TEXT = "YouWonCanvasLosesText";
    public static string YOULOSE_CANVAS = "YouLoseCanvas";
    public static string YOULOSE_CANVAS_COINS_TEXT = "YouLoseCanvasCoinsText";
    public static string YOULOSE_CANVAS_WINS_TEXT = "YouLoseCanvasWinsText";
    public static string YOULOSE_CANVAS_LOSES_TEXT = "YouLoseCanvasLosesText";
    public static string ENDGAME_CANVAS = "EndGameCanvas";
    public static string ENDGAME_CANVAS_WINNER_TEXT = "EndGameWinnerText";
    public static string ENDGAME_CANVAS_CONGRATULATIONS_IMAGE = "EndGameCongratualtionsImage";
    public static string YOULOSE_CANVAS_WINNER_NAME = "YouLoseCanvasWinnerText";
    public static string GAMEPLAY_CANVAS_MAIN = "GamePlayCanvasMain";
    public static string STARTMENU_PROFILEBOX_BUTTON = "StartMenuProfileBoxButton";
    public static string SETTINGS_CANVAS = "SettingsCanvas";
    public static string SETTINGS_BUTTON = "SettingsButton";
    public static string STARTMENU_MAIN_CANVAS = "StartMenuCanvasMain";
    public static string SETTINGS_CANVAS_BACK_BUTTON = "SettingsCanvasBackButton";
    public static string SETTINGS_CANVAS_EDITPROFILE_BUTTON = "SettingsCanvasEditProfileButton";
    public static string EDITPROFILE_CANVAS = "EditProfileCanvas";
    public static string EDITPROFILE_CANVAS_BACK_BUTTON = "EditProfileCanvasBackButton";
    public static string EDITPROFILE_CANVAS_CONTINUE_BUTTON = "EditProfileCanvasContinueButton";
    public static string EDITPROFILE_CANVAS_DISPLAY_NAME = "EditProfileCanvasDisplayName";
    public static string EDITPROFILE_CANVAS_USERIMAGE_BUTTON = "EditProfileCanvasUserImageButton";
    public static string STARTMENU_DISPLAY_IMAGE = "StartMenuDisplayImage";
    public static string STARTMENU_DISPLAY_NAME = "StartMenuDisplayName";
    public static string STARTMENU_COUNTRY_NAME = "StartMenuCountryName";
    public static string STARTMENU_COUNTRY_IMAGE = "StartMenuCountryImage";
    public static string STARTMENU_NO_OF_COINS = "StartMenuNoOfCoins";
    public static string STARTMENU_STATS_CANVAS_DISPLAY_IMAGE = "StartMenuStatsCanvasDisplayImage";
    public static string STARTMENU_STATS_CANVAS_COUNTRY_IMAGE = "StartMenuStatsCanvasCountryImage";
    public static string STARTMENU_STATS_CANVAS_DISPLAY_NAME = "StartMenuStatsCanvasDisplayName";
    public static string STARTMENU_STATS_CANVAS_COUNTRY_NAME = "StartMenuStatsCanvasCountryName";
    public static string STARTMENU_STATS_CANVAS_NOOFCOINS = "StartMenuStatsCanvasNoOFCoins";
    public static string STARTMENU_STATS_CANVAS = "StatrMenuStatsCanvas";
    public static string STARTMENU_STATS_CANVAS_BACK_BUTTON = "StartMenuStatsCanvasBackButton";
    public static string STARTMENU_NOTENOUGHCOINS_CANVAS = "StartMenuNotEnoughCoinsCanvas";
    public static string STARTMENU_NOTENOUGHCOINS_CANVAS_GETMORECOINS_BUTTON = "StartMenuNotEnoughCoinsCanvasGetMoreCoinsButton";
    public static string STARTMENU_NOTENOUGHCOINS_CANVAS_PLAYANOTHERROOM_BUTTON = "StartMenuNotEnoughCoinsCanvasPlayAnotherRoomButton";
    public static string ROOM2PLAYERS_BACK_BUTTON = "Room2PlayersBackButton";
    public static string TWO_PLAYERS_MATCH_100 = "2_PLAYER_MCH_100";
    public static string TWO_PLAYERS_MATCH_500 = "2_PLAYER_MCH_500";
    public static string TWO_PLAYERS_MATCH_5000 = "2_PLAYER_MCH_5000";
    public static string TWO_PLAYERS_MATCH_25000 = "2_PLAYER_MCH_25000";
    public static string TWO_PLAYERS_MATCH_50000 = "2_PLAYER_MCH_50000";
    public static string TWO_PLAYERS_MATCH_100000 = "2_PLAYER_MCH_100000";
    public static string TWO_PLAYERS_MATCH_250000 = "2_PLAYER_MCH_250000";
    public static string TWO_PLAYERS_MATCH_500000 = "2_PLAYER_MCH_500000";
    public static string TWO_PLAYERS_MATCH_750000 = "2_PLAYER_MCH_750000";

    public static string FOUR_PLAYERS_MATCH_100 = "4_PLAYER_MCH_100";

    public static string MAINMENU_DISPLAY_IMAGE = "MainMenuDisplayImage";
    public static string MAINMENU_DISPLAY_NAME = "MainMenuDisplayName";
    public static string MAINMENU_COUNTRY_IMAGE = "MainMenuCountryImage";
    public static string MAINMENU_COUNTRY_NAME = "MainMenuCountryName";
    public static string MAINMENU_COINS = "MainMenuCoins";
    public static string MAINMENU_VSCOMPUTER_WINS = "MainMenuVsComputerWin";
    public static string MAINMENU_VSCOMPUTER_LOSES = "MainMenuVsComputerLose";
    public static string MAINMENU_VSMULTIPLAYER_WINS = "MainMenuVsMultiplayerWin";
    public static string MAINMENU_VSMULTIPLAYER_LOSES = "MainMenuVsMultiplayerLose";
    public static string MAINMENU_STATS_CANVAS_DISPLAY_IMAGE = "MainMenuStatsCanvasDisplayImage";
    public static string MAINMENU_STATS_CANVAS_DISPLAY_NAME = "MainMenuStatsCanvasDisplayName";
    public static string MAINMENU_STATS_CANVAS_COUNTRY_IMAGE = "MainMenuStatsCanvasCountryImage";
    public static string MAINMENU_STATS_CANVAS_COUNTRY_NAME = "MainMenuStatsCanvasCountryName";
    public static string MAINMENU_STATS_CANVAS_COINS = "MainMenuStatsCanvasCoins";
    public static string MAINMENU_STATS_CANVAS = "MainMenuCanvasStats";
    public static string MAINMENU_PROFILE_BOX_BUTTON = "MainMenuProfileBoxButton";
    public static string MAINMENU_STATS_CANVAS_BACK_BUTTON = "MainMenuCanvasStatsBackButton";
    public static string STARTMENU_VSCOMPUTER_WINS = "StartMenuvsComputerWin";
    public static string STARTMENU_VSCOMPUTER_LOSES = "StartMenuvsComputerLose";
    public static string STARTMENU_VSMULTIPLAYER_WINS = "StartMenuvsMultiplayerWin";
    public static string STARTMENU_VSMULTIPLAYER_LOSES = "StartMenuvsmultiplayerLose";
    public static string ONLINEMULTIPLAYER_CANVAS_BACK_BUTTON = "OnlineMultiplayerCanvasBackButton";
    public static string LOGIN_CREATEONE_BUTTON = "LoginCreateOneButton";
    public static string EXIT_CANVAS = "ExitCanvas";
    public static string EXIT_CANVAS_YES_BUTTON = "ExitCanvasYesButton";
    public static string EXIT_CANVAS_NO_BUTTON = "ExitCanvasNoButton";
    public static string EXIT_BUTTON = "ExitButton";
    public static string LOCAL_MULTIPLAYER_CANVAS = "LocalMultiplayerCanvas";
    public static string LOCAL_MULTIPLAYER_CANVAS_BACK_BUTTON = "LocalMultiplayerCanvasBackButton";
    public static string LOCAL_MULTIPLAYER_CANVAS_2PLAYERS_BUTTON = "LocalMultiplayerCanvas2PlayersButton";
    public static string LOCAL_MULTIPLAYER_CANVAS_3PLAYERS_BUTTON = "LocalMultiplayerCanvas3PlayersButton";
    public static string LOCAL_MULTIPLAYER_CANVAS_4PLAYERS_BUTTON = "LocalMultiplayerCanvas4PlayersButton";
    public static string LOCAL_MULTIPLAYER_BUTTON = "LocalMultiplayerButton";
    public static string SELECT_YOUR_COLOR_2PLAYERS_CANVAS = "SelectYouColor2PlayersCanvas";
    public static string SELECT_YOUR_COLOR_2PLAYERS_BACK_BUTTON = "SelectYouColor2PlayersBackButton";
    public static string SELECT_YOUR_COLOR_2PLAYERS_PLAY_BUTTON = "SelectYouColor2PlayersPlayButton";
    public static string SELECT_YOUR_COLOR_OPTION1_BUTTON = "SelectYouColorOption1Button";
    public static string SELECT_YOUR_COLOR_OPTION2_BUTTON = "SelectYouColorOption2Button";
    public static string SELECT_YOUR_COLOR_OPTION1_FIELDS = "SelectYourColorOption1Fields";
    public static string SELECT_YOUR_COLOR_OPTION2_FIELDS = "SelectYourColorOption2Fields";
    public static string SELECT_YOUR_COLOR_OPTION1_PLAYER1_NAME = "SelectYourColor2PlayersOption1Player1Name";
    public static string SELECT_YOUR_COLOR_OPTION1_PLAYER2_NAME = "SelectYourColor2PlayersOption1Player2Name";
    public static string SELECT_YOUR_COLOR_OPTION2_PLAYER1_NAME = "SelectYourColor2PlayersOption2Player1Name";
    public static string SELECT_YOUR_COLOR_OPTION2_PLAYER2_NAME = "SelectYourColor2PlayersOption2Player2Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_CANVAS = "SelectYourColor3PlayersCanvas";
    public static string SELECT_YOUR_COLOR_3PLAYERS_BACK_BUTTON = "SelectYourColor3PlayersBackButton";
    public static string SELECT_YOUR_COLOR_3PLAYERS_PLAY_BUTTON = "SelectYourColor3PlayersPlayButton";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION1_BUTTON = "SeelctYourColor3PlayersOption1Button";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION2_BUTTON = "SeelctYourColor3PlayersOption2Button";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION1_FIELDS = "SelectYourColor3PlayersOption1Fields";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION2_FIELDS = "SelectYourColor3PlayersOption2Fields";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER1_NAME = "SelectYourColor3PlayersOption1Player1Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER2_NAME = "SelectYourColor3PlayersOption1Player2Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION1_PLAYER3_NAME = "SelectYourColor3PlayersOption1Player3Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER1_NAME = "SelectYourColor3PlayersOption2Player1Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER2_NAME = "SelectYourColor3PlayersOption2Player2Name";
    public static string SELECT_YOUR_COLOR_3PLAYERS_OPTION2_PLAYER3_NAME = "SelectYourColor3PlayersOption2Player3Name";
    public static string SELECT_YOUR_COLOR_4PLAYERS_CANVAS = "SelectYourColor4PlayersCanvas";
    public static string SELECT_YOUR_COLOR_4PLAYERS_BACK_BUTTON = "SelectYourColor4PlayersCanvasBackButton";
    public static string SELECT_YOUR_COLOR_4PLAYERS_PLAY_BUTTON = "SelectYourColor4PlayersCanvasPlayButton";
    public static string SELECT_YOUR_COLOR_4PLAYERS_PLAYER1_NAME = "SelectYourColor4PlayersPlayer1Name";
    public static string SELECT_YOUR_COLOR_4PLAYERS_PLAYER2_NAME = "SelectYourColor4PlayersPlayer2Name";
    public static string SELECT_YOUR_COLOR_4PLAYERS_PLAYER3_NAME = "SelectYourColor4PlayersPlayer3Name";
    public static string SELECT_YOUR_COLOR_4PLAYERS_PLAYER4_NAME = "SelectYourColor4PlayersPlayer4Name";
    public static string PLAY_WITH_COMPUTER_CANVAS = "PlayWithComputerCanvas";
    public static string PLAY_WITH_COMPUTER_BUTTON = "PlayWithComputerButton";
    public static string PLAY_WITH_COMPUTER_BACK_BUTTON ="PlayWithComputerCanvasBackButton";
    public static string PLAY_WITH_COMPUTER_PLAY_BUTTON = "PlayWithComputerCanvasPlayButton";
    public static string PLAY_WITH_COMPUTER_BUTTON1 = "PlayWithComputerCanvasButton1";
    public static string PLAY_WITH_COMPUTER_BUTTON2 = "PlayWithComputerCanvasButton2";
    public static string PLAY_WITH_COMPUTER_BUTTON3 = "PlayWithComputerCanvasButton3";
    public static string PLAY_WITH_COMPUTER_BUTTON4 = "PlayWithComputerCanvasButton4";
    public static string MAINMENU_BACK_BUTTON = "MainMenuBackButton";
    public static string START_MENU_MANAGER = "StartMenuManager";
    public static string START_MENU_MESSAGE_BOX_CANVAS = "StartMenuMessageBoxCanvas";
    public static string START_MENU_MESSAGE_BOX_BUTTON = "StartMenuMessageBoxButton";
    public static string START_MENU_MESSAGE_BOX_TEXT = "StartMenuMessageBoxText";
    public static string YOUWON_BUTTON = "YouWonButton";
    public static string ENDGAME_BUTTON = "EndGameButton";
    public static string YOULOSE_BUTTON = "YouLoseButton";




    public static string[] PLAYER = new string[4] { "Player1", "Player2", "Player3", "Player4"};
    public static string[] ARROW = new string[4] {"Player1Arrow", "Player2Arrow", "Player3Arrow", "Player4Arrow"};
    public static string[] PLAYER_IMAGE = new string[4] { "Player1Pic", "Player2Pic", "Player3Pic", "Player4Pic"};
    public static string[] PLAYER_DICE = new string[4] { "Player1Dice", "Player2Dice", "Player3Dice", "Player4Dice" };

    public static string[,] MARKER = new string[4, 4] { 
        { "Player1Marker1", "Player1Marker2", "Player1Marker3", "Player1Marker4" },
        { "Player2Marker1", "Player2Marker2", "Player2Marker3", "Player2Marker4" },
        { "Player3Marker1", "Player3Marker2", "Player3Marker3", "Player3Marker4" },
        { "Player4Marker1", "Player4Marker2", "Player4Marker3", "Player4Marker4" }};
    
    public static string[,] MARKER_POSITION = new string[4, 4] { 
        {"Player1Marker1Position", "Player1Marker2Position", "Player1Marker3Position", "Player1Marker4Position"},
        {"Player2Marker1Position", "Player2Marker2Position", "Player2Marker3Position", "Player2Marker4Position"}, 
        {"Player3Marker1Position", "Player3Marker2Position", "Player3Marker3Position", "Player3Marker4Position"},
        {"Player4Marker1Position", "Player4Marker2Position", "Player4Marker3Position", "Player4Marker4Position"}
    };

    public static string[,] MARKER_HOME = new string[4, 4] {
        {"Player1Marker1Home", "Player1Marker2Home", "Player1Marker3Home", "Player1Marker4Home"},
        {"Player2Marker1Home", "Player2Marker2Home", "Player2Marker3Home", "Player2Marker4Home"},
        {"Player3Marker1Home", "Player3Marker2Home", "Player3Marker3Home", "Player3Marker4Home"},
        {"Player4Marker1Home", "Player4Marker2Home", "Player4Marker3Home", "Player4Marker4Home"}};

}
