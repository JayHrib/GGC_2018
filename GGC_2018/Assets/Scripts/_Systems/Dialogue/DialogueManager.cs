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
    private bool startNext = false;
    public float dialogueTimer;
    private float timeLeft;

    // Use this for initialization
    void Start()
    {
        //Instantiate queue for sentences
        sentences = new Queue<string>();

        //Set automatic progress timer
        timeLeft = dialogueTimer;
    }

    void Update()
    {
        //Check if dialogue is active
        if (isActive)
        {
            //Start counting down timer 
            timeLeft -= Time.deltaTime;

            //Display next sentence when timer reaches 0 and reset the timer
            if (timeLeft <= 0)
            {
                DisplayNextSentence();
                timeLeft = dialogueTimer;
            }
        }

        //Reset timer if dialogue is inactive
        else
        {
            timeLeft = dialogueTimer;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Set dialogue as active
        isActive = true;

        //Make sure that next dialogue isn't readied
        startNext = false;

        //Open dialogue box
        animator.SetBool("IsOpen", true);

        //Manipulate the name text for the dialogue box 
        nameText.text = dialogue.name;

        //Clear previous sentences in queue
        sentences.Clear();

        //Queue new sentences
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //Display the next sentence in the queue
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        //End dialogue if there's no more sentences in the queue
        if (sentences.Count == 0)
        {
            if (timeLeft <= 0)
            {
                EndDialogue();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Write the sentences one letter at a time
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
        //Set dialogue as inactive
        isActive = false;

        //Close the dialogue box
        animator.SetBool("IsOpen", false);

        //Tell give potentially queued sentences the greenlight
        SwitchBool();
    }

    /*Used to give more control to the user of this system
    Allows the user to set the specific dialogue box to be used in the dialoge,
    the name field to manipulate as well as the dialogue text to manipulate*/
    public void SetDialogueInfo(Animator _animator, TextMeshProUGUI _name, TextMeshProUGUI _dialogueText)
    {
        animator = _animator;
        nameText = _name;
        dialogueText = _dialogueText;
    }

    //Used by chained dialogues to know when they have gotten the greenlight
    public bool GetGreenlight()
    {
        return startNext;
    }

    public void SwitchBool()
    {
        startNext = !startNext;
    }
}