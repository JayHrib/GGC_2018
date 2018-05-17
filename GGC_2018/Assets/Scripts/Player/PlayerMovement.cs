using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform destination;
    public float desiredDistance;
    private const float LOCKED_Z = -10f;

    public float movementSpeed;
    public bool usingKeys = true;
    private bool marked = false;

    private Vector3 targetPos;


    void Start()
    {
        if (destination == null)
        {
            Debug.LogWarning("PlayerMovement: No destination marker was found!");
        }
    }
    // Update is called once per frame
    void Update () {
        #region Keys
        if (usingKeys)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * (movementSpeed * Time.deltaTime * GameConfig.gameSpeed), Input.GetAxis("Vertical") * (movementSpeed * Time.deltaTime * GameConfig.gameSpeed), 0);
            pos += velocity;
            if (pos.x > 8.5f)
            {
                pos.x = 8.5f;
            }
            else if (pos.x < -8.5f)
            {
                pos.x = -8.5f;
            }
            if (pos.y > -2)
            {
                pos.y = -2;
            }
            else if (pos.y < -5)
            {
                pos.y = -5;
            }
            transform.position = pos;
        }
        #endregion

        #region Click
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Use mouse clicks if keys aren't being used
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                //Make sure clicked collider isn't empty
                if (hit.collider != null)
                {
                    if (!marked)
                    {
                        if (hit.collider.gameObject.CompareTag("ClickBox"))
                        {
                            Debug.Log(hit.collider.gameObject.tag);
                            marked = true;
                        }
                    }
                }

                if (hit.collider == null && marked)
                {
                    targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    destination.position = targetPos;
                    marked = false;
                }
                else if(hit.collider != null && marked)
                {
                    //Debug.Log(hit.collider.gameObject.tag);
                    if (!hit.collider.gameObject.CompareTag("ClickBox"))
                    {
                        targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                        destination.position = targetPos;
                        marked = false;
                    }
                }
            }

            //Cancel move command if drawing window is opened
            if (Input.GetMouseButtonDown(1) && marked)
            {
                marked = false;
            }
            
            if (Vector2.Distance(transform.position, destination.position) > desiredDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination.position, (movementSpeed * Time.deltaTime));
            }
            else
            {
                destination.position = transform.position;
            }
        }
        #endregion

    }
}
