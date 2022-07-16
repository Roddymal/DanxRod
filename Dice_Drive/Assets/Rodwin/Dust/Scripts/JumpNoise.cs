using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNoise : MonoBehaviour {
    PlayerInput PInput;
    VehicleMovement movement;

	// Use this for initialization
	void Start () {
        PInput = GameObject.FindObjectOfType<PlayerInput>();
        movement = GameObject.FindObjectOfType<VehicleMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		if (PInput.isJumping&&(movement.isOnGround || movement.isOnAlmostGround))
        {
            GetComponent<AudioSource>().Play();
        }
	}
}
