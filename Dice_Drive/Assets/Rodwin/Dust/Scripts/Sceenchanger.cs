using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;

public class Sceenchanger : MonoBehaviour {
    PlayerInput input;
    FuelGadge fuel;
    UIFader screenfade;
    ResetGame Reset;
    VehicleMovement movement;
    public GameObject Tanklow;
    public int scene;
    public int nextcene;
    public int MainMenuScene;
    public float timeBeforeHint = 2f;
    // Use this for initialization
    void Start()
    {
        screenfade = GameObject.FindObjectOfType<UIFader>();
        Reset = GameObject.FindObjectOfType<ResetGame>();
        input = GameObject.FindObjectOfType<PlayerInput>();
        fuel = GameObject.FindObjectOfType<FuelGadge>();
        movement = GameObject.FindObjectOfType<VehicleMovement>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            screenfade.GameState = 1;

            Invoke("MainMenu", screenfade.fadeTime);
        }
        if (input.isResetting || Reset.isresseting || Input.GetKey("r"))
        {
            screenfade.GameState = 1;
            Invoke("ReloadScene", screenfade.fadeTime);

        }
        Tanklow.SetActive(false);
        if (fuel.time <= 0)
        {
            input.isBraking = true;
            Tanklow.SetActive(true);
            Invoke("OutOfFuel", 4);
        }
        //if (movement.CollidingWithWall && ((!movement.isOnGround)||(!movement.isOnAlmostGround)))
        //{
        //    timeBeforeHint -= Time.deltaTime;
        //    if(timeBeforeHint <= 0)
        //    {
        //        Debug.Log("Try Resetting");
        //    }

        //}

        //if (((movement.isOnGround) || (movement.isOnAlmostGround)))
        //{
        //    timeBeforeHint = 2; 

        //}
        var player1 = InputManager.Devices[0];
        if (player1.DPadUp)
        {
            screenfade.GameState = 1;

            Invoke("MainMenu", screenfade.fadeTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        screenfade.GameState = 1;
        
        Invoke("ChangeScene", screenfade.fadeTime);
    }

    void ChangeScene ()
    {
        
        SceneManager.LoadScene(nextcene);
    }

    void ReloadScene()
    {
        
        SceneManager.LoadScene(scene);
    }

    void OutOfFuel()
    {
        Destroy(Tanklow);

        screenfade.GameState = 1;
        Invoke("ReloadScene", screenfade.fadeTime);
    }
    void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
}
