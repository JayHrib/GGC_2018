using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellSprite
{
    public string name;
    public Sprite sprite;
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

	// Use this for initialization
	void Start () {
        instance = this;

		if (spellSprites == null)
        {
            Debug.LogError("CastSpell: No sprites available");
        }

        spellPool = SpellPool.instance;

        elementList.Add(new SpellElement("FireSpell"));
        elementList.Add(new SpellElement("WaterSpell"));
        elementList.Add(new SpellElement("IceSpell"));
    }


    public void FireSpell(int elementNumber)
    {
        GameObject go = spellPool.GetPooledObject();

        if (go == null)
        {
            return;
        }

        SpellStats myStats = go.GetComponent<SpellStats>();
        myStats.element = elementList[elementNumber].type;
        SetSprite(myStats.element, go);

        go.transform.position = firePoint.position;
        go.SetActive(true);
    }

    private void SetSprite(string element, GameObject spell)
    {
        SpriteRenderer spellSprite = spell.GetComponent<SpriteRenderer>();

        for (int i = 0; i < spellSprites.Length; i++)
        {
            if (spellSprites[i].name == element)
            {
                spellSprite.sprite = spellSprites[i].sprite;

                return;
            }
        }
    }
}
