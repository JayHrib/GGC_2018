using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    private GameObject target;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private float speed;


    

	// Use this for initialization
	void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
        target = GameObject.Find("da_faiz");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetDistance = Vector3.Distance(target.transform.position, transform.position);

		if (targetDistance > GOAL_DISTANCE)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * Time.deltaTime));
        }
	}
}
