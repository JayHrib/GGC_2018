using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private GameObject target;
    private Image bar;

    private float health;

    // Use this for initialization
    void Start() {

        target = gameObject.transform.parent.parent.gameObject;
        bar = gameObject.GetComponent<Image>();
        if (target.GetComponent<PlayerStats>() != null)
        {
            if (target.GetComponent<PlayerStats>().playerIdentifier == 1)
            {
                gameObject.GetComponent<Image>().color = new Color(0, 0.6f, 1, 1);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(0, 1, 0, 1);
            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
 
    }

	void FixedUpdate () {
        
        Vector3 newpos = target.transform.position;
        if (target.GetComponent<PlayerStats>() != null)
        {
            newpos.y = newpos.y + 2;
            health = target.GetComponent<PlayerHealthSystem>().currentHealth;
        }
        else
        {
            newpos.y = newpos.y - 1.5f;
            health = target.GetComponent<EnemyHealth>().currentHealth;
        }
        transform.position = newpos;
        bar.fillAmount = health / 100;
        
    }
}
