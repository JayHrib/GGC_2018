using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject promptText;

    void Start()
    {
        PlayerPrefs.SetFloat("health", 100);
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetString("Character") == "Bartholomew" || PlayerPrefs.GetString("Character") == "Bokaj")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            if (!promptText.activeInHierarchy)
            {
                promptText.SetActive(true);
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
