using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVictorySpin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 30f;
    private void Update()
    {
        Spin();
    }
    private void Spin()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

}
