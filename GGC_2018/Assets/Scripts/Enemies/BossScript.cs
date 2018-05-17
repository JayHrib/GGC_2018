using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject animations;

    private Animator animator;
    private int timer = 0;
    private int limit = 240;
    private int fire;

	// Use this for initialization
	void Start () {
        animator = animations.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(timer == 15)
        {
            animator.SetInteger("linus", 4);
        }

        if (timer == (limit - 60))
        {
            animator.SetInteger("linus", 1);
        }

        if (timer == (limit - 15))
        {
            animator.SetInteger("linus", 2);
        }

        if (timer > limit)
        {
            FireLasor();
        }
        else
        {
            timer++;
            obj1.GetComponent<SpriteRenderer>().enabled = false;
            obj2.GetComponent<SpriteRenderer>().enabled = false;
            obj2.GetComponent<BoxCollider2D>().enabled = false;
            obj3.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = false;
        }

        if (timer > (limit - 30))
        {
            eye1.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = true;
            eye2.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = true;
        }
        else
        {
            eye1.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = false;
            eye2.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = false;
        }
    }

    void FireLasor()
    {
        timer++;
        if(fire == 0)
        {
            if (obj4.GetComponent<BossControler>().leftkills > 3 && obj4.GetComponent<BossControler>().rightkills > 3)
            {
                fire = limit + Random.Range(120, 480);
            }
            else
            {
                fire = limit + Random.Range(30, 240);
            }
        }

        if (timer > fire)
        {
            animator.SetInteger("linus", 3);
            fire = 0;
            timer = 0;
            if(obj4.GetComponent<BossControler>().leftkills > 3 || obj4.GetComponent<BossControler>().rightkills > 3)
            {
                limit = Random.Range(10, 120);
            }
            else
            {
                limit = Random.Range(90, 480);
            }
            
        }
        else
        {
            obj1.GetComponent<SpriteRenderer>().enabled = true;
            obj2.GetComponent<SpriteRenderer>().enabled = true;
            obj2.GetComponent<BoxCollider2D>().enabled = true;
            obj3.GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = true;
        }
    }
}
