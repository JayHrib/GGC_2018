using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;

    private Animator animator;

    private Queue<string> sentences;

    private bool isActive = false;
    public float dialogueTimer;
    private float timeLeft;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        timeLeft = dialogueTimer;
    }

    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                DisplayNextSentence();
                timeLeft = dialogueTimer;
            }
        }
        else
        {
            timeLeft = dialogueTimer;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isActive = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        isActive = false;
        animator.SetBool("IsOpen", false);
    }

    public void SetDialogueInfo(Animator _animator, TextMeshProUGUI _name, TextMeshProUGUI _dialogueText)
    {
        animator = _animator;
        nameText = _name;
        dialogueText = _dialogueText;
    }
}