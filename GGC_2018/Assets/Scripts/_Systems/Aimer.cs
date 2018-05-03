using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour {

    public KeyCode left;
    public KeyCode right;

    public int lane = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(left))
        {
            if(lane == 1)
            {
                lane = 6;
            }
            else
            {
                lane--;
            }
        }
        if (Input.GetKeyDown(right))
        {
            if (lane == 6)
            {
                lane = 1;
            }
            else
            {
                lane++;
            }
        }
        float poz = 1.5f;
        switch (lane)
        {
            case 1:
                poz = -7.5f;
                break;
            case 2:
                poz = -4.5f;
                break;
            case 3:
                poz = -1.5f;
                break;
            case 4:
                poz = 1.5f;
                break;
            case 5:
                poz = 4.5f;
                break;
            case 6:
                poz = 7.5f;
                break;
            default:
                break;
        }
        transform.position = new Vector3(poz,4,0);
	}
}
