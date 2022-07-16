using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFootManager : MonoBehaviour
{
    public Collider carTrigger;
    public GameObject player;
    public GameObject spawnPoint;
    public float engineOffHoverHeigt = 0f;
    public GameObject carCamera;
    public PlayerInput carControls;
    public VehicleMovement car;
    bool inCar = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inCar)
        {
            if (Input.GetKey(KeyCode.F))
            {
                LeaveCar();
                inCar = false;
            }
        }

        if (!inCar)
        {
            if (Input.GetKey(KeyCode.E))
            {
                EnterCar();
                inCar = true;
            }
        }

    }

    
    void LeaveCar()
    {
        car.StopCar();  
        carControls.enabled = false;
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
        carCamera.SetActive(false);
    }

    void EnterCar()
    {
        carControls.enabled = true;
        player.transform.position = Vector3.zero;
        player.SetActive(false);
        carCamera.SetActive(true);
        car.StartCar();
    }
}
