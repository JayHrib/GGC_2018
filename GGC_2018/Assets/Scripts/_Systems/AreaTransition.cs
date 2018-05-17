using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour {

    private EnvironmentManager e_manager;
    public string environment = "";
	
	void Start()
    {
        e_manager = FindObjectOfType<EnvironmentManager>();
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
    }
}
