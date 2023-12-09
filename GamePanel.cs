using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameResult
{
    Win,
    Fail
}

public class GamePanel : MonoBehaviour
{
    public Text resultText;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetPanel(GameResult result)
    {
        switch (result)
        {
            case GameResult.Win:
                resultText.text = "Win";
                break;
            default:
                resultText.text = "Fail";
                break;
        }
        
        gameObject.SetActive(true);
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Home");
    }
}
