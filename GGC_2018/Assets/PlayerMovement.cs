using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    
    private RaycastHit2D hit;
    private RaycastHit2D[] hitresults;
    private int layerMask;

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * (movementSpeed * Time.deltaTime), Input.GetAxis("Vertical") * (movementSpeed * Time.deltaTime), 0);
        pos += velocity;
        transform.position = pos;
        
    }
}
