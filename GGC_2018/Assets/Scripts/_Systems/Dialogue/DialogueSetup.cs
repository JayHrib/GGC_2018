using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSetup : MonoBehaviour {

    private string _character;

    public GameObject BartIsMain;
    public GameObject BokajIsMain;

    void Awake()
    {
        _character = PlayerPrefs.GetString("Character");
    }

    // Use this for initialization
    void Start () {
        DetermineCharacter();
	}

    void DetermineCharacter()
    {
        if (_character == "Bartholomew")
        {
            //Activate corresponding dialogue chain
            BartIsMain.gameObject.SetActive(true);
        }else if(_character == "Bokaj")
        {
            //Activate corresponding dialogue chain
            BokajIsMain.gameObject.SetActive(true);
        }
    }
 
}
