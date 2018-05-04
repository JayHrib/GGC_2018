using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemySprite
{
    public string name;
    public Sprite sprite;
    public RuntimeAnimatorController animController;
}

[RequireComponent(typeof(EnvironmentManager))]
public class LevelManager : MonoBehaviour {

    private EnvironmentManager e_manager;

    public Transform spawnPoint;
    public static bool active = false;
    public bool isTwoPlayers = false;
    public static int deaths = 0;
    private int toll = 0;
    public int spawnTimer = 0;
    public KeyCode pressEscape;
    private GameObject background;

    public GameObject enemy;

    private bool atBoss = false;
    private int upperLimit;

    [SerializeField]
    EnemySprite[] enemySprites;

    private ObjectPooler objectPool;
    private GameObject boss;

    List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        e_manager = FindObjectOfType<EnvironmentManager>();
        boss = GameObject.Find("Boss");
        background = GameObject.Find("PlaytestEnvironment");
        if (enemySprites == null)
        {
            Debug.LogError("LevelManager: No sprites available!");
        }

        objectPool = ObjectPooler.instance;
    }

    void FixedUpdate()
    {
        upperLimit = e_manager.GetSizeOfPool();

        if (Input.GetKeyDown(pressEscape))
        {
            SceneManager.LoadScene(0);
        }
        if (active == true)
        {
            spawnTimer++;
            if (spawnTimer >= 5)
            {
                spawnTimer = 0;
                int rand = Random.Range(0, upperLimit);
                int lane = Random.Range(1,6);
                Spawn(rand, lane);
                toll++;
                active = false;
            }
        }
        else if (deaths >= toll)
        {
            deaths = 0;
            toll = 0;
            active = true;
        }

        if (!atBoss && background.transform.position.y <= -92)
        {
            atBoss = true;
        }

        if (!boss.activeInHierarchy)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Spawn(int elementNumber, int lane)
    {
        if (!atBoss)
        {
            GameObject go = objectPool.GetPooledObject();

            if (go == null)
            {
                return;
            }

            go.GetComponent<EnemyStats>().element = e_manager.GetEnemyFromPool(elementNumber);
            go.GetComponent<EnemyStats>().lane = lane;

            SetSprite(go.GetComponent<EnemyStats>().element, go);
            SetAnimController(go.GetComponent<EnemyStats>().element, go);
            go.transform.position = spawnPoint.position;
            go.GetComponent<EnemyHealth>().currentHealth = 100f;

            go.SetActive(true);
            enemyList.Add(go);
        }
    }

    private void SetSprite(string element, GameObject enemy)
    {
        SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();

        for (int i = 0; i < enemySprites.Length; i++)
        {
            if (enemySprites[i].name == element)
            {
                enemySprite.sprite = enemySprites[i].sprite;

                return;
            }
        }
    }

    private void SetAnimController(string element, GameObject enemy)
    {
        Animator animator = enemy.GetComponent<Animator>();

        for (int i = 0; i < enemySprites.Length; i++)
        {
            if (enemySprites[i].name == element)
            {
                animator.runtimeAnimatorController = enemySprites[i].animController;

                return;
            }
        }
    }

    public GameObject GetEnemy(int lane)
    {
        float pos = -1.5f;
        switch (lane)
        {
            case 1:
                pos = -7.5f;
                break;
            case 2:
                pos = -4.5f;
                break;
            case 3:
                pos = -1.5f;
                break;
            case 4:
                pos = 1.5f;
                break;
            case 5:
                pos = 4.5f;
                break;
            case 6:
                pos = 7.5f;
                break;
            default:
                break;
        }
        GameObject result = null;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i].GetComponent<EnemyAI>().lane == pos)
            {
                result = enemyList[i];
                break;
            }
        }
        return result;
    }

    public bool IsAtBoss()
    {
        return atBoss;
    }
}
