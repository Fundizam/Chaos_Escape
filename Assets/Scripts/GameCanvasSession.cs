using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameCanvasSession : MonoBehaviour
{
    [Header("Lives and timers")]
    [SerializeField] int livesCount = 3;
    [SerializeField] float countdownTimerForInvincible = 5f;
    [SerializeField] float countdownTimerForBooster = 5f;
    //text objects
    [SerializeField] GameObject LevelCompleteText;
    [SerializeField] GameObject GameOverText;
    //lives text
    [SerializeField] Text LivesCountText;
    //timer text
    [SerializeField] Text TimerText;
    [SerializeField] Text BoosterText;

    bool ShieldActivated = false;
    bool BoosterActivated = false;

    string gameOverName = "GameOverScene";
    string winName = "WinScene";
    string mainMenuName = "MainMenu";

    int currentSceneIndex;
    int sceneIndexToTryAgain;

    private void Awake()
    {
        SetUpSingleton();
    }
    void SetUpSingleton()
    {
        int gameSessionCount = FindObjectsOfType<GameCanvasSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            DestroyItself();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        SetObjectsToFalse();
        LivesCountText.text = "Lives: " + livesCount.ToString();
        TimerText.text = "";
        BoosterText.text = "";
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == mainMenuName ||
        SceneManager.GetActiveScene().name == gameOverName ||
        SceneManager.GetActiveScene().name == winName)
        {
            SetObjectsToFalse();
            SetTextsToEmpty();
        }
        else
        {
            LivesCountText.text = "Lives: " + livesCount.ToString();
        }
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    //=============Setting objects==========//
    public void SetObjectsToFalse()
    {
        GameOverText.SetActive(false);
        LevelCompleteText.SetActive(false);
    }
    public void SetGameOverToActive()
    {
        GameOverText.SetActive(true);
    }
    public void SetLevelCompleteToActive()
    {
        LevelCompleteText.SetActive(true);
    }
    private void SetTextsToEmpty()
    {
        LivesCountText.text = "";
        TimerText.text = "";
        BoosterText.text = "";
    }
    public void SetIndexOfLostLevel(int number)
    {
        sceneIndexToTryAgain = number;
    }
    public int GetIndexOfLostLevel()
    {
        return sceneIndexToTryAgain;
    }
    //=============Setting objects==========//

    //=============Lives============//
    public void LivesDecrease()
    {
        livesCount--;
        LivesCountText.text = "Lives: " + livesCount.ToString();
    }
    public int GetLiveCount()
    {
        return livesCount;
    }
    //==============Lives================//

    //=============Resets===============//
    public void ResetScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void ResetLivesCounter()
    {
        livesCount = 3;
    }
    public void ResetTexts()
    {
        SetObjectsToFalse();
    }
    public void ResetTimer()
    {
        countdownTimerForInvincible = 5f;
        countdownTimerForBooster = 5f;
        TimerText.text = "";
        BoosterText.text = "";
    }
    //=============Resets===============//

    //=============Invincibility Timer================//
    public void ActivateTimerForInvincibility()
    {
        TimerText.text = "Time: " + countdownTimerForInvincible.ToString();
        ShieldActivated = true;
        StartCoroutine(CountdownInvincible());
    }
    public void DeactivateTimerForInvincibility()
    {
        TimerText.text = "";
        ShieldActivated = false;
        StopCoroutine(CountdownInvincible());
    }
    public float GetTimerForInvincibility()
    {
        return countdownTimerForInvincible;
    }
    //=============Invincibility Timer================//

    //=============Booster Timer================//
    public void ActivateTimerForBooster()
    {
        BoosterText.text = "Booster: " + countdownTimerForBooster.ToString();
        BoosterActivated = true;
        StartCoroutine(CountdownBooster());
    }
    public void DeactivateTimerForBooster()
    {
        BoosterText.text = "";
        BoosterActivated = false;
        StopCoroutine(CountdownBooster());
    }
    public float GetTimeForBooster()
    {
        return countdownTimerForBooster;
    }
    //=============Booster Timer================//

    //=======Timer Enumerators========//
    IEnumerator CountdownInvincible()
    {
        while (countdownTimerForInvincible > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTimerForInvincible--;
            TimerText.text = "Time: " + countdownTimerForInvincible.ToString();
        }
    }
    IEnumerator CountdownBooster()
    {
        while (countdownTimerForBooster > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTimerForBooster--;
            BoosterText.text = "Boost: " + countdownTimerForBooster.ToString();
        }
    }
    //=======Timer Enumerators========//
}