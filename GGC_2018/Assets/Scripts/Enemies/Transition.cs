﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public float visibility = 0;
    public bool reverse = false;

    private float timer = 0;
    public bool on = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (reverse)
        {
            if (on)
            {
                timer = timer + 0.00001f;
                visibility = visibility + timer;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, visibility);
                if (visibility > 2)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        else
        {
            timer = timer + 0.0001f;
            visibility = visibility - timer;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, visibility);
            if (visibility < 0)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            on = true;
        }
    }
}
