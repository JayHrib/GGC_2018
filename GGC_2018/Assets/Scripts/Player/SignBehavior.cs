using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehavior : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            if (!(contactPoint.y < center.y))
            {
                this.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
               // Debug.Log("collision from players any side except top, point and center, as player");
            }
        }
        
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("On collision exit, as player");
            this.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        }
           
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("On Trigger Enter, as Player");
            this.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        }
        
    }
}
