﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetGame : MonoBehaviour {
    public bool isresseting = false;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        isresseting = true;
    }
}
