using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public bool canClick;
    public bool isClicked;
    public int boxCount;
    public bool isOpen;
    private int X, Y;
    private int temp_diceValue;
    public bool isMoving;
    public bool isTranslating;
    public int noOfMarkersOnSameSpot;
    public int temp_boxCount;
    private bool movingBack;
    private bool isMarkerMoved;
    private bool checkLoop;
    public bool markerKilled;
    public bool markerHomed;
    private float starting_X, starting_Y;
    private Transform starting_transform;
    private GameObject gameManager;
    public GameObject targetPosition;
    private GameObject[] dice;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag(GameConstants.GAME_MANAGER);

        dice = new GameObject[4];
        for (int i = 0; i < 4; i++){
            dice[i] = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[i]);
        }

        isOpen = false;
        canClick = false;
        isClicked = false;
        isMoving = false;
        isTranslating = false;
        movingBack = false;
        isMarkerMoved = false;
        checkLoop = false;
        markerKilled = false;
        markerHomed = false;
        boxCount = -1;
        noOfMarkersOnSameSpot = 0;
        temp_boxCount = -1;

    }

    private void Start()
    {
        starting_transform = this.transform;
        starting_X = starting_transform.localPosition.x;
        starting_Y = starting_transform.localPosition.y;

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canClick)
            {
                isOpen = true;
                canClick = false;
                isClicked = true;
                isMoving = true;
                isTranslating = true;
                markerKilled = false;
                ResetMarkersOnSameSpot();
            }
        }
    }

    public void MoveMarker(int playerTurn, int markerNo)
    {
        if((GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerTurn != 0 && canClick) ||
           (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && playerTurn != 0 && canClick)){
            isOpen = true;
            canClick = false;
            isClicked = true;
            isMoving = true;
            isTranslating = true;
            ResetMarkersOnSameSpot();
        }

        targetPosition = GameObject.FindGameObjectWithTag(GameConstants.MARKER_POSITION[playerTurn, markerNo]);
        if (!isMarkerMoved)
        {
            if (isClicked)
            {
                for (int i = 0; i < dice[playerTurn].GetComponent<Dice>().diceValue; i++)
                {
                    if (boxCount != -1)
                    {
                        if (temp_boxCount == -1)
                        {
                            temp_boxCount = 1;
                        }else{
                            temp_boxCount++;
                        }
                    }
                    if (temp_boxCount == 13)
                    {
                        temp_boxCount = 0;
                        setPlayingArea(playerTurn, markerNo);
                    }
                }

                gameManager.GetComponent<PlayerActivation>().DeactivatePlayerMarkersBlink(playerTurn);
                boxCount++;
                SetXY(playerTurn);
                if (boxCount != 0)
                {
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                temp_diceValue = dice[playerTurn].GetComponent<Dice>().diceValue;
                temp_diceValue--;
                isClicked = false;

            }
            if (isTranslating)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, Time.deltaTime * 4f);
                isTranslating = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, Time.deltaTime * 2f);

            if (transform.position == targetPosition.transform.position)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, Time.deltaTime * 4f);
                isTranslating = true;
                if (temp_diceValue == 0 || boxCount == 0)
                {
                    isTranslating = false;
                    isMarkerMoved = true;
                    SetMarkersOnSameSpot(playerTurn, markerNo);
                    //KillCoin(playerTurn, markerNo);
                    //isMoving = false;
                    //isMarkerMoved = true;
                }
                else
                {
                    temp_diceValue--;
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
            }
        }
        if(isMarkerMoved){
            KillCoin(playerTurn, markerNo);
        }
    }

    public void setPlayingArea(int playerTurn, int markerNo){
        if (playerTurn == 0)
        {
            if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 0)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = 3;
            }
            else if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 3 ||
                     gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 2)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo]--;
            }
        }
        else if (playerTurn == 1)
        {
            if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 1)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = 0;
            }
            else if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 0)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = 3;
            }
            else if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 3)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = 2;
            }
        }
        else if (playerTurn == 2)
        {
            if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 2 ||
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 1)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo]--;
            }
            else if (gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] == 0)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = 3;
            }
        }
        else if (playerTurn == 3)
        {
            gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo]--;
        }
    }

    void SetMarkersOnSameSpot(int playerTurn, int markerNo)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<BoxCollider2D>().bounds.
                   Intersects(gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<BoxCollider2D>().bounds))
                {
                    if (playerTurn != i)
                    {
                        if (temp_boxCount == 0 || temp_boxCount == 8)
                        {
                            //set markers on same spot
                            gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition =
                                           new Vector2(gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.x - 7f,
                                                       gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.y + 7f);
                            noOfMarkersOnSameSpot++;
                        }
                    }
                    else if (playerTurn == i && markerNo != j)
                    {
                        //set markers on same spot
                        gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition =
                                       new Vector2(gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.x - 7f,
                                                   gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.y + 7f);
                        noOfMarkersOnSameSpot++;
                    }
                }
            }
        }
    }

    void KillCoin(int playerTurn, int markerNo)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount ==
                    gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount && playerTurn != i &&
                    gameManager.GetComponent<GameController>().playingArea[playerTurn,markerNo] == gameManager.GetComponent<GameController>().playingArea[i,j] &&
                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount != 0 &&
                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount != 8)
                {
                    checkLoop = true;
                    movingBack = true;

                    GameObject _targetPosiiton = GameObject.FindGameObjectWithTag(GameConstants.MARKER_POSITION[i, j]);
                    GameObject _marker = GameObject.FindGameObjectWithTag(GameConstants.MARKER[i, j]);

                    if (movingBack)
                    {
                        _marker.transform.position = Vector3.MoveTowards(_marker.transform.position, _targetPosiiton.transform.position, Time.deltaTime * 9f);

                    }
                    if (_marker.transform.position == _targetPosiiton.transform.position)
                    {
                        if (movingBack)
                        {
                            _targetPosiiton.transform.localPosition =
                                               new Vector2(_targetPosiiton.transform.localPosition.x - _marker.GetComponent<Marker>().X,
                                                           _targetPosiiton.transform.localPosition.y - _marker.GetComponent<Marker>().Y);
                        }
                        _marker.GetComponent<Marker>().boxCount--;
                        _marker.GetComponent<Marker>().SetXY(i);
                        if (_marker.GetComponent<Marker>().boxCount == 0)
                        {
                            _marker.transform.localPosition = new Vector2(_marker.GetComponent<Marker>().starting_X, _marker.GetComponent<Marker>().starting_Y);
                            movingBack = false;
                            checkLoop = false;
                            _marker.GetComponent<Marker>().isOpen = false;
                            _marker.GetComponent<Marker>().temp_boxCount = -1;
                            _marker.GetComponent<Marker>().noOfMarkersOnSameSpot = 0;
                            _marker.GetComponent<Marker>().boxCount = -1;
                            _marker.GetComponent<Marker>().markerKilled = true;
                             gameManager.GetComponent<GameController>().playingArea[i,j] = i;
                        }
                    }

                }
            }
        }

        if (!checkLoop)
        {
            isMoving = false;
            isMarkerMoved = false;
        }
    }

    public void ResetMarkersOnSameSpot()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().noOfMarkersOnSameSpot > noOfMarkersOnSameSpot &&
                   gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount == temp_boxCount)
                {
                    gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition =
                         new Vector2(gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition.x + 7f,
                                     gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition.y - 7f);
                }
            }
        }
        noOfMarkersOnSameSpot = 0;
    }


    void SetXY(int playerTurn)     {         if (boxCount >= 1 && boxCount <= 4 || boxCount >= 11 && boxCount <= 12 || boxCount >= 19 && boxCount <= 23 || boxCount >= 51 && boxCount <= 56)         {              if (playerTurn == GameConstants.PLAYER_1)             {                 X = 0; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = -53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = 0; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = 53; Y = 0;             }         }         else if (boxCount >= 6 && boxCount <= 10 || boxCount >= 39 && boxCount <= 43 || boxCount >= 50 && boxCount <= 50)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = -53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = 0; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = 53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = 0; Y = 53;             }          }         else if (boxCount >= 13 && boxCount <= 17 || boxCount >= 24 && boxCount <= 25 || boxCount >= 32 && boxCount <= 36)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = 53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = 0; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = -53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = 0; Y = -53;             }         }         else if (boxCount >= 26 && boxCount <= 30 || boxCount >= 37 && boxCount <= 38 || boxCount >= 45 && boxCount <= 49)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = 0; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = 53; Y = 0;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = 0; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = -53; Y = 0;             }         }         else if (boxCount == 18)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = 53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = -53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = -53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = 53; Y = -53;             }         }         else if (boxCount == 5)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = -53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = -53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = 53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = 53; Y = 53;             }         }         else if (boxCount == 31)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = 53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = 53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = -53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = -53; Y = -53;             }         }         else if (boxCount == 44)         {             if (playerTurn == GameConstants.PLAYER_1)             {                 X = -53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_2)             {                 X = 53; Y = -53;             }             else if (playerTurn == GameConstants.PLAYER_3)             {                 X = 53; Y = 53;             }             else if (playerTurn == GameConstants.PLAYER_4)             {                 X = -53; Y = 53;             }         }     } 
}
