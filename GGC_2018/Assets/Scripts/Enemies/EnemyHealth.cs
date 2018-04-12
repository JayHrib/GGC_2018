using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
   // private string myElement;
    private float resist;
    private float weakness;
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
        if (GetComponent<EnemyStats>().element == "Water")
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
        if (GetComponent<EnemyStats>().element == "Ice")
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
        if (GetComponent<EnemyStats>().element == "Grass")
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
