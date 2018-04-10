using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour {

    private float currentHealth;
    private string myElement;
    private float resist;
    private float weakness;
    private float baseDamage = 50f;

    // Use this for initialization
    void Start()
    {
        currentHealth = GetComponent<EnemyStats>().maxHealth;
        myElement = GetComponent<EnemyStats>().element;
        resist = GetComponent<EnemyStats>().resistanceModifier;
        weakness = GetComponent<EnemyStats>().weaknessModifier;
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
        //Fire modidiers
        if (myElement == "Fire")
        {
            if (other.name == "FireSpell")
            {
                ApplyDamage(resist);
            }
            else if (other.name == "WaterSpell")
            {
                ApplyDamage(weakness);
            }
            else if (other.name == "IceSpell")
            {
                ApplyDamage(resist);
            }
        }

        //Water modidiers
        if (myElement == "Water")
        {
            if (other.name == "FireSpell")
            {
                ApplyDamage(resist);
            }
            else if (other.name == "WaterSpell")
            {
                ApplyDamage(resist);
            }
            else if (other.name == "IceSpell")
            {
                ApplyDamage(weakness);
            }
        }


        //Ice modidiers
        if (myElement == "Ice")
        {
            if (other.name == "FireSpell")
            {
                ApplyDamage(weakness);
            }
            else if (other.name == "WaterSpell")
            {
                ApplyDamage(resist);
            }
            else if (other.name == "IceSpell")
            {
                ApplyDamage(resist);
            }
        }


    }

    void ApplyDamage(float modifier)
    {
        currentHealth -= (baseDamage *= modifier);

        if (currentHealth <= 0)
        {
            LevelManager.deaths++;
            gameObject.SetActive(false);
        }
    }
}
