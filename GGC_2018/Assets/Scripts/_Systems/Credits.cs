using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public GameObject TeamPanel;
    public GameObject MusicPanel;

    private GameObject currentObj;

    void Start()
    {
        currentObj = TeamPanel;
    }

	public void FlipToMusic()
    {
        if (currentObj == TeamPanel)
        {
            MusicPanel.SetActive(true);
            currentObj.SetActive(false);

            currentObj = MusicPanel;
        }
    }

    public void FlipToTeam()
    {
        if (currentObj = MusicPanel)
        {
            TeamPanel.SetActive(true);
            currentObj.SetActive(false);

            currentObj = TeamPanel;
        }
    }
}
