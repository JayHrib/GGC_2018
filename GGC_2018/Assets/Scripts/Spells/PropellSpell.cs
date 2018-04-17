using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellSpell : MonoBehaviour {

    public float lifeTime = 4f;
    public float moveSpeed = 5.0f;
    private bool isActive = false;

    GameObject target;

    void OnEnable()
    {
        //Invoke("Destroy", lifeTime);
        target = GetTarget();
        if (!isActive)
        {
            isActive = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (isActive)
        {
            if (target == null)
            {
                target = GetTarget();
                //transform.Translate(Vector3.forward * Time.deltaTime);
            }

            if (target != null && !target.activeInHierarchy)
            {
                target = null;
            }
            else if (target != null && target.activeInHierarchy)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (moveSpeed * Time.deltaTime));
            }
        }
	}

    void Destroy()
    {
        if (isActive)
        {
            isActive = false;
        }
        gameObject.SetActive(false);
    }

    void OnBecomeInvisible()
    {
        if (isActive)
        {
            isActive = false;
        }
        Destroy();
    }

    void OnDisable()
    {
        if (isActive)
        {
            isActive = false;
        }
        CancelInvoke();
    }

    GameObject GetTarget()
    {
        GameObject toReturn = GameObject.FindGameObjectWithTag("Enemy");
        return toReturn;
    }
}
