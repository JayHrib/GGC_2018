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

    private bool twoPlayer;

    private float speed;
    private int rand;


    void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
        twoPlayer = FindObjectOfType<LevelManager>().isTwoPlayers;
    }

    void OnEnable()
    {
        if (twoPlayer)
        {
            rand = Random.Range(0, 3);
            target = GameObject.Find(ChooseTarget(rand));
        }
        else
        {
            target = GameObject.Find("WitchPrefab");
        }
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

        if (target == null)
        {
            rand = Random.Range(0, 3);
            target = GameObject.Find(ChooseTarget(rand));
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
