using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour {

    private int timer;
    public bool right = false;
    public bool left = false;
    public GameObject head;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer++;
        if(timer > 119)
        {
            Move();
            timer = 0;
        }
    }

    void Move()
    {
        Vector3 newpos = transform.position;
        if (right)
        {
            newpos.x = Random.Range(2, 10);
        }
        else if (left)
        {
            newpos.x = Random.Range(-10, -2);
        }
        else
        {
            if(head.GetComponent<BossControler>().leftkills > 3 && head.GetComponent<BossControler>().rightkills > 3)
            {
                newpos.x = Random.Range(-8, 8);
            }
            else
            {
                newpos.x = Random.Range(-3, 3);
            }
        }
        transform.position = newpos;
    }
}
