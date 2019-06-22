using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivation : MonoBehaviour {


    private GameObject[] dice;
    private GameObject[,] marker;
    private GameObject[] arrow;
    private GameObject[] player;
    private GameObject[] player_glow;
    private GameObject gameManager;
    public static bool canMoveMarker = true;


    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

        dice = new GameObject[4];
        arrow = new GameObject[4];
        player = new GameObject[4];
        player_glow = new GameObject[4];
        for (int i = 0; i < 4; i++){
            dice[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[i]);
            arrow[i] = GameObject.FindGameObjectWithTag(GameConstants.ARROW[i]);
            player[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER[i]);
            player_glow[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_GLOW[i]);
        }

        marker = new GameObject[4, 4];
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){
                marker[i, j] = GameObject.FindGameObjectWithTag(GameConstants.MARKER[i, j]);
            }
        }

    }

    public void ActivateMarkers(int playerNo)
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){
                marker[i, j].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            canMoveMarker = false;
            bool canMove = false;
            int count = 0;
            int markerNo = -1;
            for (int i = 0; i < 4; i++)
            {
                if ((dice[playerNo].GetComponent<Dice>().diceValue + marker[playerNo, i].GetComponent<Marker>().boxCount <= 56 && marker[playerNo, i].GetComponent<Marker>().isOpen) ||
                    dice[playerNo].GetComponent<Dice>().diceValue == 6 && !(marker[playerNo, i].GetComponent<Marker>().isOpen) && marker[playerNo, i].GetComponent<Marker>().boxCount != 57)
                {
                    marker[playerNo, i].GetComponent<Marker>().canClick = true;
                    marker[playerNo, i].transform.parent.SetSiblingIndex(9);
                    marker[playerNo, i].GetComponent<BoxCollider2D>().enabled = true;
                    startBlinkAnimation(marker[playerNo, i], playerNo);
                    canMove = true;
                    count++;
                    markerNo = i;
                    temp.Add(i);
                    canMoveMarker = true;
                }
            }
            if (count == 1)
            {
                marker[playerNo, markerNo].GetComponent<Marker>().isClicked = true;
                marker[playerNo, markerNo].GetComponent<Marker>().isOpen = true;
                marker[playerNo, markerNo].GetComponent<Marker>().canClick = false;
                marker[playerNo, markerNo].GetComponent<Marker>().isMoving = true;
                marker[playerNo, markerNo].GetComponent<Marker>().isTranslating = true;
                marker[playerNo, markerNo].GetComponent<Marker>().markerKilled = false;
                marker[playerNo, markerNo].GetComponent<Marker>().ResetMarkersOnSameSpot();
            }
            else if (count == 2)
            {
                if (marker[playerNo, temp[0]].GetComponent<Marker>().boxCount == marker[playerNo, temp[1]].GetComponent<Marker>().boxCount)
                {
                    marker[playerNo, temp[0]].GetComponent<Marker>().isClicked = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isOpen = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().canClick = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isMoving = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isTranslating = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().markerKilled = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().ResetMarkersOnSameSpot();
                }
            }
            else if (count == 3)
            {
                if (marker[playerNo, temp[0]].GetComponent<Marker>().boxCount == marker[playerNo, temp[1]].GetComponent<Marker>().boxCount &&
                    marker[playerNo, temp[1]].GetComponent<Marker>().boxCount == marker[playerNo, temp[2]].GetComponent<Marker>().boxCount)
                {
                    marker[playerNo, temp[0]].GetComponent<Marker>().isClicked = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isOpen = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().canClick = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isMoving = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isTranslating = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().markerKilled = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().ResetMarkersOnSameSpot();
                }
            }
            else if (count == 4)
            {
                if (marker[playerNo, temp[0]].GetComponent<Marker>().boxCount == marker[playerNo, temp[1]].GetComponent<Marker>().boxCount &&
                    marker[playerNo, temp[1]].GetComponent<Marker>().boxCount == marker[playerNo, temp[2]].GetComponent<Marker>().boxCount &&
                    marker[playerNo, temp[2]].GetComponent<Marker>().boxCount == marker[playerNo, temp[3]].GetComponent<Marker>().boxCount)
                {
                    marker[playerNo, temp[0]].GetComponent<Marker>().isClicked = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isOpen = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().canClick = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isMoving = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().isTranslating = true;
                    marker[playerNo, temp[0]].GetComponent<Marker>().markerKilled = false;
                    marker[playerNo, temp[0]].GetComponent<Marker>().ResetMarkersOnSameSpot();
                }
            }


            //set GAME_STATE if player cant move
            if (!canMove)
            {
                GameController.GAME_STATE = GameConstants.CHANGE_PLAYER;
            }
        }
        else if (GameInitializer.Game == GameConstants.SNAKES_AND_LADDER)
        {
            //bool canMove = false;
            if ((dice[playerNo].GetComponent<Dice>().diceValue + marker[playerNo, 0].GetComponent<Marker>().boxCount <= 99 && marker[playerNo, 0].GetComponent<Marker>().isOpen) ||
                   dice[playerNo].GetComponent<Dice>().diceValue == 6 && (!marker[playerNo, 0].GetComponent<Marker>().isOpen))
            {
                marker[playerNo, 0].GetComponent<Marker>().canClick = true;
                //canMove = true;
            }
        }
    }

    public void ActivateDice(int playerNo)
    {
        if (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER ||
            (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerNo == 0) ||
            (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && playerNo == 0))
        {
            dice[playerNo].GetComponent<Dice>().canClick = true;
        }

    }

    public void ActivateArrows(int playerNo){
        if (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER ||
            (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerNo == 0) ||
            (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER))
        {
            DeactivateAllArrows();
            arrow[playerNo].SetActive(true);
        }
    }

    public void ActivateGlow(int playerNo){
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            if (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER ||
                (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerNo == 0) ||
                (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER))
            {
                DeactivateAllGlow();
                player_glow[playerNo].GetComponent<Animator>().SetBool(GameConstants.START_GLOWING, true);
            }
        }
    }


    public void DeactivateAllArrows(){
        for (int i = 0; i < 4; i++)
        {
            arrow[i].SetActive(false);
        }
    }
    public void DeactivatePlayerMarkersBlink(int playerNo){
        for (int i = 0; i < 4; i++){
            marker[playerNo, i].GetComponent<Animator>().SetBool(GameConstants.START_BLINKING, false);
        }
        DeactivatePlayerMarkers(playerNo);
    }

    public void DeactivateAllGlow(){
        for (int i = 0; i < 4; i++){
            player_glow[i].GetComponent<Animator>().SetBool(GameConstants.START_GLOWING, false);
        }
    }

    public void DeactivatePlayerMarkers(int playerNo){
        for (int i = 0; i < 4; i++){
            marker[playerNo, i].GetComponent<Marker>().canClick = false;
        }
    }
    public int ChangePlayer(int playerTurn)
    {
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (marker[i, j].GetComponent<Marker>().markerKilled || marker[i, j].GetComponent<Marker>().markerHomed)
                    {
                        marker[i, j].GetComponent<Marker>().markerKilled = false;
                        marker[i, j].GetComponent<Marker>().markerHomed = false;
                        ActivateDice(playerTurn);
                        ActivateArrows(playerTurn);
                        ActivateGlow(playerTurn);
                        return playerTurn;
                    }
                }
            }
            if (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS)
            {
                GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                if(dice[playerTurn].GetComponent<Dice>().diceValue == 6){
                    ActivateDice(playerTurn);
                    ActivateArrows(playerTurn);
                    ActivateGlow(playerTurn);
                    return playerTurn;
                }

                if (MakeAMatch.userId == OnlineMultiplayer.playerTurn_UserId)
                {
                    ActivateDice(0);
                    ActivateArrows(0);
                    ActivateGlow(0);
                    playerTurn = 0;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (MakeAMatch.playerIDs[i] == OnlineMultiplayer.playerTurn_UserId)
                        {
                            if (GameInitializer.Player2Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(1);
                                ActivateGlow(1);
                                playerTurn = 1;
                                return playerTurn;
                            }
                            else if (GameInitializer.Player3Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(2);
                                ActivateGlow(2);
                                playerTurn = 2;
                                return playerTurn;
                            }
                            else if (GameInitializer.Player4Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(3);
                                ActivateGlow(3);
                                playerTurn = 3;
                                return playerTurn;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                if (dice[playerTurn].GetComponent<Dice>().diceValue != 6 || (dice[playerTurn].GetComponent<Dice>().diceValue == 6 && !canMoveMarker))
                {
                    if (GameInitializer.NoOfPlayers == GameConstants.TWO_PLAYERS)
                    {
                        if (playerTurn == 0)
                        {
                            playerTurn = 2;
                        }
                        else if (playerTurn == 2)
                        {
                            playerTurn = 0;
                        }
                    }
                    else if (GameInitializer.NoOfPlayers == GameConstants.THREE_PLAYERS)
                    {
                        if (playerTurn == 0 || playerTurn == 1)
                        {
                            playerTurn++;
                        }
                        else
                        {
                            playerTurn = 0;
                        }
                    }
                    else if (GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS)
                    {
                        if (playerTurn == 0 || playerTurn == 1 || playerTurn == 2)
                        {
                            playerTurn++;
                        }
                        else
                        {
                            playerTurn = 0;
                        }
                    }
                }
            }
            ActivateDice(playerTurn);
            ActivateArrows(playerTurn);
            ActivateGlow(playerTurn);
            return playerTurn;
        }
        else
        {
            if (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS)
            {

                GameObject game_manager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
                if (dice[playerTurn].GetComponent<Dice>().diceValue == 6)
                {
                    ActivateDice(playerTurn);
                    ActivateArrows(playerTurn);
                    ActivateGlow(playerTurn);
                    return playerTurn;
                }

                if (MakeAMatch.userId == OnlineMultiplayer.playerTurn_UserId)
                {
                    ActivateDice(0);
                    ActivateArrows(0);
                    ActivateGlow(0);
                    playerTurn = 0;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (MakeAMatch.playerIDs[i] == OnlineMultiplayer.playerTurn_UserId)
                        {
                            if (GameInitializer.Player2Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(1);
                                ActivateGlow(1);
                                playerTurn = 1;
                                return playerTurn;
                            }
                            else if (GameInitializer.Player3Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(2);
                                ActivateGlow(2);
                                playerTurn = 2;
                                return playerTurn;
                            }
                            else if (GameInitializer.Player4Name.text == MakeAMatch.playerNames[i])
                            {
                                ActivateArrows(3);
                                ActivateGlow(3);
                                playerTurn = 3;
                                return playerTurn;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                if (dice[playerTurn].GetComponent<Dice>().diceValue != 6 || (dice[playerTurn].GetComponent<Dice>().diceValue == 6 && marker[playerTurn, 0].GetComponent<Marker>().boxCount > 94) ||
                    !canMoveMarker)
                {
                    if (GameInitializer.NoOfPlayers == GameConstants.TWO_PLAYERS)
                    {
                        if (playerTurn == 0)
                        {
                            playerTurn = 1;
                        }
                        else if (playerTurn == 1)
                        {
                            playerTurn = 0;
                        }
                    }
                    else if (GameInitializer.NoOfPlayers == GameConstants.THREE_PLAYERS)
                    {
                        if (playerTurn == 0 || playerTurn == 1)
                        {
                            playerTurn++;
                        }
                        else
                        {
                            playerTurn = 0;
                        }
                    }
                    else if (GameInitializer.NoOfPlayers == GameConstants.FOUR_PLAYERS)
                    {
                        if (playerTurn == 0 || playerTurn == 1 || playerTurn == 2)
                        {
                            playerTurn++;
                        }
                        else
                        {
                            playerTurn = 0;
                        }
                    }
                }
            }
            ActivateDice(playerTurn);
            ActivateArrows(playerTurn);
            ActivateGlow(playerTurn);
            return playerTurn;
        }
    }

    void startBlinkAnimation(GameObject _marker, int playerNo)
    {
        if (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER ||
            (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerNo == 0) ||
            (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && playerNo == 0))
        {
            _marker.GetComponent<Animator>().SetBool(GameConstants.START_BLINKING, true);
        }
    }

    void stopBlinkAniamtion(GameObject _marker){
            _marker.GetComponent<Animator>().SetBool(GameConstants.START_BLINKING, false);
    }
}
