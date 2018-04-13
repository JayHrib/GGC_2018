using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    public static bool active = true;
    public KeyCode pressSpace;

    private GameObject targetOne;
    private GameObject targetTwo;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private float speed;


	void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
        targetOne = GameObject.Find("WitchPrefab");
	}

	void FixedUpdate () {
        if (Input.GetKeyDown(pressSpace))
        {
            if(active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
        }
        if (active)
        {
            targetDistance = Vector3.Distance(targetOne.transform.position, transform.position);

            if (targetDistance > GOAL_DISTANCE)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetOne.transform.position, (speed * Time.deltaTime));
            }
        }
	}
}
