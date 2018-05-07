using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    private GameObject target;

	// Use this for initialization
	void Start () {
        //Make sure that the render priority is correct
		for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().sortingLayerName = "Marker";
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (target.activeInHierarchy)
        {
            transform.position = target.transform.position;
        }
        else
        {
            Destroy();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spell"))
        {
            Destroy();
        }
    }

    public void SetTarget(GameObject targetObject)
    {
        target = targetObject;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
