using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellSpell : MonoBehaviour {

    public GameObject ripple;

    public float lifeTime = 4f;
    public float moveSpeed = 5.0f;
    private bool isActive = false;
    private bool ableToCollide = false;
    private float desiredDistance = 3.0f;
    private Collider2D collider;
    private Transform spawnPoint;

    private LevelManager levelManager;

    GameObject target;
    private bool isUsingLanes = false;
    private ClickTargeting targeting;

    void Start()
    {
        if (targeting.isBeingUsed)
        {
            isUsingLanes = false;
        }
        else
        {
            isUsingLanes = true;
        }

        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        targeting = FindObjectOfType<ClickTargeting>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        
        /*Deactivate the collider until it's close enough to it's target.
         Used to make sure that only the clicked target can get hurt by the spell*/

        target = GetTarget();
        if (!isActive)
        {
            isActive = true;
        }
        if (ableToCollide)
        {
            ableToCollide = false;
        }
        //Dynamically makes sure that the sorting layer of each particle system is correct
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().sortingLayerName = "Spell";
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
                transform.position = spawnPoint.position;
            }

            if (target != null && !target.activeInHierarchy)
            {
                target = null;
            }
            else if (target != null && target.activeInHierarchy)
            {
                if (!ableToCollide)
                {
                    ableToCollide = true;
                }

                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (moveSpeed * Time.deltaTime));

                /*Checks if the spell is close enough to the target.
                Enable the collider if spell is close enough*/
                if (Vector3.Distance(transform.position, target.transform.position) <= desiredDistance)
                {
                    collider.enabled = true;
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (ableToCollide)
            {
                Instantiate(ripple, transform.position, Quaternion.identity);
                targeting.SetMarked();
                gameObject.SetActive(false);
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
    }

    GameObject GetTarget()
    {
        GameObject toReturn = null;
        
        //Determine which targeting system to use
        if (isUsingLanes)
        {
            toReturn = levelManager.GetComponent<LevelManager>().GetEnemy(FindObjectOfType<Aimer>().lane);
        }
        else
        {
            toReturn = targeting.GetTarget();
        }

        return toReturn;
    }

    public bool GetActivite()
    {
        return ableToCollide;
    }
}
