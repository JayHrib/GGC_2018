using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * (movementSpeed * Time.deltaTime * GameConfig.gameSpeed), 0, 0);
        pos += velocity;
        if(pos.x > 7)
        {
            pos.x = 7;
        }
        else if(pos.x < -7)
        {
            pos.x = -7;
        }
        transform.position = pos;
	}
}
