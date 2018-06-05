using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject promptText;
    public GameObject smokescreen;
    private GameObject startButton;

    void Start()
    {
        PlayerPrefs.SetFloat("health", 100);
        startButton = GameObject.Find("StartButton");
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetString("Character") == "Bartholomew" || PlayerPrefs.GetString("Character") == "Bokaj")
        {
            Instantiate(smokescreen, transform.position, Quaternion.identity);
        }
        else
        {
            if (!promptText.activeInHierarchy)
            {
                promptText.SetActive(true);
                ColorBlock cb = startButton.GetComponent<Button>().colors;
                cb.normalColor = cb.highlightedColor;
                startButton.GetComponent<Button>().colors = cb;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
