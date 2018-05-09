using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using System.Text;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpellOutlineHandler))]
public class LinusAI : MonoBehaviour
{
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;
    private CastSpell spellSpawner;
    private SpellOutlineHandler outlineHandler;

    private float obstaclesMove = -2;

    void Start()
    {
        spellSpawner = FindObjectOfType<CastSpell>();
        outlineHandler = FindObjectOfType<SpellOutlineHandler>();

        keywordActions.Add("display fire", DisplayOutlineFire);
        keywordActions.Add("display water", DisplayOutlineWater);
        keywordActions.Add("display nature", DisplayOutlineNature);
        keywordActions.Add("display ice", DisplayOutlineIce);
        keywordActions.Add("display electricity", DisplayOutlineElectricity);
        keywordActions.Add("display air", DisplayOutlineAir);
        keywordActions.Add("display light", DisplayOutlineLight);
        keywordActions.Add("display dark", DisplayOutlineDark);
        keywordActions.Add("display earth", DisplayOutlineEarth);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    #region Outlines

    private void DisplayOutlineFire()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Fire");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Fire");
        }
    }

    private void DisplayOutlineWater()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Water");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Water");
        }
    }

    private void DisplayOutlineIce()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Ice");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Ice");
        }
    }

    private void DisplayOutlineNature()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Nature");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Nature");
        }
    }

    private void DisplayOutlineElectricity()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Electricity");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Electricity");
        }
    }

    private void DisplayOutlineEarth()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Earth");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Earth");
        }
    }

    private void DisplayOutlineLight()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Light");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Light");
        }
    }

    private void DisplayOutlineDark()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Dark");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Dark");
        }
    }

    private void DisplayOutlineAir()
    {
        if (outlineHandler.BeingDisplayed() <= 0)
        {
            outlineHandler.DisplayOutline("Air");
        }
        else
        {
            outlineHandler.HideOutline();
            outlineHandler.DisplayOutline("Air");
        }
    }

    #endregion

    #region Obstacles

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void MoveMarkedObject()
    {
        ToogleMovementOfVisibleObstaclesWithTag("Log");
    }

    //Test: voice recognition input test, move obstacels with voice command


    private List<GameObject> GetAllVisibleObstacles()
    {
        List<GameObject> visibleObstacles = new List<GameObject>();
        foreach (Transform child in GameObject.FindGameObjectWithTag("Obstacles").transform.GetComponentInChildren<Transform>())
        {
            if (child.GetComponent<Renderer>().isVisible)
            {
                visibleObstacles.Add(child.gameObject);
            }
        }
        Debug.Log("visible obstacles count = " + visibleObstacles.Count);
        return visibleObstacles;
    }

    private void ToogleMovementOfVisibleObstaclesWithTag(string tag)
    {
        obstaclesMove *= -1;
        foreach (GameObject visibleObs in GetAllVisibleObstacles())
        {
            if (visibleObs.CompareTag(tag))
            {
                Debug.Log("visible obstacle with tag " + tag + " found!");
                visibleObs.transform.position += new Vector3(obstaclesMove, 0, 0);
            }
        }
    }
    //test end

    #endregion
}