using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour {

    public static bool active;
    public float speed;

    void Start()
    {
        active = true;
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y - (0.05f * speed));
            transform.position = newpos;
            if (transform.position.y <= (-92))
            {
                speed = 0;
            }
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 55, 0);
    }
}
