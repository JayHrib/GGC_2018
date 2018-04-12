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
            other.gameObject.SetActive(false);
            LevelManager.deaths++;
            gameObject.SetActive(false);
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
        if (myElement == "Fire")
        {
            if (spellElement == "FireSpell")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "WaterSpell")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "IceSpell")
            {
                ApplyDamage(resist);
            }
        }

        //Water modidiers
        if (myElement == "Water")
        {
            if (spellElement == "FireSpell")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "WaterSpell")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "IceSpell")
            {
                ApplyDamage(weakness);
            }
        }


        //Ice modidiers
        if (myElement == "Ice")
        {
            if (spellElement == "FireSpell")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "WaterSpell")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "IceSpell")
            {
                ApplyDamage(resist);
            }
        }

        //Grass modidiers
        if (myElement == "Grass")
        {
            if (spellElement == "FireSpell")
            {
                ApplyDamage(weakness);
            }
            else if (spellElement == "WaterSpell")
            {
                ApplyDamage(resist);
            }
            else if (spellElement == "IceSpell")
            {
                ApplyDamage(weakness);
            }
        }
    }

    void ApplyDamage(float modifier)
    {
        currentHealth -= (baseDamage * modifier);
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            LevelManager.deaths++;
            gameObject.SetActive(false);
        }
    }
}
