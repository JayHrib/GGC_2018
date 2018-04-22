using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
   // private string myElement;
    private float resist;
    private float weakness;
    private float normal = 1;
    private float baseDamage = 50f;

    // Use this for initialization
    void Start()
    {
        currentHealth = GetComponent<EnemyStats>().maxHealth;
        resist = GetComponent<EnemyStats>().resistanceModifier;
        weakness = GetComponent<EnemyStats>().weaknessModifier;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            TakeDamage(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    void TakeDamage(GameObject other)
    {
        EvaluateModifier(other);
    }

    void EvaluateModifier(GameObject other)
    {
        string spellElement = other.GetComponent<SpellStats>().element;

        //Fire modidiers
        if (GetComponent<EnemyStats>().element == "Fire")
        {
            if (spellElement == "Ice")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "Water")
            {
                ApplyDamage(weakness);
            }
            else
            {
                ApplyDamage(normal);
            }
        }

        //Water modidiers
        if (GetComponent<EnemyStats>().element == "Water")
        {
            if (spellElement == "Fire")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "Ice")
            {
                ApplyDamage(weakness);
            }
            else
            {
                ApplyDamage(normal);
            }
        }


        //Ice modidiers
        if (GetComponent<EnemyStats>().element == "Ice")
        {
            if (spellElement == "Fire")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "Water")
            {
                ApplyDamage(resist);
            }
            else
            {
                ApplyDamage(normal);
            }
        }

        //Grass modidiers
        if (GetComponent<EnemyStats>().element == "Grass")
        {
            if (spellElement == "Fire")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "Water")
            {
                ApplyDamage(resist);
            }
            else
            {
                ApplyDamage(normal);
            }
        }

        if (GetComponent<EnemyStats>().element == "Snail")
        {
            if (spellElement == "Fire")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "Water")
            {
                ApplyDamage(resist);
            }
            else
            {
                ApplyDamage(normal);
            }
        }
    }

    void ApplyDamage(float modifier)
    {
        currentHealth -= (baseDamage * modifier);

        if (currentHealth <= 0)
        {
            LevelManager.deaths++;
            gameObject.SetActive(false);
        }
    }
}
