using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour {

    private float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = GetComponent<EnemyStats>().maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            TakeDamage(other.gameObject);
        }
    }

    void TakeDamage(GameObject other)
    {
        float modifier = 
    }

    void CheckElement(float modifer)
    {

    }
}
