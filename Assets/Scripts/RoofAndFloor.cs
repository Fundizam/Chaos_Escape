using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofAndFloor : MonoBehaviour
{
    //config params
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 boundaryPositionOnYLower = new Vector3(0, 25.5f, 0);
    [SerializeField] Vector3 boundaryPositionOnYUpper = new Vector3(0, 25.5f, 0);

    [Header("Roof or Floor")]
    [SerializeField] bool IsRoof = false;
    [SerializeField] bool IsFloor = false;

    //cached ref
    Player player;

    //state var
    bool stopRoofFall = false;
    bool stopFloorGoingUp = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfRoofOrFloor();
    }

    private void CheckIfRoofOrFloor()
    {
        if (IsRoof == true && IsFloor == false)
        {
            RoofFall();
        }
        else if (IsRoof == false && IsFloor == true)
        {
            FloorAscend();
        }
    }

    private void RoofFall()
    {
        if (transform.position.y <= boundaryPositionOnYLower.y || player.GetLevelComplete() == true)
        {
            transform.Translate(Vector3.zero);
            stopRoofFall = true;
        }
        else if (stopRoofFall == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
    }

    private void FloorAscend()
    {
        if (transform.position.y >= boundaryPositionOnYUpper.y || player.GetLevelComplete() == true)
        {
            transform.Translate(Vector3.zero);
            stopFloorGoingUp = true;
        }
        else if (stopFloorGoingUp == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }
}
