using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour {

    private float doubleClickTimeLimit = 0.25f;

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
        Debug.Log("Double click");
    }

    private void SingleClick()
    {
        Debug.Log("Signle click");
    }
}
