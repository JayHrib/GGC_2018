using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpellOutline
{
    public string spellName = "";
    public Image outline;
}

public class SpellOutlineHandler : MonoBehaviour {

    [SerializeField]
    SpellOutline[] spellOutlines;

	// Use this for initialization
	void Start () {
		if (spellOutlines == null)
        {
            Debug.LogError("SpellOutlineHandler: Something went wrong, no outlines found!");
        }
        else
        {
            for (int i = 0; i < spellOutlines.Length; i++)
            {
                if (spellOutlines[i].outline.enabled)
                {
                    spellOutlines[i].outline.enabled = false;
                }
            }
        }
	}

    public void DisplayOutline(string outline)
    {
        for (int i = 0; i < spellOutlines.Length; i++)
        {
            if (spellOutlines[i].spellName == outline)
            {
                spellOutlines[i].outline.enabled = true;
            }
        }
    }

    public void HideOutline(string outline)
    {
        for (int i = 0; i < spellOutlines.Length; i++)
        {
            if (spellOutlines[i].spellName == outline)
            {
                spellOutlines[i].outline.enabled = false;
            }
        }
    }

    public void HideOutline()
    {
        for (int i = 0; i < spellOutlines.Length; i++)
        {
            if (spellOutlines[i].outline.gameObject.activeInHierarchy)
            {
                spellOutlines[i].outline.enabled = false;
            }
        }
    }

    public int BeingDisplayed()
    {
        int toReturn = 0;

        for (int i = 0; i < spellOutlines.Length; i++)
        {
            if (spellOutlines[i].outline.enabled)
            {
                toReturn++;
            }
        }

        return toReturn;
    }
}
