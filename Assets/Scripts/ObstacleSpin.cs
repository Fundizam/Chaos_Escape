using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 30f;
    // Update is called once per frame
    void Update()
    {
        ObstacleSpinner();
    }

    void ObstacleSpinner()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

}
