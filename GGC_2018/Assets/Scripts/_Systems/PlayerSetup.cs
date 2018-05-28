using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour {

    public GameObject player;
    public GameObject other;

    public RuntimeAnimatorController erio;
    public RuntimeAnimatorController bokaj;

    public Sprite _erio;
    public Sprite _bokaj;

    private string character;

	// Use this for initialization
	void Awake () {
        character = PlayerPrefs.GetString("Character");
        Setup(character);
	}

    private void Setup(string character)
    {
        if (character == "Bartholomew")
        {
            player.GetComponent<SpriteRenderer>().sprite = _erio;
            player.GetComponent<Animator>().runtimeAnimatorController = erio;

            other.GetComponent<SpriteRenderer>().sprite = _bokaj;
            other.GetComponent<Animator>().runtimeAnimatorController = bokaj;
        }
        else if (character == "Bokaj")
        {
            player.GetComponent<SpriteRenderer>().sprite = _bokaj;
            player.GetComponent<Animator>().runtimeAnimatorController = bokaj;

            other.GetComponent<SpriteRenderer>().sprite = _erio;
            other.GetComponent<Animator>().runtimeAnimatorController = erio;
        }
    }
}
