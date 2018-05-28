using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHitBox : MonoBehaviour {

    public float Xacc = 0f;
    public float Yacc = 0f;

    private StartDialogue s_dialogue;

    void Start()
    {
        s_dialogue = GetComponent<StartDialogue>();
    }

	// Update is called once per frame
	void Update () {
        if (!s_dialogue.IsTriggered())
        {
            transform.position += new Vector3(Xacc, Yacc, 0) * Time.deltaTime;
        }
	}
}
