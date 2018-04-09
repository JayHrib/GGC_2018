using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float maxHealth = 100f;

    public float movementSpeed;

    public string element = "";

    public float weaknessModifier = .25f;
    public float resistanceModifier = .5f;

	// Use this for initialization
	void Start () {
      
	}
}
