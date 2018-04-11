using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellSpell : MonoBehaviour {

    public float lifeTime = 4f;
    public float moveSpeed = 2.0f;

    GameObject target;

    private SpellPool spellPool;

    void Start()
    {
        spellPool = SpellPool.instance;
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
        GameObject toReturn = spellPool.GetActivePooledObject();
        return toReturn;
    }
}
