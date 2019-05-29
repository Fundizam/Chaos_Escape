using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLoader : MonoBehaviour
{
    GameCanvasSession gameCanvasSession;
    int sceneIndex;
    private void Start()
    {
        gameCanvasSession = FindObjectOfType<GameCanvasSession>();
        sceneIndex = gameCanvasSession.GetIndexOfLostLevel();
    }

    public void TryAgain()
    {
        gameCanvasSession.ResetLivesCounter();
        SceneManager.LoadScene(sceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
