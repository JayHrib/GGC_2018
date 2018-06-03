using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private bool inBossScene = false;

    public Transform destination;
    public float desiredDistance;
    private const float LOCKED_Z = -10f;

    public float movementSpeed;
    private bool marked = false;

    private Vector3 targetPos;
    private Scene currentScene;
   
   
    private GameConfig gameCon;
    private Animator animator;
    private bool locked = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        gameCon = FindObjectOfType<GameConfig>();
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Boss Test")
        {
            inBossScene = true;
        }
    
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
    void Update()
    {
        if (gameCon.PlayerCanWalk() && !locked)
        {
            locked = !locked;
            animator.SetBool("Walking", true);
        }

        #region Movement
        if (gameCon.GamePlayIsActive())
        {

            if (Input.GetMouseButtonDown(0))
            {
                Mark();
            }

            // drag controls start
            if (Input.GetMouseButton(0) && marked)
            {
                targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                destination.position = targetPos;
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
    }

    private void Mark()
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
}
