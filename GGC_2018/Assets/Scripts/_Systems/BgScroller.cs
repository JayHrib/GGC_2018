using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour {

    public static bool active;
    public float speed;
    private GameObject player;
    private RaycastHit2D hit;
    private int layerMask;
    public float boost;
    private float movementSpeedBoost;
    private float originalSpeed;

    void Start()
    {
        active = true;
        movementSpeedBoost = speed * boost;
        originalSpeed = speed;
        layerMask = LayerMask.GetMask("Ground");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y - (0.05f * GameConfig.gameSpeed * (speed * Time.deltaTime)));
            transform.position = newpos;
            if (transform.position.y <= (-92))
            {
                speed = 0;
            }
        }
        CheckSurface();
    }

    private void CheckSurface()
    {
        hit = Physics2D.Raycast(player.transform.position, Vector2.down, 1, layerMask);
        //Debug.DrawRay(transform.position, Vector2.down, Color.red);

        if (hit.collider != null)//if the object that was hit goes by the name "Player" then:
        {
            if (hit.collider.CompareTag("Road"))
            {
                speed = movementSpeedBoost;
            }

        }
        else
        {
            speed = originalSpeed;
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 55, 0);
    }


}
