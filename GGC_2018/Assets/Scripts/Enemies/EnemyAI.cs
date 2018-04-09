using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    public Transform target;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private float speed;


    

	// Use this for initialization
	void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        targetDistance = Vector3.Distance(target.position, transform.position);

		if (targetDistance > GOAL_DISTANCE)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
        }
	}
}
