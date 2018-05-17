using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLasorParticle : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Color color = transform.GetComponentInParent<BossLasor>().color;
        color.a = 0.5f;
        ParticleSystem.MainModule settings = gameObject.GetComponent<ParticleSystem>().main;
        settings.startColor = color;
    }
}
