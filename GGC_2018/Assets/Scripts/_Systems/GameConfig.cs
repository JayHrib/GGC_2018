using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour {

    public static float gameSpeed = 1.0f;
    public bool gameplayIsActive = false;
    private bool playerCanWalk = false;

    public void SetGameplay()
    {
        gameplayIsActive = !gameplayIsActive;
        playerCanWalk = !playerCanWalk;
    }

    public bool GamePlayIsActive()
    {
        return gameplayIsActive;
    }

    public bool PlayerCanWalk()
    {
        return playerCanWalk;
    }
}
