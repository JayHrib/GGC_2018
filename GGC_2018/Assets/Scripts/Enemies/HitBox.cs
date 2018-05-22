using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private bool Exists = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Exists)
        {
            Destroy(gameObject);
        }
        else
        {
            Exists = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerHealthSystem>().currentHealth = other.GetComponent<PlayerHealthSystem>().currentHealth - 5;
        }
        if(other.CompareTag("Spell"))
        {
            Destroy(gameObject);
        }
    }
}
