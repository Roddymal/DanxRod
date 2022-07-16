using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicOperator : MonoBehaviour {

    public AudioClip[] Songs;
    AudioSource MusicPlayer;
    //bool[] SongPlayed;
    List<bool> SongPlayed = new List<bool>();
    int CurrentSong = 0;
    int NumberPlayed = 0;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        MusicPlayer = GetComponent<AudioSource>();
        MusicPlayer.Play();
        for (int i = 0; i < Songs.Length; i++)
        {
            SongPlayed.Add(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(!MusicPlayer.isPlaying)
        {
            CurrentSong = Random.Range(0, Songs.Length);
            //Debug.Log("Current song " + CurrentSong);
            if(SongPlayed[CurrentSong]==false)
            {
                MusicPlayer.clip = Songs[CurrentSong];
                SongPlayed[CurrentSong] = true;
                MusicPlayer.Play();
            }
            
        }

        for (int i = 0; i < Songs.Length; i++)
        {
            if(SongPlayed[i] == true)
            {
                NumberPlayed++;
            }
        }
        // Debug.Log("Songs Played " + NumberPlayed);
        if (NumberPlayed == Songs.Length)
        {
            //Debug.Log("all songs Played");
            for (int i = 0; i < Songs.Length; i++)
            {
                Credits.RollCredits = true;
                SongPlayed.Add(false);
            }

        }

        NumberPlayed = 0;

    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
           

    }
}
