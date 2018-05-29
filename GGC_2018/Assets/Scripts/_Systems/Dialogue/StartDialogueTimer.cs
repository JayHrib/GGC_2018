using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueTimer : MonoBehaviour {

    public bool affectGameplay = true;

    private bool locked = false;

    public DialogueTrigger dialogue;
    private GameConfig gameCon;

    public float timer;
    private float currTime;

	// Use this for initialization
	void Start () {
        currTime = timer;
        gameCon = FindObjectOfType<GameConfig>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currTime > 0)
        {
            currTime -= Time.deltaTime;
        }
        else if (currTime <= 0 && !locked)
        {
            locked = !locked;
            dialogue.TriggerCharDialogue();
        }

        if (affectGameplay && dialogue.StartNext())
        {
            gameCon.SetGameplay();
        }
	}
}
