﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealthSystem : MonoBehaviour {

    private float currentHealth;
    public float baseDamage = 20f;


	// Use this for initialization
	void Start () {
        currentHealth = GetComponent<PlayerStats>().maxHealth;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
            LevelManager.deaths++;
            other.gameObject.SetActive(false);
        }
    }

    void TakeDamage()
    {
        currentHealth -= baseDamage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
