using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject promptText;
    public GameObject smokescreen;

    void Start()
    {
        PlayerPrefs.SetFloat("health", 100);
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
