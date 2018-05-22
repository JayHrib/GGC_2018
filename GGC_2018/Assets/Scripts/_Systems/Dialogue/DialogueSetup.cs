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

    private string _character = "";
    private string otherChar = "";

    [SerializeField]
    public Character[] characters;

    private Image dialogueImage;

    private DialogueTrigger dTrigger;

    void Awake()
    {
        _character = PlayerPrefs.GetString("Character");
        otherChar = PlayerPrefs.GetString("NotPicked");
    }

    // Use this for initialization
    void Start () {

        if (characters == null)
        {
            Debug.LogWarning("DialogueSetup: No character entries found!");
        }

        if (_character == null)
        {
            _character = PlayerPrefs.GetString("Character");
            if (_character == null)
            {
                Debug.LogWarning("DialogueSetup: Something went wrong! No character pref found!");
            }
        }

        SetupDialogue(_character);
	}

    void SetupDialogue(string chosenChar)
    {

    }
	

}
