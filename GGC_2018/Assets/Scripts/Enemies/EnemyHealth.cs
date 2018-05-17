using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
    private string myElement;
    public bool marked = false;
  
    private float baseDamage = 50f;
    private float modifier;
    private DamageModifierCalculator damageCalculator;

    // Use this for initialization
    void Start()
    {
        currentHealth = GetComponent<EnemyStats>().maxHealth;
        damageCalculator = FindObjectOfType<DamageModifierCalculator>();
        if (damageCalculator == null)
        {
            Debug.LogError("EnemyHealth: No damage modifier script present in scene!");
        }
    }

    void OnEnable()
    {
        myElement = gameObject.GetComponent<EnemyStats>().element;
        if (marked == true)
        {
            marked = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            TakeDamage(other.gameObject);
        }
    }

    void TakeDamage(GameObject other)
    {
        EvaluateModifier(other);
    }

    void EvaluateModifier(GameObject other)
    {
        string spellElement = other.GetComponent<SpellStats>().element;

        modifier = damageCalculator.CalculateDamage(spellElement, myElement);
        ApplyDamage(modifier);
    }

    void ApplyDamage(float damage)
    {
        currentHealth -= (damage *= baseDamage);

        if (currentHealth <= 0)
        {
            LevelManager.deaths++;
            gameObject.SetActive(false);
        }
    }
}
