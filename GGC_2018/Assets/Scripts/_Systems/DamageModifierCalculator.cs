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
        //Reset modifier in case it has not been reset 
        modifier = 1f;

        for (int i = 0; 0 < listOfRelations.Length - 1; i++)
        {
            if (listOfRelations[i].element == currentEnemyElement)
            {
                for (int j = 0; j < listOfRelations[i].weaknesses.Length; j++)
                {
                    //Check if spell element is inside of the weakness list
                    if (listOfRelations[i].weaknesses[j] == spellElement)
                    {
                        modifier = weaknessModifier;
                        modifierFound = true;
                        break;
                    }
                    else
                    {
                        //Break loop if no modifier has been found at the last iteration
                        if (j == listOfRelations[i].weaknesses.Length && !modifierFound)
                        {
                            break;
                        }
                    }
                }

                if (!modifierFound)
                {
                    //Check if spell element is inside of the resistance list
                    for (int k = 0; k < listOfRelations[i].resisting.Length; k++)
                    {
                        if (listOfRelations[i].resisting[k] == spellElement)
                        {
                            modifier = resistanceModifier;
                            modifierFound = true;
                            break;
                        }

                        //Break loop if no modifier has been found at the last iteration
                        if (k == listOfRelations[i].resisting.Length && !modifierFound)
                        {
                            break;
                        }
                    }
                }
            }

            if (modifierFound)
            {
                //Break loop early in case modifier has been found
                break;
            }

            if (i == listOfRelations.Length - 1 && !modifierFound)
            {
                //Nothing found in the lists, apply base damage
                break;
            }
        }

        return modifier;
        
    }
}
