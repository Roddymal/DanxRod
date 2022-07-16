//This script handles reading inputs from the player and passing it on to the vehicle. We 
//separate the input code from the behaviour code so that we can easily swap controls 
//schemes or even implement and AI "controller". Works together with the VehicleMovement script

using UnityEngine;
using InControl;

public class PlayerInput : MonoBehaviour
{
    public bool isplayer2 = false;
	public string verticalAxisName = "Vertical";        //The name of the thruster axis
	public string horizontalAxisName = "Horizontal";    //The name of the rudder axis
	public string brakingKey = "Brake";                 //The name of the brake button
    public string JumpingKey = "Jump";                 //The name of the Jump button
    //InputControl control;
    //InputDevice device;
    int Controllers;
    float ThrusterDirection;
    //We hide these in the inspector because we want 
    //them public but we don't want people trying to change them
    [HideInInspector] public float thruster;			//The current thruster value
	[HideInInspector] public float rudder;				//The current rudder value
	[HideInInspector] public bool isBraking;			//The current brake value
    [HideInInspector] public bool isJumping;            //The current brake value
    [HideInInspector] public bool isResetting = false;          //The current reset value
    public AudioSource Hooter;
    bool isHooting = false;


    private void Start()
    {
      //  Hooter = GameObject.Find("Ship Body").GetComponent<AudioSource>();
    }
    void Update()
	{

		if(isplayer2)
        {
            //If the player presses the Escape key and this is a build (not the editor), exit the game


            //If a GameManager exists and the game is not active...
            if (GameManager.instance != null && !GameManager.instance.IsActiveGame())
            {
                //...set all inputs to neutral values and exit this method
                thruster = rudder = 0f;
                isBraking = false;
                return;
            }


            //Get the values of the thruster, rudder, and brake from the input class
            thruster = Input.GetAxis(verticalAxisName);
            rudder = Input.GetAxis(horizontalAxisName);
            //thruster = Input.acceleration.z * -1f;
            //rudder = Input.acceleration.x*2.2f; 
            isJumping = Input.GetButton(JumpingKey);
            isResetting = Input.GetKey("r");
            isHooting = Input.GetKey("q");
            Controllers = InputManager.Devices.Count;
            //device = InputManager.ActiveDevice;
            //control = device.GetControl(InputControlType.Action1);

            if (isHooting)
            {
                Hooter.Play();
            }









            if (Controllers >= 1)
            {
                var player1 = InputManager.Devices[1];
                ThrusterDirection = player1.RightTrigger - (player1.LeftTrigger);
                thruster = ThrusterDirection;
                rudder = player1.LeftStick.X;
                isJumping = player1.Action1;
                //isBraking = player1.LeftTrigger;
                isResetting = player1.DPadDown;
                isHooting = player1.Action2;

            }

            if (isHooting)
            {
                Hooter.Play();
            }
        }
        else

        {
            //If the player presses the Escape key and this is a build (not the editor), exit the game


            //If a GameManager exists and the game is not active...
            if (GameManager.instance != null && !GameManager.instance.IsActiveGame())
            {
                //...set all inputs to neutral values and exit this method
                thruster = rudder = 0f;
                isBraking = false;
                return;
            }


            //Get the values of the thruster, rudder, and brake from the input class
            thruster = Input.GetAxis(verticalAxisName);
            rudder = Input.GetAxis(horizontalAxisName);
            //thruster = Input.acceleration.z * -1f;
            //rudder = Input.acceleration.x*2.2f; 
            isJumping = Input.GetButton(JumpingKey);
            isResetting = Input.GetKey("r");
            isHooting = Input.GetKey("q");
            Controllers = /*InputManager.Devices.Count*/0;
            //device = InputManager.ActiveDevice;
            //control = device.GetControl(InputControlType.Action1);

            if (isHooting)
            {
                Hooter.Play();
            }









            if (Controllers >= 1)
            {
                var player1 = InputManager.Devices[0];
                ThrusterDirection = player1.RightTrigger - (player1.LeftTrigger);
                thruster = ThrusterDirection;
                rudder = player1.LeftStick.X;
                isJumping = player1.Action1;
                //isBraking = player1.LeftTrigger;
                isResetting = player1.DPadDown;
                isHooting = player1.Action2;

            }

            if (isHooting)
            {
                Hooter.Play();
            }
        }
    }
}
