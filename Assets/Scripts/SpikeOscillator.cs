using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class SpikeOscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    float defaultPeriod;
    float slowPeriod = 6f;
    float movementFactor;
    const float tau = Mathf.PI * 2f;            // 6.28
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        defaultPeriod = period;
        Debug.Log(startingPos.y + movementVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        //"moje" rješenje ((int) uzeto iz tuđeg)
        /*if ((int)period == 0)
        {
            return;
        }*/
        // bolja varijanta kada se uspoređuju decimalni brojevi
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        else
        {
            
            if (transform.position.x >= (startingPos.x + movementVector.x - 0.2f) ||
                transform.position.y >= (startingPos.y + movementVector.y - 0.2f))
            {
                period = slowPeriod;
            }
            else if (transform.position.x <= (startingPos.x +0.2f) ||
                     transform.position.y <= (startingPos.y + 0.2f))
            {
                period = defaultPeriod;
            }
            float cycles = Time.time / period;          // grows continually
            float rawSinWave = Mathf.Sin(cycles * tau); // from -1 to +1
            movementFactor = rawSinWave / 2f + 0.5f;
            Vector3 offset = movementFactor * movementVector;
            transform.position = startingPos + offset;
        }
    }
}