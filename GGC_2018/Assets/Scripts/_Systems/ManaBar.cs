using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class ManaBar : MonoBehaviour
{
    public Image manaBar;

    public static float currentMana;
    private float maxMana;
    public float drainRate = 0.6f;
    public float refillRate = 1f;
    private Demo drawingMode;

    // Use this for initialization
    void Start()
    {
        drawingMode = FindObjectOfType<Demo>();
        currentMana = 0f;
        maxMana = GetComponent<PlayerStats>().maxMana;

    }

    void Update()
    {
        if (currentMana <= 0f)
        {
            currentMana = 0;
        }

        if (drawingMode.GetSlowMoActive())
        {
            DrainMana(drainRate);
        }
        else
        {
            RefillMana(refillRate);
        }

        SetMana(CalculateMana(currentMana));
    }

    public float CalculateMana(float myMana)
    {
        float toReturn;
        toReturn = myMana / maxMana;
        return toReturn;
    }

    public void SetMana(float myMana)
    {
        manaBar.fillAmount = myMana;
    }

    public float GetMana()
    {
        return currentMana;
    }

    private void DrainMana(float amount)
    {
        currentMana -= amount;
        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }

    private void RefillMana(float amount)
    {
        currentMana += (amount * Time.deltaTime);
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }
}
