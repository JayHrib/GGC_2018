using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered!");
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<DialogueTrigger>().TriggerCharDialogue();
        }
    }
}
