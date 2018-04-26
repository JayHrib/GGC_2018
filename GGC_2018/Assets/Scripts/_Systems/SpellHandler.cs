using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellEffect
{
    public string name;
    public GameObject particlePrefab;
}

public class SpellHandler : MonoBehaviour {

    [SerializeField]
    SpellEffect[] spellEffects;

    public static SpellHandler instance;
    GameObject toReturn;
    public int pooledAmount = 2;
    List<GameObject> spellEffectPool = new List<GameObject>();
    List<string> spellElementList = new List<string>();

    void Start()
    {
        if (spellEffects == null)
        {
            Debug.LogError("SpellHandler: No spell prefabs in array!");
        }

        for (int i = 0; i < spellEffects.Length; i++)
        {
            for (int j = 0; j < pooledAmount; j++)
            {
                GameObject go = (GameObject)Instantiate(spellEffects[i].particlePrefab);
                string element = spellEffects[i].name;
                go.SetActive(false);
                spellEffectPool.Add(go);
                spellElementList.Add(element);
            }
        }
    }

    void Awake () {
        instance = this;
	}

    public GameObject GetSpecifiedSpell(string element)
    {
        for (int i = 0; i < spellEffectPool.Count; i++)
        {
            if (spellElementList[i] == element)
            {
                toReturn = spellEffectPool[i];

                return toReturn;
            }
        }

        return null;
    }
}
