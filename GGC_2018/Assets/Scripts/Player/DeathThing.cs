using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathThing : MonoBehaviour {

    private int timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newpos = transform.position;
        newpos.y = transform.position.y + 0.01f;
        transform.position = newpos;

        timer++;
        if(timer > 240)
        {
            SceneManager.LoadScene(0);
        }
	}
}
