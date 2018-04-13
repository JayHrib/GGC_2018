using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler instance;
    public GameObject pooledObject;
    public int pooledAmount = 10;
    public bool willGrow = false;

    List<GameObject> pooledObjects;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
	
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject go = (GameObject)Instantiate(pooledObject);
            go.SetActive(false);
            pooledObjects.Add(go);
        }
    }

	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject go = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(go);
            return go;
        }

        return null;
    }

    public GameObject GetActivePooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
