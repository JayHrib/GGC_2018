using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool usingDragMovement = false;
    public bool inBossScene = false;

    public Transform destination;
    public float desiredDistance;
    private const float LOCKED_Z = -10f;

    public float movementSpeed;
    public bool usingKeys = true;
    private bool marked = false;

    private Vector3 targetPos;
    private ClickListener clickListener;
    //private ClickManager click;
    private GameConfig gameCon;
    private Animator animator;
    private bool locked = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        gameCon = FindObjectOfType<GameConfig>();
        clickListener = FindObjectOfType<ClickListener>();
        //click = new ClickManager();
        if (destination == null)
        {
            Debug.LogWarning("PlayerMovement: No destination marker was found!");
        }
        if (inBossScene)
        {
            gameCon.SetGameplay();
        }
    }
    // Update is called once per frame
    void Update () {
        if (gameCon.PlayerCanWalk() && !locked)
        {
            locked = !locked;
            animator.SetBool("Walking", true);
        }

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

        #region Drag
        if (usingDragMovement && gameCon.GamePlayIsActive())
        {
            // drag controls start
            if (Input.GetMouseButton(0) && marked)
            {
               
                targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                destination.position = targetPos;
            }

            if (Input.GetMouseButtonDown(0))
            {
                //Use mouse clicks if keys aren't being used
                Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit1 = Physics2D.GetRayIntersection(ray1, Mathf.Infinity);

                //Make sure clicked collider isn't empty
                if (hit1.collider != null)
                {
                    if (!marked)
                    {
                        if (hit1.collider.gameObject.CompareTag("ClickBox"))
                        {
                            marked = true;
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
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

        #region DoubleClick
        else if(!usingDragMovement && gameCon.GamePlayIsActive())
        {
         
            //Check for double clicks
            if (clickListener.IsClickedTwice())
            {
                //Set target position based on the clicked location
                targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                destination.position = targetPos;
                clickListener.SetBoolTwice();
            }

            //Move towards target point if it's not close enough
            if (Vector2.Distance(transform.position, destination.position) > desiredDistance)
            {
                if (inBossScene)
                {
                    animator.SetBool("Walking", true);
                }
                transform.position = Vector2.MoveTowards(transform.position, destination.position, (movementSpeed * Time.deltaTime));
            }
            //Reset target position to player position if target has been reached 
            else
            {
                if (inBossScene)
                {
                    animator.SetBool("Walking", false);
                }
                destination.position = transform.position;
            }
            
            
        } 
    }
    #endregion
}
