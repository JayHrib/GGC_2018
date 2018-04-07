using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float healthPoints = 100f;
    public bool playerOne = false;
    public bool playerTwo = false;

    private float currentHealth;
   
	// Use this for initialization
	void Start () {
        currentHealth = healthPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
