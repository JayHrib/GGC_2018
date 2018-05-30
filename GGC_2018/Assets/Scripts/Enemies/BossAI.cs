using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

    public float movementSpeed = 0.5f;

    public Transform target;
    public bool vulnerable = false;

    private int timer;
    private Quaternion newrot = Quaternion.Euler(0,0,0);

    public GameObject ender;
    private bool pimp = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gameObject.GetComponent<EnemyHealth>().currentHealth <= 100 && pimp)
        {
            Instantiate(ender, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), Quaternion.identity);
            Debug.Log("Did the thing!");
            pimp = false;
        }

        timer++;
        if (timer > 119)
        {
            int tempo = Random.Range(-60, 60);
            newrot = Quaternion.Euler(0, 0, tempo);
            timer = 0;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, newrot, movementSpeed * Time.deltaTime);

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
            transform.position = Vector3.MoveTowards(transform.position, newpos, movementSpeed * Time.deltaTime);
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
