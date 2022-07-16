using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    Rigidbody rb;
    public float fanStrength = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
       rb = other.GetComponent<Rigidbody>();
       rb.AddForce(transform.forward * (fanStrength));
    }
}
