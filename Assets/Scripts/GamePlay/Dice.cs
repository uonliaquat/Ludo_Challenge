using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dice : MonoBehaviour {

    public bool isClicked;
    public bool canClick;
    public int diceValue;
    private GameObject gameManager;
    public Sprite[] staticDice;

    private Text testInput;
    private Text testInputAI;

    private void Awake()
    {

        //for testing purpose
        testInput = GameObject.Find("Text").GetComponent<Text>();
        testInputAI = GameObject.Find("TextComputer").GetComponent<Text>();

        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);


        isClicked = false;
        canClick = false;
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canClick)
            {
                isClicked = true;
                canClick = false;
            }
        }
    }

    public void RollDice(){
        //for testing purpose
        gameManager.GetComponent<PlayerActivation>().DeactivateAllArrows();
        gameManager.GetComponent<PlayerActivation>().DeactivateAllGlow();

        if (GameController.playerTurn == 0)
        {
            string str = testInput.text;
            diceValue = Convert.ToInt32(str);
        }

        if (GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER &&
            GameController.playerTurn != 0)
        {
            diceValue = UnityEngine.Random.Range(1, 7);
        }
        else if(GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && GameController.playerTurn != 0){
            diceValue = OnlineMultiplayer.dice_value;
        }

        gameObject.GetComponent<Animator>().enabled = true;
        isClicked = false;

    }

    void StopRollingDice(){
        if ((GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && GameController.playerTurn != 0) ||
            (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && GameController.playerTurn != 0))
        {
            GameController.GAME_STATE = GameConstants.MARKER_SELECT;
        }
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = staticDice[diceValue - 1];
        gameManager.GetComponent<PlayerActivation>().ActivateMarkers(GameController.playerTurn);
    }
}
