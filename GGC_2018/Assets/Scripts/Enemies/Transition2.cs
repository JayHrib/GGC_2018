using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition2 : MonoBehaviour {

    public float visibility = 0;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer + 0.0001f;
        visibility = visibility + timer;
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, visibility);
        if (visibility > 2)
        {
            SceneManager.LoadScene(1);
        }
    }
}
