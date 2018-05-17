using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    public GameObject bullet;
    public bool active = false;
    public int direction = -1;
    public int discord = 3;

    private int timer = 0;
    private float rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            rotation = rotation + 10;
            Quaternion newrot = Quaternion.Euler(0, 0, (rotation * direction));
            transform.rotation = Quaternion.Slerp(transform.rotation, newrot, 100 * Time.deltaTime);

            timer++;
            if (timer > discord)
            {
                rotation = rotation + 2;
                timer = 0;
                GameObject go = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                go.GetComponent<Rigidbody2D>().velocity = go.transform.up * -5;
            }
        }
	}
}
