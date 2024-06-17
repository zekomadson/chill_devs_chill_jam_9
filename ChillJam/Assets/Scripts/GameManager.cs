using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public static bool isPaused = false;

    void Awake()
    {
        // Hide Pause Menu on Start
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void StartGame()
    {
        // Load Scene Called: Main
        string gameSceneName = "Game";
        SceneManager.LoadScene(gameSceneName);

        // Hide Pause Menu on Start
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        string menuSceneName = "MainMenu";
        SceneManager.LoadScene(menuSceneName);
        isPaused = false;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        // Quit Game, Close Entire Game.
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
