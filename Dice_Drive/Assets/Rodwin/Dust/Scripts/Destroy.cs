using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public float destroyDelay = 1f ; 
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
