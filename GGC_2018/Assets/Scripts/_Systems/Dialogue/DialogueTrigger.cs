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
    private bool lockAutoChange = false;

    void Update()
    {
        if (!lockAutoChange)
        {
            startChain = FindObjectOfType<DialogueManager>().GetBool();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerCharDialogue()
    {
        FindObjectOfType<DialogueManager>().SetDialogueInfo(animator, _name, _dialogue);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public bool StartNext()
    {
        return startChain;
    }

    public void SetBool()
    {
        startChain = !startChain;
    }

    public void LockBool()
    {
        lockAutoChange = !lockAutoChange;
    }
}
