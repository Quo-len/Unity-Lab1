using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static bool isPaused = true;
    public GameObject pauseMenuUI;

    private void Start()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = false;
    }

    public void UnpauseGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = true;
    }
   
}
