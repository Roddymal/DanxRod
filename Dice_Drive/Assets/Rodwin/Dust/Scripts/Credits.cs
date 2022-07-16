using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    public static bool RollCredits;
    public GameObject credits;
    // Use this for initialization
    void Start () {
        credits.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(RollCredits)
        {
            credits.SetActive(true);
        }
	}
}
