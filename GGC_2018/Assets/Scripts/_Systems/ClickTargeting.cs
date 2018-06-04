using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTargeting : MonoBehaviour {

    private GameObject target;
    private GameObject PrevClickedObject;
    private bool somethingIsMarked = false;
    public bool isBeingUsed = true;
    public GameObject targetMarker;
    GameObject marker;

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


            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider != null)
            {
                //Make sure that the clicked object is either a hazard or an enemy
                if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Boss"))
                {
                    
                    target = hit.collider.gameObject;
                    if (!somethingIsMarked)
                    {
                        if (!target.GetComponent<EnemyHealth>().marked)
                        {
                            MarkTarget(target);
                        }
                    }
                    else if (somethingIsMarked && target != PrevClickedObject)
                    {
                        DeMarkTarget(PrevClickedObject);
                        MarkTarget(target);
                    }
                    else if(somethingIsMarked && target == PrevClickedObject)
                    {
                        ReMarkTarget();
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

    public void SetMarked()
    {
        if (!somethingIsMarked)
        {
            somethingIsMarked = true;
        }
    }

    private void MarkTarget(GameObject target)
    {
        PrevClickedObject = target;
        marker = Instantiate(targetMarker, target.transform.position, target.transform.rotation);
        marker.GetComponent<Marker>().SetTarget(target);
        target.GetComponent<EnemyHealth>().marked = true;
        somethingIsMarked = true;
    }

    private void DeMarkTarget(GameObject target)
    {
        PrevClickedObject = null;
        if (marker != null)
        {
            Destroy(marker);
        }

        target.GetComponent<EnemyHealth>().marked = false;
        somethingIsMarked = false;
    }

    private void ReMarkTarget()
    {
        PrevClickedObject = null;

        target.GetComponent<EnemyHealth>().marked = false;
        somethingIsMarked = false;

        PrevClickedObject = target;
     
        target.GetComponent<EnemyHealth>().marked = true;
        somethingIsMarked = true;
    }
}
