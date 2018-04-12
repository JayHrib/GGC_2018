using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySprite
{
    public string name;
    public Sprite sprite;
}

public class Element
{
    public string type;

    public Element(string newType)
    {
        type = newType;
    }
}

public class LevelManager : MonoBehaviour {

    public Transform spawnPoint;
    public static bool active = false;
    public static int deaths = 0;
    private int toll = 0;
    public int spawnTimer = 0;

    public GameObject enemy;
    List<Element> elementList = new List<Element>();

    [SerializeField]
    EnemySprite[] enemySprites;

    private ObjectPooler objectPool;

    void Start()
    {
        if (enemySprites == null)
        {
            Debug.LogError("LevelManager: No sprites available!");
        }

        objectPool = ObjectPooler.instance;

        elementList.Add(new Element("Fire"));
        elementList.Add(new Element("Grass"));
        //elementList.Add(new Element("Ice"));
        //elementList.Add(new Element("Earth"));
        //elementList.Add(new Element("Electricity"));
        //elementList.Add(new Element("The one we dont talk about"));
        //elementList.Add(new Element("Wind"));
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            spawnTimer++;
            if (spawnTimer >= 5)
            {
                spawnTimer = 0;
                int rand = Random.Range(0, (elementList.Count - 1));
                Spawn(rand);
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
    }

    private void Spawn(int elementNumber)
    {
        GameObject go = objectPool.GetPooledObject();

        if (go == null)
        {
            return;
        }
        
        go.GetComponent<EnemyStats>().element = elementList[elementNumber].type;
        
        SetSprite(go.GetComponent<EnemyStats>().element, go);
        go.transform.position = spawnPoint.position;
        go.GetComponent<EnemyHealth>().currentHealth = 100f;

        Debug.Log("Health: " + go.GetComponent<EnemyHealth>().currentHealth + " Element: " + go.GetComponent<EnemyStats>().element);

        go.SetActive(true);
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
}
