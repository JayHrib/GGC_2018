using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLasor : MonoBehaviour {

    public float hue = 0;
    public Color color;
    public bool damaging;
    public float sat;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        hue = hue + 0.03f;
        if(hue >= 1)
        {
            hue = 0;
        }
        color = Color.HSVToRGB(hue, 1, 1);
        color.a = sat;
        gameObject.GetComponent<SpriteRenderer>().color = color;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && damaging)
        {
            other.GetComponent<PlayerHealthSystem>().currentHealth = other.GetComponent<PlayerHealthSystem>().currentHealth - 0.7f;
        }
    }
}
