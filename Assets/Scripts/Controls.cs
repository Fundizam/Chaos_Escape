using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] GameObject controlsObjects;
    bool areControlsActive = false;

    private void Start()
    {
        controlsObjects.SetActive(false);
        GetComponent<LevelSelection>();
    }

    public void ShowControls()
    {
        if (areControlsActive == false)
        {
            if (GetComponent<LevelSelection>().GetBoolOfLevelSelect() == true)
            {
                GetComponent<LevelSelection>().SetLevelWindowToFalse();
                SetControlsToTrue();
            }
            else
            {
                SetControlsToTrue();
            }
        }
        else if (areControlsActive == true)
        {
            SetControlsToFalse();
        }
    }

    public void SetControlsToTrue()
    {
        controlsObjects.SetActive(true);
        areControlsActive = true;
    }

    public void SetControlsToFalse()
    {
        controlsObjects.SetActive(false);
        areControlsActive = false;
    }

    public bool GetBoolOfControls()
    {
        return areControlsActive;
    }
}
