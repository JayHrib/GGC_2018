using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    public static bool active = true;
    public KeyCode pressSpace;

    private GameObject target;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private float speed;


	void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
    }

    void OnEnable()
    {
        int rand = Random.Range(0, 3);
        target = GameObject.Find(ChooseTarget(rand));
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
        if (active && target != null)
        {
            targetDistance = Vector3.Distance(target.transform.position, transform.position);

            if (targetDistance > GOAL_DISTANCE)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * Time.deltaTime));
            }
        }
	}

    private string ChooseTarget(int index)
    {
        string toReturn = "";

        if (index == 0 || index == 1)
        {
            toReturn = "WitchPrefab";
        }
        if (index == 2 || index == 3)
        {
            toReturn = "FamiliarPrefab";
        }

        return toReturn;
    }
}
