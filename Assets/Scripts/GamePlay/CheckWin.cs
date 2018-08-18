using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWin : MonoBehaviour {

    private GameObject gameManager;
    public static string playerWon;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
    }
    // Update is called once per frame
    void Update () {
        CheckMarkerHome();
	}

    private void Start()
    {
        playerWon = "None";
    }

    void CheckMarkerHome(){
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){
                if(gameManager.GetComponent<GameInitializer>().marker[i,j].GetComponent<Marker>().boxCount == 56){
                    gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().isOpen = false;
                    gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().markerHomed = true;
                    gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().boxCount++;
                    GameObject home_marker = GameObject.FindGameObjectWithTag(GameConstants.MARKER_HOME[i, j]);
                    home_marker.GetComponent<Image>().sprite = gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Image>().sprite;
                    Color color = home_marker.GetComponent<Image>().color;
                    color.a = 1f;
                    home_marker.GetComponent<Image>().color = color;
                    gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localScale = new Vector2(0, 0);
                }
            }
        }
    }


    public bool Check_Win(){
        bool[] win = new bool[4] {false, false, false, false };
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().boxCount == 57){
                    win[j] = true;
                }
            }
            if (win[0] && win[1] && win[2] && win[3])
            {
                if(GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER || 
                   (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && GameController.playerTurn == 0)){

                    if (GameInitializer.NoOfPlayers == GameConstants.TWO_PLAYERS)
                    {
                        if (i == 0)
                        {
                            playerWon = GameInitializer.Player1Name.text;
                        }
                        else
                        {
                            playerWon = GameInitializer.Player3Name.text;
                        }
                    }
                    else{
                        if (i == 0)
                        {
                            playerWon = GameInitializer.Player1Name.text;
                        }
                        else if(i == 1)
                        {
                            playerWon = GameInitializer.Player2Name.text;
                        }
                        else if (i == 2)
                        {
                            playerWon = GameInitializer.Player3Name.text;
                        }
                        else if (i == 3)
                        {
                            playerWon = GameInitializer.Player4Name.text;
                        }
                    }
                    playerWon = playerWon + " Won!";
                }
                else if(GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && GameController.playerTurn != 0){
                    playerWon = "Computer Won!";
                }
                else if(GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER){
                    if (GameController.playerTurn == 0)
                    {
                        playerWon = GameInitializer.Player1Name.text;
                    }
                    else if (GameController.playerTurn == 1)
                    {
                        playerWon = GameInitializer.Player2Name.text;
                    }
                    else if (GameController.playerTurn == 2)
                    {
                        playerWon = GameInitializer.Player3Name.text;
                    }
                    else if (GameController.playerTurn == 3)
                    {
                        playerWon = GameInitializer.Player4Name.text;
                    }
                }


                return true;
            }
        }
        return false;
    }
}
