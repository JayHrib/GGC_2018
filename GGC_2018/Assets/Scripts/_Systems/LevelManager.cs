using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static bool active = false;
    public static int deaths = 0;
    private int toll = 0;
    private int time = 0;

    public GameObject enemy_fire;
    List<GameObject> enemies = new List<GameObject>();

    void FixedUpdate()
    {
        if (active == true)
        {
            time++;
            if (time >= 120)
            {
                time = 0;
                int rand = Random.Range(0, 10);
                Spawn(rand);
                toll = 1;
                active = false;
            }
        }
        else if (deaths >= toll)
        {
            deaths = 0;
            toll = 0;
            active = true;
        }
    }

    private void Spawn(int enemy)
    {

    }
}
