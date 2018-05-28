using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotChosenMovement : MonoBehaviour {

    private Animator animator;
    private GameConfig gameCon;
    public float Xacc = 0f;
    public float Yacc = 0f;

	// Use this for initialization
	void Start () {
        gameCon = FindObjectOfType<GameConfig>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameCon.GamePlayIsActive())
        {
            animator.SetBool("Walking", true);
            transform.position += new Vector3(Xacc, Yacc, 0) * Time.deltaTime;
        }
	}
}
