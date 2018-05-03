using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HazardSystem : MonoBehaviour {

    public string requiredSpell = "";
    private string otherElement = "";
    public bool toRemove = false;
    Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spell"))
        {
            otherElement = other.gameObject.GetComponent<SpellStats>().element;
          
            if (otherElement == requiredSpell)
            {
                other.gameObject.SetActive(false);
                if (toRemove)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    collider.enabled = false;
                }
            }
        }
    }
}
