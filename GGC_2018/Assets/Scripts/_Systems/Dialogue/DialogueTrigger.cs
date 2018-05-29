using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _dialogue;
    public Dialogue dialogue;
    private bool startChain = false;

    /*Used to automatically determine when the greenlight to start 
     the chained conversation is given*/
    void Update()
    {
        //Automatically receive the greenlight to start chain dialogue
        //lockAutoChange is used when ChainDialogue alters the startChain bool just to make sure that it doesn't change back to it's previous state
       
        startChain = FindObjectOfType<DialogueManager>().GetGreenlight();
        
    }

    //Used to trigger the dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //Used to trigger specific dialogue where a specific box, name text, and dialogue text needs to be used
    //Example: when there's multiple characters talking in a scene
    public void TriggerCharDialogue()
    {
        FindObjectOfType<DialogueManager>().SetDialogueInfo(animator, _name, _dialogue);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //Used to pass the greenlight to the chained dialogue
    public bool StartNext()
    {
        return startChain;
    }

    //Used to switch the greenlight from ChainDialogue
    public void SetBool()
    { 
        startChain = !startChain;
        FindObjectOfType<DialogueManager>().SwitchBool();
    }
}
