using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicBehavior : MonoBehaviour {

    private AudioSource bossMusic;
    public float startAtTime;
    public float loopFromTime;
    private float endAtTime;
    private float difference;

	// Use this for initialization
	void Start () {
        bossMusic = GetComponent<AudioSource>();
        endAtTime = bossMusic.clip.length;
        bossMusic.time = startAtTime;
        difference = 1;
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Boss Music time = " + bossMusic.time);
        if (bossMusic.time >= endAtTime - difference)
        {
            bossMusic.time = loopFromTime - difference;
        }
	}
}
