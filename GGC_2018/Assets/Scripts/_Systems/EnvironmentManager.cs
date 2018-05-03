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
    public string startEnvironment = "";

    [SerializeField]
    EnemyHabitat[] enemyHabitats;
    List<string> currentPool;

	// Use this for initialization
	void Start () {
        if (startEnvironment == "")
        {
            Debug.LogError("EnvironmentManager: No start environment has been set!");
        }
        else
        {
            SetPool(startEnvironment);
        }

		if(enemyHabitats == null)
        {
            Debug.LogError("EnvironmentManager: List of habitats is empty!");
        }


	}
	
	// Update is called once per frame
	void Update () {
		if (currentEnvironment != newEnvironment)
        {
            currentEnvironment = newEnvironment;
            newEnvironment = "";

            SetPool(currentEnvironment);
        }
	}

    void SetPool(string environment)
    {
        if (currentPool != null)
        {
            currentPool.Clear();
        }

        for (int i = 0; i < enemyHabitats.Length - 1; i++)
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
}
