using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    GameCanvasSession gameCanvasSession;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameCanvasSession = FindObjectOfType<GameCanvasSession>();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.SetObjectsToFalse();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}