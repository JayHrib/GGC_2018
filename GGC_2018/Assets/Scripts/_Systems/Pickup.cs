using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public bool health = false;
    public bool mana = false;

    private bool active = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newpos = transform.position;
        newpos.y = transform.position.y - 0.01f;
        transform.position = newpos;
        if(newpos.y < -10)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && active)
        {
            active = false;
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerHealthSystem>().PlayPickUpSound();
            if (health)
            {
                other.gameObject.GetComponent<PlayerHealthSystem>().TakeDamage(-1);
            }
            if (mana)
            {
                other.GetComponent<ManaBar>().PickUpMana();
                //other.GetComponent<PlayerHealthSystem>().PlayDrinkingPickUpSound();
            }

        }
    }
}
