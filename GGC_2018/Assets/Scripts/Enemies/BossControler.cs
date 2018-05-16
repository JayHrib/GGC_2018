﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeftLegs
{
    public GameObject leg;
}

[System.Serializable]
public class RightLegs
{
    public GameObject leg;
}

public class BossControler : MonoBehaviour {

    [SerializeField]
    LeftLegs[] LeftList;

    [SerializeField]
    RightLegs[] RightList;

    public bool leftKill = false;
    public bool rightKill = false;
    public int leftkills = 0;
    public int rightkills = 0;

    public GameObject bulletspawner;
    private int timer = 0;
    private int limit = 120;

    // Use this for initialization
    void Start () {
        ChooseLegLeft();
        ChooseLegRight();
	}
	
	// Update is called once per frame
	void Update () {
        if(leftkills > 3 && rightkills > 3)
        {
            gameObject.GetComponentInChildren<BossAI>().vulnerable = true;
            bulletspawner.GetComponent<BulletSpawner>().active = true;
            timer++;
            if (timer > limit)
            {
                timer = 0;
                limit = Random.Range(90, 480);
                if (bulletspawner.GetComponent<BulletSpawner>().direction == 1)
                {
                    bulletspawner.GetComponent<BulletSpawner>().direction = -1;
                    bulletspawner.GetComponent<BulletSpawner>().discord = 3;
                }
                else
                {
                    bulletspawner.GetComponent<BulletSpawner>().direction = 1;
                    bulletspawner.GetComponent<BulletSpawner>().discord = 1;
                }
            }
        }
        else
        {
            timer++;
            if (timer > limit)
            {
                timer = 0;
                limit = Random.Range(90, 480);
                if (bulletspawner.GetComponent<BulletSpawner>().active)
                {
                    bulletspawner.GetComponent<BulletSpawner>().active = false;
                }
                else
                {
                    bulletspawner.GetComponent<BulletSpawner>().active = true;
                    int temp1 = Random.Range(-1, 2);
                    if(temp1 > 1)
                    {
                        temp1 = 1;
                    }
                    int temp2 = temp1;
                    if (temp1 == 0)
                    {
                        temp2 = 1;
                    }
                    if(temp2 <= 0)
                    {
                        temp2 = 2;
                    }
                    bulletspawner.GetComponent<BulletSpawner>().direction = temp1;
                    bulletspawner.GetComponent<BulletSpawner>().discord = temp2 * 3;
                }
            }
        }


        if (leftKill)
        {
            if (leftkills < 4)
            {
                ChooseLegLeft();
            }
            leftKill = false;
        }
        if (rightKill)
        {
            if (rightkills < 4)
            {
                ChooseLegRight();
            }
            rightKill = false;
        }
    }

    void ChooseLegLeft()
    {
        int temp = Random.Range(0, LeftList.Length);
        if (LeftList[temp].leg.activeInHierarchy != true)
        {
            ChooseLegLeft();
        }
        else
        {
            LeftList[temp].leg.GetComponent<BossLeg>().active = true;
        }
    }

    void ChooseLegRight()
    {
        int temp = Random.Range(0, RightList.Length);
        if (RightList[temp].leg.activeInHierarchy != true)
        {
            ChooseLegRight();
        }
        else
        {
            RightList[temp].leg.GetComponent<BossLeg>().active = true;
        }
    }
}
