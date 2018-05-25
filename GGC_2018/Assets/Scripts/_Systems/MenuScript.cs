using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void StartGame()
    {
        if (PlayerPrefs.GetString("Character") == "Bartholomew" || PlayerPrefs.GetString("Character") == "Bokaj")
        {
            SceneManager.LoadScene(1);
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
