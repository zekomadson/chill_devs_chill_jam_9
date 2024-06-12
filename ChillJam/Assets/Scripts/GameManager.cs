using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load Scene Called: Main
        string gameSceneName = "Main";
        SceneManager.LoadScene(gameSceneName);

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
