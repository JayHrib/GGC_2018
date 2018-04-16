using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellSprite
{
    public string name;
    public Sprite spellSprite;
}

public class SpellElement
{
    public string type;

    public SpellElement(string newType)
    {
        type = newType;
    }
}

public class CastSpell : MonoBehaviour {

    public static CastSpell instance;
    
    public Transform firePoint;
    public GameObject spellPrefab;
    List<SpellElement> elementList = new List<SpellElement>();

    [SerializeField]
    SpellSprite[] spellSprites;

    private SpellHandler spellHandler;

    private GameObject toReturn;

	// Use this for initialization
	void Start () {
        instance = this;

		if (spellSprites == null)
        {
            Debug.LogError("CastSpell: No sprites available");
        }

        spellHandler = SpellHandler.instance;

        elementList.Add(new SpellElement("FireSpell"));
        elementList.Add(new SpellElement("WaterSpell"));
        elementList.Add(new SpellElement("IceSpell"));
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
