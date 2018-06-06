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

    private AudioSource bulletAudio;
    // Use this for initialization
    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            
            rotation = rotation + 10;
            Quaternion newrot = Quaternion.Euler(0, 0, (rotation * direction));
            transform.rotation = Quaternion.Slerp(transform.rotation, newrot, 100 * Time.deltaTime);
            
            timer++;
            if (timer > (discord * 2.5))
            {
                bulletAudio.Play();
                rotation = rotation + 6;
                timer = 0;
                GameObject go = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                go.GetComponent<Rigidbody2D>().velocity = go.transform.up * -2;
                
            }
        }
        else
        {
            if (bulletAudio.isPlaying)
            {
                bulletAudio.Stop();
            }
        }
        
    }
}
