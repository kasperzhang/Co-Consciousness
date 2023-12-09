using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void OnClickContinueButton()
    {
        gameObject.SetActive(false);

        GameManager.Instance.gameStatus = GameStatus.Run;
    }

    public void OnClickHomeButton()
    {
        gameObject.SetActive(false);

        SceneManager.LoadScene("Home");
    }
}
