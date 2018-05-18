using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public bool usingKeys = true;
    private bool marked = false;

    private Vector3 targetPosX;
    private Vector3 newPos;

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
                        if (hit.collider.gameObject.CompareTag("Player"))
                        {
                            marked = true;
                        }
                    }
                }

                if (hit.collider == null && marked)
                {
                    targetPosX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, -3f, 0f));

                    newPos = targetPosX;
                    //Debug.Log(newPos.x);
                    marked = false;
                }
            }

            if (newPos != gameObject.transform.position)
            {
                if (Vector3.Distance(gameObject.transform.position, newPos) > 0.2f)
                {
                    Vector2.MoveTowards(gameObject.transform.position, newPos, (movementSpeed * Time.deltaTime));
                }
                else
                {
                    newPos = gameObject.transform.position;
                }
            }
        }
        #endregion

    }
}
