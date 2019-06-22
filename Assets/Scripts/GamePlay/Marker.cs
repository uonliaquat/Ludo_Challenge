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
    private bool check = false;
    private bool isDone = false;
    private bool sal_markerStartCheck;
    private bool playingAreaChecked;
    private int _playerTurn;
    public bool markerPassed;

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
        sal_markerStartCheck = false;
        playingAreaChecked = false;
        markerPassed = true;
        boxCount = -1;
        noOfMarkersOnSameSpot = 0;
        temp_boxCount = -1;

    }

    private void Update()
    {
        if (!playingAreaChecked && boxCount >= 51 && GameInitializer.Game == GameConstants.LUDO_CHALLENGE){
            playingAreaChecked = true;
            string markerName = gameObject.name;
            char markerNo_str = markerName[markerName.Length - 1];
            int markerNo = System.Convert.ToInt32(new string(markerNo_str, 1));
            markerNo--;
            setPlayingArea(_playerTurn, markerNo);
        }
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
                if (!isOpen)
                {
                    temp_boxCount = 0;
                }
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
        _playerTurn = playerTurn;
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            if ((GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && playerTurn != 0 && canClick) ||
               (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && playerTurn != 0 && canClick))
            {
                if (!isOpen)
                {
                    temp_boxCount = 0;
                    markerPassed = false;
                }
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
                            }
                            else
                            {
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
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, Time.deltaTime * 1.5f);

                if (transform.position == targetPosition.transform.position)
                {
                    if (Register.isSoundPlaying)
                    {
                        gameManager.GetComponent<GameInitializer>().markerSource.Play();
                    }
                    //playMarkerSound = true;
                    transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, Time.deltaTime * 4f);
                    isTranslating = true;
                    if (temp_diceValue == 0 || boxCount == 0)
                    {
                        isTranslating = false;
                        isMarkerMoved = true;
                        SetMarkersOnSameSpot(playerTurn, markerNo);
                        if(Register.isSoundPlaying && GameInitializer.Game == GameConstants.LUDO_CHALLENGE){
                            if(boxCount == 0 || boxCount == 8){
                                gameManager.GetComponent<GameInitializer>().diceSix.Play();
                            }
                        }
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
            if (isMarkerMoved)
            {
                KillCoin(playerTurn, markerNo);
            }
        }
        else
        {
            if (dice[GameController.playerTurn].GetComponent<Dice>().diceValue == 6 && !sal_markerStartCheck)
            {
                sal_markerStartCheck = true;
                isMoving = false;
                return;

            }
            if ((GameInitializer.GameType == GameConstants.PLAY_WITH_COMPUTER && canClick) ||
               (GameInitializer.GameType == GameConstants.ONLINE_MULTIPLAYER && canClick) ||
                (GameInitializer.GameType == GameConstants.LOCAL_MULTIPLAYER && canClick))
            {
                isOpen = true;
                canClick = false;
                isClicked = true;
                isMoving = true;
                isTranslating = true;
                ResetMarkersOnSameSpot();
            }
            targetPosition = GameObject.FindGameObjectWithTag(GameConstants.MARKER_POSITION[playerTurn, 0]);
            if (!isMarkerMoved)
            {
                if (isMoving)
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
                                }
                                else
                                {
                                    temp_boxCount++;
                                }
                            }
                            if (temp_boxCount == 13)
                            {
                                temp_boxCount = 0;
                            }
                        }

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
                        if (Register.isSoundPlaying)
                        {
                            gameManager.GetComponent<GameInitializer>().markerSource.Play();
                        }
                        //playMarkerSound = true;
                        transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, Time.deltaTime * 4f);
                        isTranslating = true;
                        if (temp_diceValue == 0)
                        {
                            isTranslating = false;
                            isMarkerMoved = true;
                            //SetMarkersOnSameSpot(playerTurn, 0);
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
            }
            if(isMarkerMoved){
                SNAKES_AND_LADDERS(playerTurn, 0);
            }
        }
    }

    private void SNAKES_AND_LADDERS(int playerTurn, int markerNo)
    {
        GameObject temp_dice = GameObject.FindGameObjectWithTag(GameConstants.PLAYER_DICE[playerTurn]);
        if (GameInitializer.Game == GameConstants.SNAKES_AND_LADDER)
        {
            if (boxCount == 0)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 37; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 3)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 10; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 8)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 22; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 50)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 16; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 70)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 20; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 79)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 20; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 61)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 43; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if(temp_dice.GetComponent<Dice>().diceValue == 6){
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }

                isDone = true;
            }
            else if (boxCount == 27)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 56; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                    boxCount++;
                }
                isDone = true;
            }
            else if (boxCount == 92)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 20; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 86)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 63; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 53)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 20; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 20)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerClear.Play();
                }
                check = true;
                for (int i = 0; i < 21; i++)
                {
                    boxCount++;
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x + X, targetPosition.transform.localPosition.y + Y);
                }
                isDone = true;
            }
            else if (boxCount == 63)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 4; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 94)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 20; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 97)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 19; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            else if (boxCount == 16)
            {
                if (Register.isSoundPlaying)
                {
                    gameManager.GetComponent<GameInitializer>().markerKill.Play();
                }
                check = true;
                for (int i = 0; i < 10; i++)
                {
                    SetXY(playerTurn);
                    targetPosition.transform.localPosition = new Vector2(targetPosition.transform.localPosition.x - X, targetPosition.transform.localPosition.y - Y);
                    boxCount--;
                }
                if (temp_dice.GetComponent<Dice>().diceValue == 6)
                {
                    PlayerActivation.canMoveMarker = false;
                    gameManager.GetComponent<PlayerActivation>().ChangePlayer(playerTurn);
                }
                isDone = true;
            }
            if (isDone)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, Time.deltaTime * 3f);
                if (transform.position == targetPosition.transform.position)
                {
                    check = false;
                }
            }

        }
        if(!check){
            isMoving = false;
            isMarkerMoved = false;
            SetMarkersOnSameSpot(playerTurn, markerNo);
        }
    }

    public void setPlayingArea(int playerTurn, int markerNo){
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().boxCount >= 51)
            {
                gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo] = ((playerTurn + markerNo) * markerNo) + (Random.Range(1, 10000));
                Debug.Log(gameManager.GetComponent<GameController>().playingArea[playerTurn, markerNo]);
                return;
            }
        }
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
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<BoxCollider2D>().bounds.
                        Intersects(gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<BoxCollider2D>().bounds))
                    {
                        if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount ==
                            gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount)
                        {
                            if (playerTurn != i)
                            {
                                if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount == 0 || 
                                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount == 8)
                                {
                                    //set markers on same spot
                                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition =
                                                   new Vector2(gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.x - 7f,
                                                               gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.y + 7f);
                                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.SetSiblingIndex(0);
                                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().noOfMarkersOnSameSpot++;
                                    //noOfMarkersOnSameSpot++;
                                }
                            }
                            else if (playerTurn == i && markerNo != j)
                            {
                                //set markers on same spot
                                gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition =
                                               new Vector2(gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.x - 7f,
                                                           gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.y + 7f);
                                gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.SetSiblingIndex(0);
                                gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().noOfMarkersOnSameSpot++;
                                //noOfMarkersOnSameSpot++;
                            }
                        }
                    }
                }
            }
        }
        else if (GameInitializer.Game == GameConstants.SNAKES_AND_LADDER)
        {
            for (int i = 0; i < 4; i++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[playerTurn, 0].GetComponent<BoxCollider2D>().bounds.
                   Intersects(gameManager.GetComponent<GameInitializer>().marker[i, 0].GetComponent<BoxCollider2D>().bounds))
                {
                    if (playerTurn != i)
                    {
                        //set markers on same spot
                        gameManager.GetComponent<GameInitializer>().marker[playerTurn, 0].transform.localPosition =
                                       new Vector2(gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.x - 7f,
                                                   gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.localPosition.y + 7f);
                        gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].transform.SetSiblingIndex(0);
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
                    gameManager.GetComponent<GameInitializer>().marker[playerTurn, markerNo].GetComponent<Marker>().temp_boxCount != 8 &&
                    !(gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().boxCount >= 51))
                {
                    checkLoop = true;
                    movingBack = true;

                    if (Register.isSoundPlaying)
                    {
                        if (!gameManager.GetComponent<GameInitializer>().markerKill.isPlaying)
                        {
                            gameManager.GetComponent<GameInitializer>().markerKill.Play();
                        }
                    }
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
                            _marker.GetComponent<Marker>().markerPassed = true;
                             gameManager.GetComponent<GameController>().playingArea[i,j] = i;
                            gameManager.GetComponent<GameInitializer>().markerKill.Stop();
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
      
        string markerName = gameObject.name;
        char markerNo_str = markerName[markerName.Length - 1];
        int markerNo = System.Convert.ToInt32(new string(markerNo_str, 1));
        markerNo--;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (gameManager.GetComponent<GameInitializer>().marker[GameController.playerTurn, markerNo].GetComponent<BoxCollider2D>().bounds.
                    Intersects(gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<BoxCollider2D>().bounds))
                {
                    if ((GameController.playerTurn == i && markerNo != j) || (GameController.playerTurn != i))
                    {

                        if (gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().noOfMarkersOnSameSpot > noOfMarkersOnSameSpot &&
                            gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().temp_boxCount == temp_boxCount &&
                            gameManager.GetComponent<GameController>().playingArea[i, j] == gameManager.GetComponent<GameController>().playingArea[GameController.playerTurn, markerNo])
                        {
                            gameManager.GetComponent<GameInitializer>().marker[i, j].GetComponent<Marker>().noOfMarkersOnSameSpot--;
                            gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition =
                                 new Vector2(gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition.x + 7f,
                                             gameManager.GetComponent<GameInitializer>().marker[i, j].transform.localPosition.y - 7f);
                        }
                    }
                }
            }
        }
        gameManager.GetComponent<GameInitializer>().marker[GameController.playerTurn, markerNo].GetComponent<Marker>().noOfMarkersOnSameSpot = 0;
    }



    void SetXY(int playerTurn)     {
        if (GameInitializer.Game == GameConstants.LUDO_CHALLENGE)
        {
            if (boxCount >= 1 && boxCount <= 4 || boxCount >= 11 && boxCount <= 12 || boxCount >= 19 && boxCount <= 23 || boxCount >= 51 && boxCount <= 56)
            {

                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = 0; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = -53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = 0; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = 53; Y = 0;
                }
            }
            else if (boxCount >= 6 && boxCount <= 10 || boxCount >= 39 && boxCount <= 43 || boxCount >= 50 && boxCount <= 50)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = -53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = 0; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = 53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = 0; Y = 53;
                }

            }
            else if (boxCount >= 13 && boxCount <= 17 || boxCount >= 24 && boxCount <= 25 || boxCount >= 32 && boxCount <= 36)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = 53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = 0; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = -53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = 0; Y = -53;
                }
            }
            else if (boxCount >= 26 && boxCount <= 30 || boxCount >= 37 && boxCount <= 38 || boxCount >= 45 && boxCount <= 49)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = 0; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = 53; Y = 0;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = 0; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = -53; Y = 0;
                }
            }
            else if (boxCount == 18)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = 53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = -53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = -53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = 53; Y = -53;
                }
            }
            else if (boxCount == 5)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = -53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = -53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = 53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = 53; Y = 53;
                }
            }
            else if (boxCount == 31)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = 53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = 53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = -53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = -53; Y = -53;
                }
            }
            else if (boxCount == 44)
            {
                if (playerTurn == GameConstants.PLAYER_1)
                {
                    X = -53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_2)
                {
                    X = 53; Y = -53;
                }
                else if (playerTurn == GameConstants.PLAYER_3)
                {
                    X = 53; Y = 53;
                }
                else if (playerTurn == GameConstants.PLAYER_4)
                {
                    X = -53; Y = 53;
                }
            }
        }

        else
        {
            if(boxCount >= 1 && boxCount <= 9 || boxCount >= 21 && boxCount <= 29 || boxCount >= 41 && boxCount <= 49 || boxCount >= 61 && boxCount <= 69 
               || boxCount >= 81 && boxCount <= 89){
                X = 80; Y = 0;
            }
            else if(boxCount == 10 || boxCount == 20 || boxCount == 30 || boxCount == 40 || boxCount == 50 || boxCount == 60 || boxCount == 70 || boxCount == 80 ||
                    boxCount == 90){
                X = 0; Y = 80;
            }
            else if(boxCount >= 11 && boxCount <= 19 || boxCount >= 31 && boxCount <= 39 || boxCount >= 51 && boxCount <= 59 || boxCount >= 71 && boxCount <= 79 ||
                    boxCount >= 91 && boxCount <= 99){
                X = -80; Y = 0;
            }

        }
    }
 
}
