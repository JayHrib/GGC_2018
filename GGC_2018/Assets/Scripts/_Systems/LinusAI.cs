using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using System.Text;
using UnityEngine.SceneManagement;

public class LinusAI : MonoBehaviour
{
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;
    private DictationRecognizer dictationRecognizer;
    private CastSpell spellSpawner;
    private float obstaclesMove = -2;

    public BgScroller bgScroller;
    private String[] ObstacleList; 
    void Start()
    {
        /*spellSpawner = FindObjectOfType<CastSpell>();

       
        keywordActions.Add("I'll hit you where the sun don't shine", Dark);
        keywordActions.Add("empty quotes kills the man", Earth);
        keywordActions.Add("silent but deadly", Air);
        keywordActions.Add("Praise the sun", Light);
        keywordActions.Add("why dont you make like a leaf and blow away", Nature);
        keywordActions.Add("Thunder bolt", Electricity);
        keywordActions.Add("How much does a polar bear weigh", Ice);
        keywordActions.Add("would you like to get moist my friend", Water);
        keywordActions.Add("i am about to drop my mixtape", Fire);
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

    private void Blue()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
    }

    private void Red()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    private void Green()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    private void Fire()
    {
        spellSpawner.FireSpell("Fire");
    }

    private void Water()
    {
        spellSpawner.FireSpell("Water");
    }

    private void Ice()
    {
        spellSpawner.FireSpell("Ice");
    }

    private void Electricity()
    {
        spellSpawner.FireSpell("Electricity");
    }

    private void Nature()
    {
        spellSpawner.FireSpell("Nature");
    }

    private void Light()
    {
        spellSpawner.FireSpell("Light");
    }

    private void Air()
    {
        spellSpawner.FireSpell("Air");
    }

    private void Earth()
    {
        spellSpawner.FireSpell("Earth");
    }

    private void Dark()
    {
        spellSpawner.FireSpell("Dark");
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


}