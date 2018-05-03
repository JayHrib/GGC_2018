using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour {

    private GameObject target;

    private float targetDistance;
    public const float GOAL_DISTANCE = 1f;

    private bool twoPlayer;

    private float speed;
    private int rand;
    public float lane;
    private int min_rand;
    private int max_rand;


    void Start () {
        speed = gameObject.GetComponent<EnemyStats>().movementSpeed;
        twoPlayer = FindObjectOfType<LevelManager>().isTwoPlayers;
    }

    void OnEnable()
    {
        int enemyLane = gameObject.GetComponent<EnemyStats>().lane;
        switch (enemyLane)
        {
            case 1:
                lane = -7.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(1));
                }
                break;
            case 2:
                lane = -4.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(1));
                }
                break;
            case 3:
                lane = -1.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(1));
                }
                break;
            case 4:
                lane = 1.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(2));
                }
                break;
            case 5:
                lane = 4.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(2));
                }
                break;
            case 6:
                lane = 7.5f;
                if (twoPlayer)
                {
                    target = GameObject.Find(ChooseTarget(2));
                }
                break;
            default:
                break;
        }

        if (!twoPlayer)
        {
            target = GameObject.Find("WitchPrefab");
        }
    }

	void FixedUpdate () {

        if (target == null)
        {
            rand = Random.Range(0, 3);
            target = GameObject.Find(ChooseTarget(rand));
        }

        else
        {
            targetDistance = Vector3.Distance(target.transform.position, transform.position);

            if (targetDistance > GOAL_DISTANCE && transform.localPosition.y < 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * GameConfig.gameSpeed * Time.deltaTime));
            }
            else
            {
                float tempPos = transform.localPosition.y - (speed * 0.02f * GameConfig.gameSpeed);
                transform.localPosition = new Vector3(lane, tempPos, 0);
            }
        }
	}

    private string ChooseTarget(int index)
    {
        string toReturn = "";

        if (index == 1)
        {
            toReturn = "WitchPrefab";
        }
        if (index == 2)
        {
            toReturn = "Bokaj";
        }

        return toReturn;
    }
}
