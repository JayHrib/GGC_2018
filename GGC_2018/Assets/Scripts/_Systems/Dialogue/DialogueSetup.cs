using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Character
{
    public string name;
    public Image dialogueBox;

    public TextMeshProUGUI _name;
    public TextMeshProUGUI dialogue;
}

public class DialogueSetup : MonoBehaviour {

    [SerializeField]
    public Character[] characters;

    private Image dialogueImage; 

    // Use this for initialization
    void Start () {

        if (characters == null)
        {
            Debug.LogWarning("DialogueSetup: No character entries found!");
        }
       
	}
	

}
