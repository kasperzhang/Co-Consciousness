using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Pause,
    Run,
    Over
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CameraController cameraController;
    public Player player1;
    public Player player2;
    public GamePanel gamePanel;
    public PausePanel pausePanel;
    public GameStatus gameStatus;

    private int _exitNum = 0;

    private void Awake()
    {
        Instance = this;

        gameStatus = GameStatus.Run;
    }

    private void Update()
    {
        if (gameStatus != GameStatus.Run)
            return;

        Pause();

        ShiftReplace();
    }

    private void Pause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameStatus = GameStatus.Pause;
            
            pausePanel.OpenPanel();
        }
    }

    private void ShiftReplace()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            (player1.transform.position, player2.transform.position) = (player2.transform.position, player1.transform.position);
        }
    }

    public void SetCameraMove(bool isMove)
    {
        cameraController.isMove = isMove;
    }

    public void SetExit(int value)
    {
        _exitNum += value;

        if (_exitNum >= 2)
        {
            gameStatus = GameStatus.Over;

            gamePanel.SetPanel(GameResult.Win);
        }
    }
}
