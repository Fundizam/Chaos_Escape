using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Config params
    [Header("Player engine")]
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float thrust = 30f;

    [Header("Audio Clips")]
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip successClip;

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem engineThrust;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] ParticleSystem successExplosion;
    
    //enums
    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    //variables
    float levelLoadDelay = 3f;

    //thrust var
    float boosterThrust = 55f;
    float mainThrust = 0f;
    bool collisionDisabled = false;
    bool gameOver = false;
    bool isLevelCompleted = false;

    int currentSceneIndex;

    // references
    Rigidbody rigidbody;
    AudioSource audioSource;
    SceneLoader sceneLoader;
    GameCanvasSession gameCanvasSession;

    // Start is called before the first frame update
    void Start()
    {
        mainThrust = thrust;
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameCanvasSession = FindObjectOfType<GameCanvasSession>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            ProcessInput();
        }
        if (Debug.isDebugBuild)
        {
            PressInput();
        }
        if (gameCanvasSession.GetTimerForInvincibility() <= 0)
        {
            collisionDisabled = false;
            gameCanvasSession.DeactivateTimerForInvincibility();
        }
        if (gameCanvasSession.GetTimeForBooster() <= 0)
        {
            gameCanvasSession.DeactivateTimerForBooster();
            mainThrust = thrust;
        }
    }
    private void ProcessInput()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotationInput();
        }
    }

    void PressInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextSceneFromSceneLoader();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || collisionDisabled)   //ignore collisions
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                if (gameCanvasSession.GetLiveCount() > 1)
                {
                    gameCanvasSession.LivesDecrease();
                    gameCanvasSession.ResetScene();
                    gameCanvasSession.ResetTimer();
                }
                else
                {
                    gameCanvasSession.LivesDecrease();
                    StartDeathSequence();
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shield":
                // funkcija za paljenje i gašenje kolizije
                // aktiviraj Timer
                Destroy(collision.gameObject);
                ShieldPickup();
                break;
            case "Booster":
                Destroy(collision.gameObject);
                BoosterPickup();
                break;
            default:
                break;
        }
    }

    //=====================Level Complete==============================//
    private void StartSuccessSequence()
    {
        state = State.Transcending;
        isLevelCompleted = true;
        LevelCompleteEffects();
        gameCanvasSession.SetLevelCompleteToActive();        
        Invoke("LoadNextSceneFromSceneLoader", levelLoadDelay);
    }
    private void LevelCompleteEffects()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(successClip);
        successExplosion.Play();
    }

    public bool GetLevelComplete()
    {
        return isLevelCompleted;
    }
    //======================Level Complete==================================//

    //===================Game Over=====================================//
    private void StartDeathSequence()
    {
        state = State.Dying;
        GameOverEffects();
        gameCanvasSession.SetGameOverToActive();
        gameCanvasSession.SetIndexOfLostLevel(currentSceneIndex);
        Invoke("LoadGameOverFromSceneLoader", levelLoadDelay);
    }
    private void GameOverEffects()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(deathClip);
        deathExplosion.Play();
    }
    //======================Game Over==================================//

    //=======================Thrust=================================//
    void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            StopApplyingThrust();
        }
    }
    private void StopApplyingThrust()
    {
        audioSource.Stop();
        engineThrust.Stop();
    }
    private void ApplyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        engineThrust.Play();
    }
    //======================Thrust===================================//

    //======================Rotation===============================================//
    void RespondToRotationInput()
    {
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            RotateManually(rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateManually(-rotationThisFrame);
        }
    }
    private void RotateManually(float rotationThisFrame)
    {
        rigidbody.freezeRotation = true; //take manual control of rotation
        transform.Rotate(Vector3.forward * rotationThisFrame);
        rigidbody.freezeRotation = false; //resume physics control of rotation
    }
    //==============================Rotation=======================================//


    //==========================Scene Load===========================================//
    void LoadNextSceneFromSceneLoader()
    {
        sceneLoader.NextScene();
    }
    void LoadGameOverFromSceneLoader()
    {
        sceneLoader.GameOverScene();
    }
    //==========================Scene Load===========================================//

    //==========================Shield Pickup===========================================//
    void ShieldPickup()
    {
        collisionDisabled = true;
        gameCanvasSession.ActivateTimerForInvincibility();
    }
    //==========================Shield Pickup===========================================//

    //==========================Booster Pickup==========================================//
    void BoosterPickup()
    {
        mainThrust = boosterThrust;
        gameCanvasSession.ActivateTimerForBooster();
    }
    //==========================Booster Pickup==========================================//
}