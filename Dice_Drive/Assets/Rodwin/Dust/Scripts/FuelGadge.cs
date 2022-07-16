using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGadge : MonoBehaviour {

    VehicleMovement movement;
    VehicleAVFX avfx;
    public Image fillImg;
    public Color Ful;
    public Color Low;
    public Color Dry;
    public Color DryText;
    public float timeAmt = 200;
    public float time;
    public Image fuelLow;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<VehicleMovement>();
        avfx = GetComponent<VehicleAVFX>();
        time = timeAmt;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > timeAmt)
        {
            time = timeAmt;
        }

        if (time < 0)
        {
            time = 0;
        }
        if (movement.speed > avfx.minTrailSpeed)
        {
            time -= Time.deltaTime;
          
        }
        fillImg.fillAmount = time / timeAmt;

        if (time <= (timeAmt* .14f))
        {
            fillImg.color = Dry;  
            fuelLow.gameObject.SetActive(true);
            fuelLow.color = DryText;
        }
        else if (time <= (timeAmt *.27f))
        {
            fillImg.color = Low;
            fuelLow.gameObject.SetActive(false);
        }
        else
        {
            fillImg.color = Ful;
            fuelLow.gameObject.SetActive(false);
        }
        if (time <= (0f))
        {

            fuelLow.gameObject.SetActive(false);
        }

    }
}
