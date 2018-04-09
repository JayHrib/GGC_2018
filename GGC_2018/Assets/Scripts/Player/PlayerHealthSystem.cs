using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealthSystem : MonoBehaviour {

    private float currentHealth;
    private float baseDamage = 20f;


	// Use this for initialization
	void Start () {
        currentHealth = GetComponent<PlayerStats>().maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TakeDamage(baseDamage);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= baseDamage;

        if (baseDamage <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
