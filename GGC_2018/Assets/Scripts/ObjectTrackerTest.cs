using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrackerTest : MonoBehaviour {

    public float cursorSensitivity = 10f;
    public Transform objectToTrack;
    private VRCursorController controller;

	// Use this for initialization
	void Start () {
        controller = objectToTrack.GetComponent<VRCursorController>();
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.position = new Vector3(objectToTrack.position.x, objectToTrack.position.y, 0f);
        Vector3 temp = new Vector3(-controller.GetCursorPosition().x * cursorSensitivity, controller.GetCursorPosition().y * cursorSensitivity, 0f);
        transform.position = temp;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 50, 500, 50), transform.position.x.ToString() + transform.position.y.ToString());
    }
}
