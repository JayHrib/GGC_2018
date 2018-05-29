using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPlayerBoss : MonoBehaviour {

    public GameObject player;

    public RuntimeAnimatorController cont_bart;
    public RuntimeAnimatorController cont_bokaj;

    public Sprite spr_bart;
    public Sprite spr_bokaj;

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
            player.GetComponent<SpriteRenderer>().sprite = spr_bart;
            player.GetComponent<Animator>().runtimeAnimatorController = cont_bart;
        }

        else if (character == "Bokaj")
        {
            player.GetComponent<SpriteRenderer>().sprite = spr_bokaj;
            player.GetComponent<Animator>().runtimeAnimatorController = cont_bokaj;
        }
    }
}
