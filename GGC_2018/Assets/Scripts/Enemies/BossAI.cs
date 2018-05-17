using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

    public Transform target;
    public bool vulnerable = false;

    private int timer;
    private Quaternion newrot = Quaternion.Euler(0,0,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        timer++;
        if (timer > 119)
        {
            int tempo = Random.Range(-60, 60);
            newrot = Quaternion.Euler(0, 0, tempo);
            timer = 0;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, newrot, 0.5f * Time.deltaTime);

        //if (transform.position.x < target.position.x)
        //{
        //    Vector3 newpos = transform.position;
        //    newpos.x = newpos.x + 0.05f;
        //    transform.position = newpos;
        //}
        //else if(transform.position.x > target.position.x)
        //{
        //    Vector3 newpos = transform.position;
        //    newpos.x = newpos.x - 0.05f;
        //    transform.position = newpos;
        //}

        if(Vector3.Distance(transform.position, target.position) > 1)
        {
            Vector3 newpos = new Vector3(target.position.x, transform.position.y, 1);
            transform.position = Vector3.MoveTowards(transform.position, newpos, 0.05f);
        }

        if (vulnerable)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
