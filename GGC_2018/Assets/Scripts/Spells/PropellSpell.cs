using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellSpell : MonoBehaviour {

    public float lifeTime = 2f;
    public float moveSpeed = 1.0f;

    GameObject target;

    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    void OnEnable()
    {
        //Invoke("Destroy", lifeTime);
    }

    // Update is called once per frame
    void Update () {

        if (target == null)
        {
            target = GetTarget();
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

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnBecomeInvisible()
    {
        Destroy();
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    GameObject GetTarget()
    {
        GameObject toReturn = objectPooler.GetActivePooledObject();
        return toReturn;
    }
}
