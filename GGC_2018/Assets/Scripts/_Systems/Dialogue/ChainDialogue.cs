using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This scrip is used to chain dialogue
public class ChainDialogue : MonoBehaviour {

    //The previous dialogue 
    public DialogueTrigger previousDialogue;

    //The dialogue to trigger next
    public DialogueTrigger nextDialogue;
	
	// Update is called once per frame
	void Update () {
        //Check if the previous dialogue has ended
		if (previousDialogue.StartNext())
        {
            //Trigger next dialogue
            nextDialogue.TriggerCharDialogue();
            
            //Lock the communication bool in previous dialogue
            previousDialogue.LockBool();

            //Switch the bool after locking it
            previousDialogue.SetBool();
        }
	}
}
