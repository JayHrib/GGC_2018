﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellSpell : MonoBehaviour {

    public float lifeTime = 4f;
    public float moveSpeed = 5.0f;
    private bool isActive = false;

    public LevelManager levelManager;

    GameObject target;
    private bool manager;

    void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        //Invoke("Destroy", lifeTime);
        target = GetTarget();
        if (!isActive)
        {
            isActive = true;
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().sortingLayerName = "Spell";
        }
    }

    // Update is called once per frame
    void Update ()
    {
        manager = FindObjectOfType<LevelManager>().atBoss;
        if (isActive)
        {
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
        GameObject toReturn = null;
        if (!manager)
        {
            //toReturn = GameObject.FindGameObjectWithTag("Enemy");
            toReturn = levelManager.GetComponent<LevelManager>().GetEnemy(FindObjectOfType<Aimer>().lane);
            return toReturn;
        }
        else
        {
            toReturn = GameObject.FindGameObjectWithTag("Boss");
            Debug.Log(toReturn);
            return toReturn;
        }
    }
}
