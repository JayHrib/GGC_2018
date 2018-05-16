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
        gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1);

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
        if(target.GetComponent<BossScript>() != null)
        {
            bar.fillAmount = health / 800;
        }
        else if(target.GetComponent<BossLeg>() != null)
        {
            bar.fillAmount = health / 200;
        }
        else
        {
            bar.fillAmount = health / 100;
        }
        
    }
}
