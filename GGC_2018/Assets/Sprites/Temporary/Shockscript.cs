﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockscript : MonoBehaviour {

    public Renderer rend;
    public Vector3 uutela;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Unlit/shockwave");
        uutela = new Vector3(0,0,0);
        transform.localScale = uutela;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        uutela = transform.localScale;
        if (uutela.x > 50)
        {
            uutela = new Vector3(0,0,0);
        }
        else if (uutela.x > 4)
        {
            uutela.x = uutela.x + 0.2f;
            uutela.y = uutela.y + 0.2f;
        }
        else if (uutela.x > 2)
        {
            uutela.x = uutela.x + 0.2f;
            uutela.y = uutela.y + 0.2f;
        }
        else
        {
            uutela.x = uutela.x + 0.2f;
            uutela.y = uutela.y + 0.2f;
        }
        transform.localScale = uutela;
    }
}