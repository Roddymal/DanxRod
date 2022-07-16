using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class MenuChanger : MonoBehaviour {

  
    UIFader screenfade;
    ResetGame Reset;
    int Controllers;

    public int scene;
    public int nextcene;
    public bool isMainMenu= false;
    public float timeAmt = 7;
    float time;

    // Use this for initialization
    void Start()
    {
        screenfade = GameObject.FindObjectOfType<UIFader>();
        Reset = GameObject.FindObjectOfType<ResetGame>();
        time = timeAmt;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)&&isMainMenu)
        {
            Application.Quit();
        }
        if(isMainMenu == true)
        {
            ControllerChecker.ShowHowToPlay = true;
        }

       
           
        if ((Input.GetKey(KeyCode.Space))&&isMainMenu)
        {
          screenfade.GameState = 1;

          Invoke("ChangeScene", screenfade.fadeTime);
        }

        Controllers = InputManager.Devices.Count;
        if (Controllers >= 1)
        {
            var player1 = InputManager.Devices[0];

            if (player1.DPadUp && isMainMenu)
            {
                Application.Quit();
            }

            if (( player1.Action1) && isMainMenu)
            {
                screenfade.GameState = 1;

                Invoke("ChangeScene", screenfade.fadeTime);
            }
        }

        if(isMainMenu == false)
        {
            if (time > timeAmt)
            {
                time = timeAmt;
            }

            if (time < 0)
            {
                time = 0;
            }
            
            time -= Time.deltaTime;

            // print(time);
            if (Input.GetButtonDown("Cancel") && isMainMenu)
            {
                Application.Quit();
            }
                

            if (time <= (0f))
            {

                screenfade.GameState = 1;

                Invoke("ChangeScene", screenfade.fadeTime);


            }
           
            
        }

    }

    void ChangeScene()
    {

        SceneManager.LoadScene(nextcene);
    }




}
