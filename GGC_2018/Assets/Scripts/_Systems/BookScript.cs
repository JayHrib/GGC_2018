using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Book
{
    public string name;
    public Image book;
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

        currentBook = books[0].name;
	}
	
	public void FlipToMenu()
    {
        if (currentBook != books[0].name)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].name == "Main")
                {
                    //Play flipping animation
                    //Activate other book
                    //Deactivate current book
                    Debug.Log("Flipping to Main");
                    currentBook = books[i].name;
                    break;
                }
            }
        }
    }

    public void FlipToControls()
    {
        if (currentBook != books[1].name)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].name == "Controls")
                {
                    //Play flipping animation
                    //Activate other book
                    //Deactivate current book
                    Debug.Log("Flipping to Controls");
                    currentBook = books[i].name;
                    break;
                }
            }
        }
    }

    public void FlipToStory()
    {
        if (currentBook != books[2].name)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].name == "Story")
                {
                    //Play flipping animation
                    //Activate other book
                    //Deactivate current book
                    Debug.Log("Flipping to Story");
                    currentBook = books[i].name;
                    break;
                }
            }
        }
    }

    public void FlipToCredits()
    {
        if (currentBook != books[3].name)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].name == "Credits")
                {
                    //Play flipping animation
                    //Activate other book
                    //Deactivate current book
                    Debug.Log("Flipping to Credits");
                    currentBook = books[i].name;
                    break;
                }
            }
        }
    }

    private void DeactivateCurrent(string name)
    {

    }

    private void ActivateNext(string name)
    {

    }

    private void PlayAnimation(string direction)
    {

    }
}
