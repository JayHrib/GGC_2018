using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

    public float hue = 0;
    public Color color;
    public float sat;

    private GameObject clickbox;

    void OnEnable()
    {
        clickbox = GameObject.FindGameObjectWithTag("ClickBox").gameObject;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), clickbox.GetComponent<BoxCollider2D>());
    }

    void Update () {
        hue = hue + 0.06f;
        if (hue >= 1)
        {
            hue = 0;
        }
        color = Color.HSVToRGB(hue, 1, 1);
        color.a = sat;
        gameObject.GetComponent<SpriteRenderer>().color = color;

        if (transform.position.x > 30 || transform.position.x < -30 || transform.position.y > 30 || transform.position.y < -30)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
