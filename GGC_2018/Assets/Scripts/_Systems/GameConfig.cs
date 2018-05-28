using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour {

    public static float gameSpeed = 1.0f;
    private bool gameplayIsActive = false;

    public void SetGameplay()
    {
        gameplayIsActive = !gameplayIsActive;
    }

    public bool GamePlayIsActive()
    {
        return gameplayIsActive;
    }
}
