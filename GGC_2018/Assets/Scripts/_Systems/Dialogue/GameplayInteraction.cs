using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInteraction : MonoBehaviour {

    private GameConfig gameCon;
    private bool activated = false;
    public DialogueTrigger dialogue;

	// Use this for initialization
	void Start () {
        gameCon = FindObjectOfType<GameConfig>();

        if (gameCon == null)
        {
            Debug.LogError("GameplayInteraction: No GameConfig found in scene!");
        }
	}

    void Update()
    {
        if (dialogue.StartNext() && !activated)
        {
            activated = !activated;

            gameCon.SetGameplay();
        }
    }
}
