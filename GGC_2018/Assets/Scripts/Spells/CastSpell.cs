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

    public GameObject spellPrefab;
    List<SpellElement> elementList = new List<SpellElement>();

    [SerializeField]
    SpellSprite[] spellSprites;

    private SpellPool spellPool;

	// Use this for initialization
	void Start () {
		if (spellSprites == null)
        {
            Debug.LogError("CastSpell: No sprites available");
        }

        spellPool = SpellPool.instance;

        elementList.Add(new SpellElement("Fire"));
        elementList.Add(new SpellElement("Water"));
        elementList.Add(new SpellElement("Ice"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireSpell(int elementNumber)
    {
        GameObject go = spellPool.GetPooledObject();

        if (go == null)
        {
            return;
        }

        
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
