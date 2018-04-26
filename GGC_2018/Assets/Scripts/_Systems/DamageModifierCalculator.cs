using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListOfRelation
{
    public string element;

    [SerializeField]
    public string[] weaknesses;

    [SerializeField]
    public string[] resisting;
} 

public class DamageModifierCalculator : MonoBehaviour {

    [SerializeField]
    ListOfRelation[] listOfRelations;

    float modifier = 1;
    public float weaknessModifier = 2.0f;
    public float resistanceModifier = 0.25f;
    private bool modifierFound = false;

    void Start()
    {
       if (listOfRelations == null)
        {
            Debug.LogError("DamageModCalc: List of relations is empty!");
        }
    }

	public float CalculateDamage(string spellElement, string currentEnemyElement)
    {
        if (modifierFound)
        {
            modifierFound = false;
        }
        modifier = 1f;

        for (int i = 0; 0 < listOfRelations.Length - 1; i++)
        {
            if (listOfRelations[i].element == currentEnemyElement)
            {
                Debug.Log("Match found! " + listOfRelations[i].element + " = " + currentEnemyElement);
                for (int j = 0; j < listOfRelations[i].weaknesses.Length; j++)
                {
                    Debug.Log(listOfRelations[i].weaknesses[j]);
                    if (listOfRelations[i].weaknesses[j] == spellElement)
                    {
                        modifier = weaknessModifier;
                        modifierFound = true;
                        break;
                    }
                    else
                    {
                        if (j == listOfRelations[i].weaknesses.Length && !modifierFound)
                        {
                            break;
                        }
                    }
                }

                if (!modifierFound)
                {
                    for (int k = 0; k < listOfRelations[i].resisting.Length; k++)
                    {
                        Debug.Log(listOfRelations[i].resisting[k]);
                        if (listOfRelations[i].resisting[k] == spellElement)
                        {
                            modifier = resistanceModifier;
                            modifierFound = true;
                            break;
                        }

                        if (k == listOfRelations[i].resisting.Length && !modifierFound)
                        {
                            break;
                        }
                    }
                }
            }

            if (modifierFound)
            {
                break;
            }

            if (i == listOfRelations.Length - 1 && !modifierFound)
            {
                //Nothing found in the lists, apply base damage
                Debug.Log("Element not found");
                break;
            }
        }

        return modifier;
        
    }
}
