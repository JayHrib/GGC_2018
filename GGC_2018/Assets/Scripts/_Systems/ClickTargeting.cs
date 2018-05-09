using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTargeting : MonoBehaviour {

    private GameObject target;
    public bool isBeingUsed = true;
    public GameObject targetMarker;

    void Start()
    {
        target = null;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            //Use raycasts to determine which target the player clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                //Make sure that the clicked object is either a hazard or an enemy
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    target = hit.collider.gameObject;
                    if (!target.GetComponent<EnemyHealth>().marked)
                    {
                        MarkTarget(target);
                    }
                }
                else
                {
                    target = null;
                }
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

    private void MarkTarget(GameObject target)
    {
        GameObject marker;
        marker = Instantiate(targetMarker, target.transform.position, target.transform.rotation);
        marker.GetComponent<Marker>().SetTarget(target);
        target.GetComponent<EnemyHealth>().marked = true;
    }
}
