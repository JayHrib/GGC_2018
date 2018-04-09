using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static bool active = false;
    public static int deaths = 0;
    private int toll = 0;
    private int time = 0;

    public GameObject enemy;
    List<Element> elementList = new List<Element>();

    void Start()
    {
        elementList.Add(new Element("Fire"));
        elementList.Add(new Element("Water"));
        elementList.Add(new Element("Ice"));
        elementList.Add(new Element("Earth"));
        elementList.Add(new Element("Electricity"));
        elementList.Add(new Element("The one we dont talk about"));
        elementList.Add(new Element("Wind"));
        foreach (Element i in elementList)
        {
            Debug.Log(i.type);
        }
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            time++;
            if (time >= 120)
            {
                time = 0;
                int rand = Random.Range(0, 6);
                Spawn(rand);
                toll = 1;
                active = false;
            }
        }
        else if (deaths >= toll)
        {
            deaths = 0;
            toll = 0;
            active = true;
        }
    }

    private void Spawn(int elementNumber)
    {
        GameObject go = (GameObject)Instantiate(enemy);
        EnemyStats mystats = go.GetComponent<EnemyStats>();
        mystats.element = elementList[elementNumber].type;
        Debug.Log(elementList[elementNumber].type);
    }

    public class Element
    {
        public string type;

        public Element(string newType)
        {
            type = newType;
        }
    }
}
