using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour {
    FuelGadge fuelGadge;
    public float fuelValue = 20f;
    public GameObject Deathparts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0,0,15*Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        fuelGadge = other.gameObject.GetComponent<FuelGadge>();
        fuelGadge.time = fuelGadge.time + fuelValue;
        Instantiate(Deathparts, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
