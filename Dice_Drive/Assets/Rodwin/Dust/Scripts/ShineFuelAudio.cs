using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineFuelAudio : MonoBehaviour {
    public AudioClip[] AudioFile;
    int Song;
	// Use this for initialization
	void Start () {
		 Song = Random.Range(0, 2);
        GetComponent<AudioSource>().clip = AudioFile[Song];
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
