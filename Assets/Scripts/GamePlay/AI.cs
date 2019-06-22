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
        Debug.Log("Computert Dice Value: " + dice.GetComponent<Dice>().diceValue);
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
            for (int j = 0; j < 4; j++)
            {
                if (GameInitializer.NoOfPlayers == 2 && i > 0)
                {
                    break;
                }
                _temp_boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, j].GetComponent<Marker>().temp_boxCount;
                _boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, j].GetComponent<Marker>().boxCount;
                _playingArea = gameManager.GetComponent<GameController>().playingArea[playerTurn, j];
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

                if (j != playerTurn)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (_temp_boxCount == gameManager.GetComponent<GameInitializer>().marker[j, k].GetComponent<Marker>().temp_boxCount &&
                            _playingArea == gameManager.GetComponent<GameController>().playingArea[j, k] && playerTurn != i)
                        {
                            Debug.Log("Computer TempBoxCount: " + _temp_boxCount + "    Player TempBoxCount: " + gameManager.GetComponent<GameInitializer>().marker[j, k].GetComponent<Marker>().temp_boxCount);
                            Debug.Log("Computer Marker: " + j + "    Player Marker: " + k);
                            print("Oppennt Marker killed!");
                            return j;
                        }
                    }
                }

            }
        }

        //Check if any of computer marker is getting killed
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (GameInitializer.NoOfPlayers == 2 && i > 0)
                {
                    break;
                }
                _temp_boxCount = gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount;
                _boxCount = gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().boxCount;
                _playingArea = gameManager.GetComponent<GameController>().playingArea[i, j];
                for (int l = 0; l < 5; l++)
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
                        setPlayingArea();
                    }
                    //Debug.Log("PlayerNo: " + i + " MarkerNo: " + j + "TempBoxCount: " + _temp_boxCount + " Playing Area: " + _playingArea);
                    for (int k = 0; k < 4; k++)
                    {
                        if (_temp_boxCount == gameManager.GetComponent<GameInitializer>().marker[playerTurn, k].GetComponent<Marker>().temp_boxCount &&
                            _playingArea == gameManager.GetComponent<GameController>().playingArea[playerTurn, k] && _temp_boxCount != 0 && _temp_boxCount != 8 &&
                            playerTurn != i)
                        {
                            Debug.Log("Computer TempBoxCount: " + gameManager.GetComponent<GameInitializer>().marker[j, k].GetComponent<Marker>().temp_boxCount + "    Player TempBoxCount: " + _temp_boxCount);
                            Debug.Log("Computer Marker: " + k + "    Player Marker: " + i);
                            print("Getting killed!");
                            return k;
                        }
                    }
                }
            }
        }


        //Check if Any of the Computers's marker can go to stop
        for (int i = 0; i < 4; i++){
            _temp_boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().temp_boxCount;
            _boxCount = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount;
            _playingArea = gameManager.GetComponent<GameController>().playingArea[playerTurn, i];
            _diceValue = dice.GetComponent<Dice>().diceValue;
            if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().isOpen || _diceValue == 6)
            {
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

                if (_temp_boxCount == 0 || _temp_boxCount == 8)
                {
                    print("stopped");
                    return i;
                }
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
                if((gameManager.GetComponent<GameInitializer>().marker[playerTurn,i].GetComponent<Marker>().isOpen == false) &&
                   gameManager.GetComponent<GameInitializer>().marker[playerTurn, i].GetComponent<Marker>().boxCount == -1){
                    Debug.Log("Returning 6");
                    return i;
                }
            }
        }


        //Get Random Marker
        List<int> random_list = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            marker = gameManager.GetComponent<GameInitializer>().marker[playerTurn, i];
            if (dice.GetComponent<Dice>().diceValue + marker.GetComponent<Marker>().boxCount <= 56 && marker.GetComponent<Marker>().isOpen 
                && marker.GetComponent<Marker>().markerPassed == false)
            {
                random_list.Add(i);
                Debug.Log("Random Add: " + i);
            }
            if(i == 3){
                if (random_list.Count > 0)
                {
                    int random = Random.Range(0, random_list.Count);
                    random = random_list[random];
                    Debug.Log("Returning Random " + random);
                    return random;
                }
            }
        }
        Debug.Log("Returning -1");
        return -1;
        //while (random_list.Count > 0)
        //{
        //    int random = Random.Range(random_list[0], random_list.Count);
        //    marker = gameManager.GetComponent<GameInitializer>().marker[playerTurn, random];
        //    if ((_diceValue + marker.GetComponent<Marker>().boxCount <= 56 && marker.GetComponent<Marker>().isOpen))
        //    {
        //        random_list.Clear();
        //        return random;
        //    }
        //    else
        //    {
        //        random_list.RemoveAt(random);
        //    }
        //}
        //return -1;
    }




    public void setPlayingArea()
    {
        if (_playingArea == 0)
        {
            _playingArea = 3;
        }
        else if (_playingArea == 3 || _playingArea == 2)
        {
            _playingArea--;
        }
        else if(_playingArea == 1){
            _playingArea = 0;
        }
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
