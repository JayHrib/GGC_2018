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

    public GameObject healthpotion;
    public GameObject manapotion;

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
            if(gameObject.GetComponent<BossAI>() != null)
            {
                Destroy(transform.parent.parent.gameObject);
            }
            else
            {
                int temp = Random.Range(1,4);
                if(temp == 1)
                {
                    Instantiate(healthpotion, transform.position, Quaternion.identity);
                }
                else if(temp == 2)
                {
                    Instantiate(manapotion, transform.position, Quaternion.identity);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
