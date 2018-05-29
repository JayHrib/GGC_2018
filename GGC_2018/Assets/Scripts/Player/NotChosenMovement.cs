using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotChosenMovement : MonoBehaviour {

    private Animator animator;

    public float Xacc = 0f;
    public float Yacc = 0f;

    public float moveTimer = 5f;
    private float currTime;

    public float vanishTimer = 5f;
    private float currVan;

    private bool startMoving = false;

	// Use this for initialization
	void Start () {
        currTime = moveTimer;
        currVan = vanishTimer;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currTime > 0)
        {
            currTime -= Time.deltaTime;
        }
        else
        {
            startMoving = !startMoving;
        }

		if (startMoving)
        {
            animator.SetBool("Walking", true);
            transform.position += new Vector3(Xacc, Yacc, 0) * Time.deltaTime;
            if (currVan > 0)
            {
                currVan -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        
	}
}
