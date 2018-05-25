using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour {

    private EnvironmentManager e_manager;
    public string environment = "";
    public AudioClip environmentMusic;
    private bool fade = false;
    private float aproxTimeToFade = 2;
    private AudioSource audioSourceTmp;

	void Start()
    {
        e_manager = FindObjectOfType<EnvironmentManager>();
        audioSourceTmp = Camera.main.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetNewEnvironment(environment);
        }
    }

    void SetNewEnvironment(string newEnvironment)
    {
        e_manager.SetPool(newEnvironment);
        fade = true;     
    }

    private void FixedUpdate()
    {
        if(fade) //if statement to fade current song and play the next one.
        {   
            if (aproxTimeToFade > 0)
            {            
                audioSourceTmp.volume -= 0.01f;
                aproxTimeToFade -= Time.deltaTime;
            }
            else
            {
                fade = false;
                aproxTimeToFade = 2;
                //Debug.Log("Now Stoping current song and Playing nxt song");
                audioSourceTmp.Stop();
                audioSourceTmp.clip = environmentMusic;
                audioSourceTmp.volume = 1;
                audioSourceTmp.Play();
            }
        }
    }
}
