using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class ControllerChecker : MonoBehaviour {
    public Sprite[] controllersettings;
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    int Controllers;
    public static bool ShowHowToPlay = false;
    public bool howtoplay;

    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                //print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                //print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }

        Controllers = InputManager.Devices.Count;
        if (Xbox_One_Controller == 1)
        {
            GetComponent<Image>().sprite = controllersettings[1];  //do something
        }
        else if (PS4_Controller == 1)
        {
            GetComponent<Image>().sprite = controllersettings[2];//do something
        }
        else
        {
            GetComponent<Image>().sprite = controllersettings[0];// there is no controllers
            
            if(Controllers >= 1)
            {
                
                GetComponent<Image>().sprite = controllersettings[1];
            }
        }
        if(Controllers <= 0)
        {
            GetComponent<Image>().sprite = controllersettings[0];
        }

        if(howtoplay)
        {
            if(ShowHowToPlay)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }

            if(Input.GetKey(KeyCode.Return))
            {
                Destroy(gameObject);
                ShowHowToPlay = false;
            }
            if (Controllers >= 1)
            {
                var player1 = InputManager.Devices[0];
                if(player1.Action4)
                {
                    Destroy(gameObject);
                    ShowHowToPlay = false;
                }
              
            }

        }


    }
}
