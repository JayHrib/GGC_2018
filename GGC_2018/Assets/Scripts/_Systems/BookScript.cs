using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {
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

    public void FlipToStory()
    {
        if (currentBook != books[2].name)
        {
            ActivateNext("Story");
            DeactivateCurrent(currentBook);
            currentBook = "Story";
        }
    }

    public void FlipToCredits()
    {
        if (currentBook != books[3].name)
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

    private void PlayAnimation(string direction)
    {

    }
}
