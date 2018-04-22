using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private GameObject senpai;
    private Image bar;

    private float health;

	// Use this for initialization
	void Start () {
        senpai = gameObject.transform.parent.parent.gameObject;
        bar = gameObject.GetComponent<Image>();
		if(senpai.GetComponent<PlayerStats>() != null)
        {
            if(senpai.GetComponent<PlayerStats>().playerIdentifier == 1)
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
        Vector3 newpos = senpai.transform.position;
        if (senpai.GetComponent<PlayerStats>() != null)
        {
            newpos.y = newpos.y + 2;
            health = senpai.GetComponent<PlayerHealthSystem>().currentHealth;
        }
        else
        {
            newpos.y = newpos.y - 1.5f;
            health = senpai.GetComponent<EnemyHealth>().currentHealth;
        }
        transform.position = newpos;
        bar.fillAmount = health / 100;
    }
}
