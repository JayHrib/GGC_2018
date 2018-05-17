using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeg : MonoBehaviour {

    public Transform target;
    public GameObject hitbox;
    public bool active = false;
    public bool preped = false;
    public bool right = false;
    public bool attacking = false;

    private int timer;
    private int limit = 120;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = transform.position;
        if (transform.position.x < (target.position.x - 0.5))
        {
            newpos.x = newpos.x + 0.05f;
        }
        else if (transform.position.x > (target.position.x + 0.5))
        {
            newpos.x = newpos.x - 0.05f;
        }
        transform.position = newpos;


        if(timer > (limit - 30) && timer < limit)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }

        if(timer > limit)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            timer = 0;
            attacking = true;
            limit = Random.Range(120, 240);
        }

        if (active && preped)
        {
            if (attacking)
            {
                timer = 0;
                newpos = new Vector3(transform.position.x, -4, 1);
                transform.position = Vector3.MoveTowards(transform.position, newpos, 0.3f);
                if (transform.position.y < -3)
                {
                    attacking = false;
                    Instantiate(hitbox, transform.position, transform.rotation);
                }
            }
            else
            {
                timer++;
                newpos = new Vector3(transform.position.x, 2, 1);
                transform.position = Vector3.MoveTowards(transform.position, newpos, 0.05f);
            }
        }
        else if (active)
        {
            newpos = new Vector3(transform.position.x, 2, 1);
            transform.position = Vector3.MoveTowards(transform.position, newpos, 0.05f);
            if (transform.position.y < 2.5)
            {
                preped = true;
            }
        }
        else
        {
            newpos = new Vector3(transform.position.x, 12, 1);
            transform.position = Vector3.MoveTowards(transform.position, newpos, 0.05f);
        }
    }

    void OnDisable()
    {
        if (right)
        {
            transform.parent.GetComponent<BossControler>().rightKill = true;
            transform.parent.GetComponent<BossControler>().rightkills++;
        }
        else
        {
            transform.parent.GetComponent<BossControler>().leftKill = true;
            transform.parent.GetComponent<BossControler>().leftkills++;
        }
    }
}
