using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float maxHealth = 100f;
    public int playerIdentifier;
   
	// Use this for initialization
	void Start () {

        if (playerIdentifier < 1)
        {
            playerIdentifier = 1;
        }
        else
        {
            playerIdentifier = 2;
        }
	}
}
