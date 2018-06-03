using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private GameObject target;
    public GameObject boss = null;
    private Image bar;
    private bool bossfollower = false;

    private float health;

    // Use this for initialization
    void Start() {

        bar = gameObject.GetComponent<Image>();
        if(gameObject.GetComponentInParent<BossControler>() != null)
        {
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            target = boss;
            bossfollower = true;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            target = gameObject.transform.parent.parent.gameObject;
        }

    }

	void FixedUpdate () {

        Vector3 newpos = transform.position;
        if (!bossfollower)
        {
            newpos = target.transform.position;
        }
        if (target.GetComponent<PlayerStats>() != null)
        {
            newpos.y = newpos.y + 2;
            health = target.GetComponent<PlayerHealthSystem>().currentHealth;
        }
        else if(!bossfollower)
        {
            newpos.y = newpos.y - 1.5f;
            health = target.GetComponent<EnemyHealth>().currentHealth;
        }
        else
        {
            health = boss.GetComponent<EnemyHealth>().currentHealth;
        }
        transform.position = newpos;
        if(target.GetComponent<BossScript>() != null)
        {
            bar.fillAmount = health / 1200;
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
