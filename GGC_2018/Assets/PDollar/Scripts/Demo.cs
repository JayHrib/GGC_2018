using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using PDollarGestureRecognizer;

public class Demo : MonoBehaviour {

    public bool devMode = false;

    public Transform gestureOnScreenPrefab;

    private List<Gesture> trainingSet = new List<Gesture>();

    private List<Point> points = new List<Point>();
    private int strokeId = -1;

    private Vector3 virtualKeyPosition = Vector2.zero;
    private Rect drawArea;

    private RuntimePlatform platform;
    private int vertexCount = 0;

    private List<LineRenderer> gestureLinesRenderer = new List<LineRenderer>();
    private LineRenderer currentGestureLineRenderer;

    //GUI
    private string message;
    private bool recognized;
    private string newGestureName = "";

    //Custom 
    private CastSpell spellSpawner;

    private bool displayDrawing = false;
    private bool drawnWellEnough = false;
    private bool drawing = false;

    private const float REQUIRED_SCORE = 0.2f;
    private GameObject spellCheck;
    private ManaBar mana;

    private bool ductTape = false;
    private CastingManager castManager;
    private ClickListener clickListener;

    void Start() {
        spellSpawner = FindObjectOfType<CastSpell>();
        mana = FindObjectOfType<ManaBar>();
        castManager = FindObjectOfType<CastingManager>();
        clickListener = FindObjectOfType<ClickListener>();

        //Create platform of which to draw on
        platform = Application.platform;

        //Load gesture templates
        TextAsset[] filePaths = Resources.LoadAll<TextAsset>("CustomGestureSet/");
        foreach (TextAsset filePath in filePaths)
            trainingSet.Add(GestureIO.ReadGestureFromXML(filePath.text));
    }

    void Update() {
        #region GamePlay
        if (!devMode)
        {
            //Create draw area
            if (Input.GetMouseButtonDown(0))
            {
                displayDrawing = true;
                drawArea = new Rect(0, 0, Screen.width, Screen.height);
            }

            if (Input.GetMouseButton(0))
            {
                
                if (mana.GetMana() > 50)
                {
                    ductTape = true;
                }
                if (ductTape)
                {
                    GameConfig.gameSpeed = 0.25f;
                }
                else
                {
                    GameConfig.gameSpeed = 1;
                }

                if (mana.GetMana() < 1f)
                {
                    GameConfig.gameSpeed = 1f;
                    ductTape = false;
                }
                
            }

            //Destroy draw area
            if (Input.GetMouseButtonUp(0))
            {
                GameConfig.gameSpeed = 1f;
                ductTape = false;

                displayDrawing = false;

                if (drawing)
                {
                    recognized = true;

                    Gesture candidate = new Gesture(points.ToArray());
                    Result gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());

                    message = gestureResult.GestureClass + " " + gestureResult.Score;
                    Debug.Log(gestureResult.Score);
                    Debug.Log(gestureResult.GestureClass);
                    if (gestureResult.Score > REQUIRED_SCORE)
                    {
                        if (!drawnWellEnough)
                        {
                            drawnWellEnough = true;
                        }
                        if (castManager.activeSpells < 1)
                        {
                            spellSpawner.FireSpell(gestureResult.GestureClass);
                            castManager.activeSpells++;
                        }
                    }
                    else
                    {
                        if (drawnWellEnough)
                        {
                            drawnWellEnough = false;
                        }
                    }

                    drawing = false;
                }

                //Use to remove area
                drawArea = new Rect(0, 0, 0, 0);
            }
        }
        #endregion

        #region DevMode
        else
        {
            //Create draw area
            if (Input.GetMouseButtonDown(1))
            {
               
                displayDrawing = true;

                drawArea = new Rect(0, 0, Screen.width, Screen.height);
                
            }

            if (Input.GetMouseButton(1))
            {
                if (mana.GetMana() > 50)
                {
                    ductTape = true;
                }
                if (ductTape)
                {
                    GameConfig.gameSpeed = 0.25f;
                }
                else
                {
                    GameConfig.gameSpeed = 1;
                }

                if (mana.GetMana() < 1f)
                {
                    GameConfig.gameSpeed = 1f;
                    ductTape = false;
                }
            }

            //Destroy draw area
            if (Input.GetMouseButtonUp(1))
            {
                GameConfig.gameSpeed = 1f;
                ductTape = false;

                displayDrawing = false;

                if (drawing)
                {
                    recognized = true;

                    Gesture candidate = new Gesture(points.ToArray());
                    Result gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());

                    message = gestureResult.GestureClass + " " + gestureResult.Score;
                    Debug.Log(gestureResult.Score);
                    Debug.Log(gestureResult.GestureClass);
                    if (gestureResult.Score > REQUIRED_SCORE)
                    {
                        if (!drawnWellEnough)
                        {
                            drawnWellEnough = true;
                        }
                        if (castManager.activeSpells < 1)
                        {
                            spellSpawner.FireSpell(gestureResult.GestureClass);
                            castManager.activeSpells++;
                        }
                    }
                    else
                    {
                        Debug.Log("Too poorly drawn");
                        if (drawnWellEnough)
                        {
                            drawnWellEnough = false;
                        }
                    }

                    drawing = false;
                }

                //Use to remove area
                drawArea = new Rect(0, 0, 0, 0);
            }
        }
        #endregion


        #region DetermineInputDevicePos

        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                virtualKeyPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
            }
        } else {

            if (Input.GetMouseButton(0))
            {
                virtualKeyPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            }
        }
        #endregion

        #region MouseIsUsed
        //Checks if the mouse is within the draw area 
        if (drawArea.Contains(virtualKeyPosition)) {

            if (Input.GetMouseButtonDown(0))
            {
                Transform tmpGesture = Instantiate(gestureOnScreenPrefab, transform.position, transform.rotation) as Transform;
                currentGestureLineRenderer = tmpGesture.GetComponent<LineRenderer>();

                
                ++strokeId;

                gestureLinesRenderer.Add(currentGestureLineRenderer);

                vertexCount = 0;
                
            }

            if (Input.GetMouseButton(0))
            {
                
                if (!drawing)
                {
                    drawing = true;
                }

                points.Add(new Point(virtualKeyPosition.x, -virtualKeyPosition.y, strokeId));

                currentGestureLineRenderer.SetVertexCount(++vertexCount);
                currentGestureLineRenderer.SetPosition(vertexCount - 1, Camera.main.ScreenToWorldPoint(new Vector3(virtualKeyPosition.x, virtualKeyPosition.y, 10)));
                
            }

            #endregion
        }

        //Compare and clean drawings when drawing area is removed
        if (!displayDrawing)
        {
            recognized = false;
            strokeId = -1;

            points.Clear();

            foreach (LineRenderer lineRenderer in gestureLinesRenderer)
            {
                lineRenderer.SetVertexCount(0);
                Destroy(lineRenderer.gameObject);
            }

            gestureLinesRenderer.Clear();
        }
    }


    void OnGUI() {
        if (devMode)
        {
            GUI.color = new Color(1, 1, 1, 1);
        }
        else
        {
            GUI.color = new Color(0, 0, 0, 0);
        }
        GUI.Box(drawArea, " ");

        if (devMode)
        {
            GUI.Label(new Rect(10, Screen.height - 40, 500, 50), message);

            if (GUI.Button(new Rect(Screen.width - 100, 10, 100, 30), "Recognize"))
            {

                recognized = true;

                Gesture candidate = new Gesture(points.ToArray());
                Result gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());

                message = gestureResult.GestureClass + " " + gestureResult.Score;
                if (gestureResult.Score > 0.7f)
                {
                    Debug.Log("Spell has been cast!");
                    if (!drawnWellEnough)
                    {
                        drawnWellEnough = true;
                    }

                    Debug.Log(gestureResult.GestureClass + " spell has been cast!");
                }
                else
                {
                    Debug.Log("Too poorly drawn");
                    if (drawnWellEnough)
                    {
                        drawnWellEnough = false;
                    }
                }
            }
        }

        if (devMode)
        {
            GUI.Label(new Rect(Screen.width - 200, 150, 70, 30), "Add as: ");
            newGestureName = GUI.TextField(new Rect(Screen.width - 150, 150, 100, 30), newGestureName);

            if (GUI.Button(new Rect(Screen.width - 50, 150, 50, 30), "Add") && points.Count > 0 && newGestureName != "")
            {
                //Stores the new gestures
                string fileName = String.Format("{0}/{1}-{2}.xml", "Assets/PDollar/Resources/CustomGestureSet", newGestureName, DateTime.Now.ToFileTime());

                #if !UNITY_WEBPLAYER
                GestureIO.WriteGesture(points.ToArray(), newGestureName, fileName);
                #endif

                trainingSet.Add(new Gesture(points.ToArray(), newGestureName));

                newGestureName = "";
            }
        }
    }

    public bool GetSlowMoActive()
    {
        return ductTape;
    }

    private void CheckClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("ClickBox"))
            {
                allowedToDraw = false;
            }
            else
            {
                allowedToDraw = true;
            }
        }
        else
        {
            allowedToDraw = true;
        }
       
    }
}

