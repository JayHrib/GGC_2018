using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using RawMouseDriver;
using RawInputSharp;

public class MultipleMiceTest : MonoBehaviour {

    private RawMouseDriver.RawMouseDriver mouseDriver;
    private RawMouse[] mice;
    private Vector2[] move;
    private const int NUM_MICE = 2;

    void Start()
    {
        mouseDriver = new RawMouseDriver.RawMouseDriver();
        mice = new RawMouse[NUM_MICE];
        move = new Vector2[NUM_MICE];
    }

    void Update()
    {
        for (int i = 0; i < mice.Length; i++)
        {
            try
            {
                mouseDriver.GetMouse(i, ref mice[i]);
                move[i] += new Vector2(mice[i].XDelta, -mice[i].YDelta);
            }
            catch
            {

            }
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Connected Mice:");
        for (int i = 0; i < mice.Length; i++)
        {
            if (mice[i] != null)
                GUILayout.Label("Mouse[" + i.ToString() + "] : " + move[i] + mice[i].Buttons[0] + mice[i].Buttons[1]);
        }
    }

    void OnApplicationQuit()
    {
        mouseDriver.Dispose();
    }
}
