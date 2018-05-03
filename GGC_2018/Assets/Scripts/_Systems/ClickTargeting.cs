using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTargeting : MonoBehaviour {

    private GameObject target;
    public bool isBeingUsed = true;

    void Start()
    {
        target = null;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                target = hit.collider.gameObject;
            }
            else
            {
                target = null;
            }

            if (target != null && !target.activeInHierarchy)
            {
                target = null;
            }
        }
	}

    public GameObject GetTarget()
    {
        return target;
    } 
}
