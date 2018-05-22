using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    private GameObject target;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private float speed;
    private int rand;
    public float lane;
    private int min_rand;
    private int max_rand;

    private bool positionReached = false;

    private GameObject clickbox;


    void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
    }

    void OnEnable()
    {
        clickbox = GameObject.FindGameObjectWithTag("ClickBox").gameObject;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), clickbox.GetComponent<BoxCollider2D>());
        positionReached = false;

        int enemyLane = gameObject.GetComponent<EnemyStats>().lane;
        switch (enemyLane)
        {
            case 1:
                lane = -7.5f;
                break;
            case 2:
                lane = -4.5f;
                break;
            case 3:
                lane = -1.5f;
                break;
            case 4:
                lane = 1.5f;
                break;
            case 5:
                lane = 4.5f;
                break;
            case 6:
                lane = 7.5f;
                break;
            default:
                break;
        }

        target = GameObject.Find("Player");
    }

	void FixedUpdate () {

        if (target == null)
        {
            target = GameObject.Find("Player");
        }

        else
        {
            targetDistance = Vector3.Distance(target.transform.position, transform.position);

            if (transform.localPosition.y < 0)
            {
                if (!positionReached)
                {
                    positionReached = true;
                }
            }

            if(!positionReached)
            {
                float tempPos = transform.localPosition.y - (speed * 0.02f * GameConfig.gameSpeed);
                transform.localPosition = new Vector3(lane, tempPos, 0);
            }

            if (positionReached)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * GameConfig.gameSpeed * Time.deltaTime));
            }
        }
	}
}
