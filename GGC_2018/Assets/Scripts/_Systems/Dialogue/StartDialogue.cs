using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is used as a hitbox trigger for dialogue
public class StartDialogue : MonoBehaviour {

    private bool triggered = false;
    public DialogueTrigger dialogue;
    public string triggerTag = "";

    //Check if the dialogue was triggered by the player,
    //and make sure that the dialogue has not been triggered before
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTag) && !triggered)
        {
            if (triggerTag == "NotChosen")
            {
                other.gameObject.SetActive(false);
                dialogue.TriggerCharDialogue();
            }
            //Switch the trigger bool to make sure that dialogue can't trigger again
            triggered = !triggered;

            //Trigger desired dialogue
            //GetComponent<DialogueTrigger>().TriggerCharDialogue();
            dialogue.TriggerCharDialogue();
        }
    }

    public bool IsTriggered()
    {
        return triggered;
    }
}
