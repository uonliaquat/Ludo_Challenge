using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject dice;
    private GameObject marker;
    private int _diceValue;
    private int _temp_boxCount;
    private int _boxCount;
    private int _playingArea;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);
    }

    private void Start()
    {
        _temp_boxCount = -1;
    }

    public int ChooseBestMove(int playerTurn)
    {
        dice = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[playerTurn]);
        //Check if All Markers are closed and dice value is 6
        if (dice.GetComponent<Dice>().diceValue == 6)
        {
            bool checkLoop = false;
            for (int i = 0; i < 4; i++)
            {
                marker = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i];
                if (marker.GetComponent<Marker>().isOpen)
                {
                    checkLoop = true;
                }
            }
            if(!checkLoop){
                int randomMarker = Random.Range(0, 4);
                return randomMarker;
            }
        }

        //Check if Any of the user's marker is getting killed
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){
                _temp_boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().temp_boxCount;
                _boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount;
                _playingArea = gameManager.GetComponent<GameController>().playingArea[playerTurn, i];
                _diceValue = dice.GetComponent<Dice>().diceValue;


                for (int k = 0; k < _diceValue; k++)
                {
                    if (_boxCount != -1)
                    {
                        if (_temp_boxCount == -1)
                        {
                            _temp_boxCount = 1;
                        }
                        else{
                            _temp_boxCount++;
                        }
                    }
                    if (_temp_boxCount == 13)
                    {
                        _temp_boxCount = 0;
                        set_PlayingArea(playerTurn);
                    }
                }


                if(_temp_boxCount == gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount && 
                   _playingArea == gameManager.GetComponent<GameController>().playingArea[i, j] && playerTurn != i){
                    print(_temp_boxCount + " " + _playingArea + " " + playerTurn + "  " + i);
                    print("killed");
                    //getting killed;
                    return i;
                }
            }
        }


        //Check if Any of the Computers's marker can go to stop
        for (int i = 0; i < 4; i++){
            _temp_boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().temp_boxCount;
            _boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount;
            _playingArea = gameManager.GetComponent<GameController>().playingArea[playerTurn, i];
            _diceValue = dice.GetComponent<Dice>().diceValue;

            for (int k = 0; k < _diceValue; k++)
            {
                if (_boxCount != -1)
                {
                    if (_temp_boxCount == -1)
                    {
                        _temp_boxCount = 1;
                    }
                    else
                    {
                        _temp_boxCount++;
                    }
                }
                if (_temp_boxCount == 13)
                {
                    _temp_boxCount = 0;
                    set_PlayingArea(playerTurn);
                }
            }

            if(_temp_boxCount == 0 || _temp_boxCount == 8){
                print("stopped");
                return i;
            }

        }


        //Check if Any of Computer's marker can home
        for (int i = 0; i < 4; i++){
            _boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount;
            _diceValue = dice.GetComponent<Dice>().diceValue;
            if(_boxCount + _diceValue == 56){
                return i;
            }
        }

        //Check if diceValue is 6 and Computer can bring one more marker into game
        _diceValue = dice.GetComponent<Dice>().diceValue;
        if (_diceValue == 6)
        {
            for (int i = 0; i < 4; i++)
            {
                if((!gameManager.GetComponent<GameInitializer>().marker[playerTurn,i].GetComponent<Marker>().isOpen) &&
                   gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount == -1){
                    return i;
                }
            }
        }


        //Get Random Marker
        for (int i = 0; i < 4; i++){
            marker = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i];
            if(marker.GetComponent<Marker>().isOpen){
                return i;
            }
        }
        return -1;
    }



    public void set_PlayingArea(int playerTurn)
    {
        if (playerTurn == 0)
        {
            if (_playingArea == 0)
            {
                _playingArea = 3;
            }
            else if (_playingArea == 3 || _playingArea == 2)
            {
                _playingArea--;
            }
        }
        else if (playerTurn == 1)
        {
            if (_playingArea == 1)
            {
                _playingArea = 0;
            }
            else if (_playingArea == 0)
            {
                _playingArea = 3;
            }
            else if (_playingArea == 3)
            {
                _playingArea = 2;
            }
        }
        else if (playerTurn == 2)
        {
            if (_playingArea == 2 || _playingArea == 1)
            {
                _playingArea--;
            }
            else if (_playingArea == 0)
            {
                _playingArea = 3;
            }
        }
        else if (playerTurn == 3)
        {
            _playingArea--;
        }
    }

}
