using System.Collections;
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
