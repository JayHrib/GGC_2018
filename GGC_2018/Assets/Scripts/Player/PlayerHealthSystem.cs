using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealthSystem : MonoBehaviour {

    private float maxHealth;
    public float currentHealth;
    public float baseDamage = 20f;
    public Image healthBar;

	// Use this for initialization
	void Start () {
        currentHealth = GetComponent<PlayerStats>().maxHealth;
        maxHealth = GetComponent<PlayerStats>().maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            TriggerLoss();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
            LevelManager.deaths++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Hazard"))
        {
            TakeDamage();
        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth -= baseDamage;

        SetHealth(CalculateHealth(currentHealth));
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

    private float CalculateHealth(float health)
    {
        float toReturn;
        toReturn = health / maxHealth;
        return toReturn;
    }

    void SetHealth(float myHealth)
    {
        healthBar.fillAmount = myHealth;
    }

    void TriggerLoss()
    {
        SceneManager.LoadScene(0);
    }
}
