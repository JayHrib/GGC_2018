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
    private DictationRecognizer dictationRecognizer;
    private CastSpell spellSpawner;
    private SpellOutlineHandler outlineHandler;
    private float obstaclesMove = -2;

    public BgScroller bgScroller;
    private String[] ObstacleList; 
    void Start()
    {
        /*spellSpawner = FindObjectOfType<CastSpell>();
        keywordActions.Add("test", Test);
        keywordActions.Add("teddy", Left);
        keywordActions.Add("in send dio", Right);
        keywordActions.Add("lightning", Forward);
        keywordActions.Add("go down", Back);
        keywordActions.Add("pause background", PauseBackground);
        keywordActions.Add("start background", StartBackground);
        keywordActions.Add("reset background", ResetBackground);
        keywordActions.Add("exit game", ExitGame);
        keywordActions.Add("restart game", RestartGame);
        keywordActions.Add("turn white", White);
        keywordActions.Add("turn blue", Blue);
        keywordActions.Add("turn red", Red);
        keywordActions.Add("turn green", Green);

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
        keywordRecognizer.Start();*/


        //test dictationRecognizer
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        //dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        //dictationRecognizer.DictationError += DictationRecognizer_DictationError;
        dictationRecognizer.Start();
        ObstacleList = new string[]{"tree","log"};
    }

    /*private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("dictation error:" + error + " hresult: " + hresult);
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        
        Debug.Log("testing dictationHypothesis(get text ):" + text);
    }*/

    #region Voice Commands

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        Debug.Log("testing dictationResult (get text after each pause): " + text + " \nConfidenceLevel: "+confidence.ToString());
        if(text.Contains("move"))
        {

            //check if the is an obstacle in the text
            foreach (string obstacle in ObstacleList)
            {
                foreach (string word in text.Split(' '))
                {           
                    if (word == obstacle)
                    {
                        Debug.Log("word= " + word);
                        ToogleMovementOfVisibleObstaclesWithTag(obstacle);
                        return;
                    }
                }
            }
        }       
    }


    private void Forward()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1);
    }

    private void Back()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1);
    }

    private void PauseBackground()
    {
        BgScroller.active = false;
    }

    private void StartBackground()
    {
        BgScroller.active = true;
    }

    private void ResetBackground()
    {
        bgScroller.Reset();
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void White()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Test()
    {
        print("You said TEST, hopefully it went well");
    }

    private void Left()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y);
    }

    private void Right()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y);
    }



    #endregion


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
        //uppercase the first letter
        char[] tagCharArr = tag.ToCharArray();
        tagCharArr[0] = Char.ToUpper(tagCharArr[0]);

        //find and move obstacle
        obstaclesMove *= -1;
        foreach (GameObject visibleObs in GetAllVisibleObstacles())
        {
            if (visibleObs.CompareTag(new string(tagCharArr)))
            {
                Debug.Log("visible obstacle with tag " + tag + " found!");
                visibleObs.transform.position += new Vector3(obstaclesMove, 0, 0);
            }
        }
    }
    //test end

    #endregion
}