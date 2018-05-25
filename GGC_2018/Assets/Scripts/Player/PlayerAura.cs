using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAura : MonoBehaviour {
    private float downsizeTo = 0.9f;
    private AudioSource stepOnAudio;

    private void Start()
    {
        stepOnAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("In player Trigger");
        if(!collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                if (collision.CompareTag("Dandelion"))
                {
                    //Debug.Log("60 degrees angle");
                    collision.transform.eulerAngles = new Vector3(60, 0, 10);
                    stepOnAudio.Play();
                }
            }
            else
            {              
                foreach (SpriteRenderer sr in collision.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.color = Color.gray;
                    //Debug.Log("in coll");
                    if (sr.CompareTag("FlowerHead"))
                    {
                        sr.transform.localPosition = new Vector3(sr.transform.localPosition.x, sr.transform.localPosition.y - 2, 0);
                        sr.tag = "FlowerHeadDown";
                    }
                    sr.transform.eulerAngles = new Vector3(40, 0, 10);
                }
                stepOnAudio.Play();              
            }
        }
        
    }
}
