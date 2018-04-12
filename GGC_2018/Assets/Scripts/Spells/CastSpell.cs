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

    private SpellPool spellPool;
    private SpellHandler spellHandler;

    private GameObject toReturn;

	// Use this for initialization
	void Start () {
        instance = this;

		if (spellSprites == null)
        {
            Debug.LogError("CastSpell: No sprites available");
        }

        spellPool = SpellPool.instance;
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

        //SpellStats myStats = go.GetComponent<SpellStats>();
        //myStats.element = elementList[elementNumber].type;
        //SetSpell(myStats.element, go);

        go.transform.position = firePoint.position;
        Debug.Log("Test 2");

        go.SetActive(true);

        Debug.Log(go + " " + go.transform.position + " " + go.activeInHierarchy);
    }

    private void SetSpell(string element, GameObject spell)
    {
        SpriteRenderer spellSprite = spell.GetComponent<SpriteRenderer>();

        for (int i = 0; i < spellSprites.Length; i++)
        {
            if (spellSprites[i].name == element)
            {
                spellSprite.sprite = spellSprites[i].spellSprite;

                return;
            }
        }
    }

    private GameObject PickPrefab(string element)
    {
        toReturn = spellHandler.GetSpecifiedSpell(element);
        return toReturn;
    }
}
