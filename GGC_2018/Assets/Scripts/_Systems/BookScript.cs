using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script is used to switch between different pages in the main menu*/

//NOTE!
//This script will most likely be heavily edited when the new menu is implemented

[System.Serializable]
public class Book
{
    public string name;
    public GameObject book;
}

public class BookScript : MonoBehaviour {

    [SerializeField]
    Book[] books;

    private string currentBook = "";
    public GameObject pickAChar;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Character"))
        {
            PlayerPrefs.DeleteKey("Character");
        }
    }

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("health", 100);
		if (books == null)
        {
            Debug.LogError("BookScript: Something went wrong, 'books' array is empty!");
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].book.activeInHierarchy)
            {
                currentBook = books[i].name;
                break;
            }
        }
	}
	
	public void FlipToMenu()
    {
        if (currentBook != books[0].name)
        {
            ActivateNext("Main");
            if (!pickAChar.activeInHierarchy)
            {
                pickAChar.SetActive(true);
            }
            DeactivateCurrent(currentBook);
            currentBook = "Main";
        }
    }

    public void FlipToControls()
    {
        if (currentBook != books[1].name)
        {
            ActivateNext("Controls");
            DeactivateCurrent(currentBook);
            currentBook = "Controls";
        }
    }

    public void FlipToCredits()
    {
        if (currentBook != books[2].name)
        {
            ActivateNext("Credits");
            DeactivateCurrent(currentBook);
            currentBook = "Credits";
        }
    }

    private void DeactivateCurrent(string name)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].name == name)
            {
                books[i].book.SetActive(false);
                break;
            }
        }
    }

    private void ActivateNext(string name)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].name == name)
            {
                books[i].book.SetActive(true);
                break;
            }
        }
    }

    public void SetCharacter(string character)
    {
        if (PlayerPrefs.HasKey("Character"))
        {
            PlayerPrefs.DeleteKey("Character");
            PlayerPrefs.SetString("Character", character);
        }
        else
        {
            PlayerPrefs.SetString("Character", character);
        }
    }

    public void PickedBartholomew()
    {
        SetCharacter("Bartholomew");
    }

    public void PickedBokaj()
    {
        SetCharacter("Bokaj");
    }
}
