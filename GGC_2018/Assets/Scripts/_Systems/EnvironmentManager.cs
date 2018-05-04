using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyHabitat
{
    public string environment = "";
    public string[] elementsInArea;
}

public class EnvironmentManager : MonoBehaviour {

    private string currentEnvironment = "";
    private string newEnvironment = "";

    [SerializeField]
    EnemyHabitat[] enemyHabitats;

    List<string> currentPool = new List<string>();

	// Use this for initialization
	void Start () {

		if(enemyHabitats == null)
        {
            Debug.LogError("EnvironmentManager: List of habitats is empty!");
        }

        SetPool(enemyHabitats[0].environment);
    }

    public void SetPool(string environment)
    {
        if (currentPool != null)
        {
            currentPool.Clear();
        }

        for (int i = 0; i < enemyHabitats.Length; i++)
        {
            if (enemyHabitats[i].environment == environment)
            {
                for (int j = 0; j < enemyHabitats[i].elementsInArea.Length; j++)
                {
                    currentPool.Add(enemyHabitats[i].elementsInArea[j]);
                }
            }
        }
    }

    public string GetEnemyFromPool(int index)
    {
        string toReturn = "";

        for (int i = 0; i < currentPool.Count; i++)
        {
            if (i == index)
            {
                toReturn = currentPool[i];
            }
        }

        return toReturn;
    }

    public int GetSizeOfPool()
    {
        int toReturn = currentPool.Count;
        return toReturn;
    }
}
