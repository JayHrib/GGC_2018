using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class LinusAI : MonoBehaviour
{
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    public BgScroller bgScroller;

    void Start()
    {
        keywordActions.Add("test", Test);
        keywordActions.Add("go left", Left);
        keywordActions.Add("go right", Right);
        keywordActions.Add("go up", Forward);
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
        keywordRecognizer.Start();
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
}