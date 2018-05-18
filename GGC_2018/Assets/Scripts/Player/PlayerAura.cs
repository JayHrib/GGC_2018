using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerAura : MonoBehaviour {
    private float downsizeTo = 0.9f; 
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("In player Trigger");
        if((collision.gameObject.GetComponent<SpriteRenderer>() != null) && (!collision.gameObject.CompareTag("Enemy")))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

            if (collision.CompareTag("Dandelion"))
            {
                //Debug.Log("60 degrees angle");
                collision.transform.eulerAngles = new Vector3(60, 0, 10);
            }
        }
        else
        {
            if(!collision.gameObject.CompareTag("Enemy"))
            {
                foreach (SpriteRenderer sr in collision.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.color = Color.gray;
                    //Debug.Log("in coll");
                    if (sr.CompareTag("FlowerHead"))
                    {
                        sr.transform.localPosition = new Vector3(sr.transform.localPosition.x, sr.transform.localPosition.y -2, 0);
                       // sr.transform.localScale = new Vector3(downsizeTo, downsizeTo,1);
                        sr.tag = "FlowerHeadDown";
                    }
                    if(sr.CompareTag("FlowerWhole"))
                    {
                        //Debug.Log("original = "+sr.sprite.name + "replaced = " + sr.sprite.name.Replace('0', '1'));
                        //sr.transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    }
                    if (collision.CompareTag("Dandelion"))
                    {
                        //Debug.Log("60 degrees angle");
                        collision.transform.eulerAngles = new Vector3(60, 0, 10);
                    }
                    sr.transform.eulerAngles = new Vector3(40, 0, 10);

                }
            }    
        }
    }
}
