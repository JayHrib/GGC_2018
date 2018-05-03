using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

    public static CastSpell instance;
    
    public Transform firePoint;
    public GameObject spellPrefab;

    private SpellHandler spellHandler;

    private GameObject toReturn;

	// Use this for initialization
	void Start () {
        instance = this;

        spellHandler = SpellHandler.instance;
    }


    public void FireSpell(string element)
    {
        GameObject go = PickPrefab(element);

        if (go == null)
        {
            return;
        }

        go.transform.position = firePoint.position;

        go.SetActive(true);
    }

    private GameObject PickPrefab(string element)
    {
        toReturn = spellHandler.GetSpecifiedSpell(element);
        return toReturn;
    }
}
