using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;
    bool isLevelSelectActive = false;

    GameCanvasSession gameCanvasSession;

    private void Start()
    {
        gameCanvasSession = FindObjectOfType<GameCanvasSession>();
        levelSelect.SetActive(false);
    }

    public void ShowLevelSelection()
    {
        if (isLevelSelectActive == false)
        {
            if (GetComponent<Controls>().GetBoolOfControls() == true)
            {
                GetComponent<Controls>().SetControlsToFalse();
                SetLevelWindowToTrue();
            }
            else
            {
                SetLevelWindowToTrue();
            }

        }
        else if(isLevelSelectActive == true)
        {
            SetLevelWindowToFalse();
        }
    }

    public void SetLevelWindowToFalse()
    {
        isLevelSelectActive = false;
        levelSelect.SetActive(false);
    }

    public void SetLevelWindowToTrue()
    {
        isLevelSelectActive = true;
        levelSelect.SetActive(true);
    }
    public bool GetBoolOfLevelSelect()
    {
        return isLevelSelectActive;
    }


    //===================Levels============================
    public void Level1()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(6);
    }
    public void Level7()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(7);
    }
    public void Level8()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(8);
    }
    public void Level9()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(9);
    }
    public void Level10()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(10);
    }
    public void Level11()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(11);
    }
    public void Level12()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(12);
    }
    public void Level13()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(13);
    }
    public void Level14()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(14);
    }
    public void Level15()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(15);
    }
    public void Level16()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(16);
    }
    public void Level17()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(17);
    }
    public void Level18()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(18);
    }
    public void Level19()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(19);
    }
    public void Level20()
    {
        gameCanvasSession.ResetLivesCounter();
        gameCanvasSession.ResetTexts();
        gameCanvasSession.ResetTimer();
        SceneManager.LoadScene(20);
    }
}