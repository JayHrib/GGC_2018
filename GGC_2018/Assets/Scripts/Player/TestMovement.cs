using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

    private float movementSpeed = 9f;
    private float desiredDistance = 0.2f;

    public Transform target;
    private bool allowedToMove = false;
    private Animator animator;
    private GameConfig gameCon;
    private bool locked = false;
    private Vector2 targetPos;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        gameCon = FindObjectOfType<GameConfig>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameCon.PlayerCanWalk() && !locked)
        {
            locked = true;
            animator.SetBool("Walking", true);
        }


		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                if (!hit.collider.gameObject.CompareTag("Enemy"))
                {
                    targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    target.position = targetPos;
                }

                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    allowedToMove = true;
                }
            }
            else
            {
                targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                target.position = targetPos;
            }

        }

        if (allowedToMove)
        {
            if (Vector2.Distance(transform.position, target.position) > desiredDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            }
            else
            {
                target.position = transform.position;
                allowedToMove = false;
            }
        }
	}
}
