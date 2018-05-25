using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour {

    private float doubleClickTimeLimit = 0.25f;
    private bool clickedOnce = false;
    private bool clickedTwice = false;
    private bool loop = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(InputListener());
	}

    private IEnumerator InputListener()
    {
        while (enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                yield return ClickEvent();
            }

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }

            count += Time.deltaTime;
            yield return null;
        }

        SingleClick();
    }

    private void DoubleClick()
    {
        clickedTwice = !clickedTwice;
    }

    private void SingleClick()
    {
        clickedOnce = !clickedOnce;
    }

    public void SetBoolOnce()
    {
        clickedOnce = !clickedOnce;
    }

    public void SetBoolTwice()
    {
        clickedTwice = !clickedTwice;
    }

    public bool IsClickedOnce()
    {
        return clickedOnce;
    }

    public bool IsClickedTwice()
    {
        return clickedTwice;
    }
}
