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

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerCharDialogue()
    {
        FindObjectOfType<DialogueManager>().SetDialogueInfo(animator, _name, _dialogue);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
