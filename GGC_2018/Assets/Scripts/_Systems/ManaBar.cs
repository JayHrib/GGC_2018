using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    private GameObject target;
    private Image bar;

    public static float mana;

    // Use this for initialization
    void Start()
    {

        target = gameObject.transform.parent.parent.gameObject;
        bar = gameObject.GetComponent<Image>();
        gameObject.GetComponent<Image>().color = new Color(0, 0, 1, 1);
        mana = 0;

    }

    void Update()
    {

        Vector3 newpos = target.transform.position;
        if (target.GetComponent<PlayerStats>() != null)
        {
            newpos.y = newpos.y + 2.1f;
        }
        transform.position = newpos;
        mana = mana + 0.3f;
        if (mana > 100)
        {
            mana = 100;
        }
        bar.fillAmount = mana / 100;

    }
}
