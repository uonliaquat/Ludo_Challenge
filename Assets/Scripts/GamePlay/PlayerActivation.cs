using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivation : MonoBehaviour {


    private GameObject[] dice;
    private GameObject[,] marker;
    private GameObject[] arrow;
    private GameObject[] player;
    private GameObject gameManager;


    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

        dice = new GameObject[4];
        arrow = new GameObject[4];
        player = new GameObject[4];
        for (int i = 0; i < 4; i++){
            dice[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[i]);
            arrow[i] = GameObject.FindGameObjectWithTag(GameConstants.ARROW[i]);
            player[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER[i]);
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
        bool canMove = false;
        for (int i = 0; i < 4; i++)
        {
            if ((dice[playerNo].GetComponent<Dice>().diceValue + marker[playerNo, i].GetComponent<Marker>().boxCount <= 56 && marker[playerNo, i].GetComponent<Marker>().isOpen) ||
               dice[playerNo].GetComponent<Dice>().diceValue == 6 && (!marker[playerNo, i].GetComponent<Marker>().isOpen))
            {
                marker[playerNo, i].GetComponent<Marker>().canClick = true;
                startBlinkAnimation(marker[playerNo, i], playerNo);
                canMove = true;
            }
        }

        //set GAME_STATE if player cant move
        if (!canMove)
        {
            GameController.GAME_STATE = GameConstants.CHANGE_PLAYER;
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
        if (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER ||
            (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerNo == 0) ||
            (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER))
        {
            DeactivateAllGlow();
            player[playerNo].GetComponent<Animator>().SetBool(GameConstants.START_GLOWING, true);
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
            player[i].GetComponent<Animator>().SetBool(GameConstants.START_GLOWING, false);
        }
    }

    public void DeactivatePlayerMarkers(int playerNo){
        for (int i = 0; i < 4; i++){
            marker[playerNo, i].GetComponent<Marker>().canClick = false;
        }
    }
    public int ChangePlayer(int playerTurn){
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (marker[i, j].GetComponent<Marker>().markerKilled || marker[i, j].GetComponent<Marker>().markerHomed)
                {
                    marker[i,j].GetComponent<Marker>().markerKilled = false;
                    marker[i, j].GetComponent<Marker>().markerHomed = false;
                    ActivateDice(playerTurn);
                    ActivateArrows(playerTurn);
                    ActivateGlow(playerTurn);
                    return playerTurn;
                }
            }
        }
        if (dice[playerTurn].GetComponent<Dice>().diceValue != 6)
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
        ActivateDice(playerTurn);
        ActivateArrows(playerTurn);
        ActivateGlow(playerTurn);
        return playerTurn;
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
