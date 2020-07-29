using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Linq;

public class FirefighterListener : MonoBehaviour
{
    public AlertObject.AlertLevel Alert;
    public static Action<GameObject> ShowUI;
    protected FireFighter Firefighter;
    protected static List<Color> colorList = new List<Color>() { Color.red, Color.yellow, Color.green};
    protected static List<FireFighter> FirefighterList = new List<FireFighter>();
    public AlertObject.AlertLevel highestAlert { get; private set; }
    public static FireFighter highestAlertFirefighter { get; private set; }
    // Start is called before the first frame update
    public GameObject[] Firefighters
    {
        get { return FindFirefighters(); }
    }

    private void Start()
    {
        InitalSetup();
        getFirefighter();
        updateColorList();
        updateFirefighterList();
        highestAlert = AlertObject.AlertLevel.none;
    }

    protected void InitalSetup()
    {
        BurningBuildingHandler.UpdateContent += Content;
    }

    protected void getFirefighter()
    {
        Firefighter = ScriptableObject.CreateInstance<FireFighter>();
        Firefighter = transform.gameObject.GetComponent<StoreFirefighterData>().data;
        Firefighter.isPlayer = this.transform.parent.transform == Player.instance.transform;
    }

    protected void Content(GameObject _candidate)
    {
        ShowUI(this.gameObject);
        Firefighter.distance = Distance2Player();
        setAlertLevel(Alert);
        currentHighestAlertlevel();
    }

    protected int Distance2Player()
    {
        return (int)Vector3.Distance(Player.instance.transform.position, this.transform.position);
    }


    //get all firefighters at same floor
    private GameObject[] FindFirefighters()
    {
        List<GameObject> local = GameObject.FindGameObjectsWithTag("Firefighter").ToList();
        local.RemoveAll(NotSameLayer);
        return local.ToArray();
    }

    private bool NotSameLayer(GameObject s)
    {
        return s.layer != Camera.main.gameObject.layer;
    }

    private void OnDisable()
    {
        BurningBuildingHandler.UpdateContent -= Content;
    }

    private void updateFirefighterList()
    {
        if (!FirefighterList.Contains(Firefighter))
        {
            FirefighterList.Add(Firefighter);
        }
    }

    private void updateColorList()
    {

        Color color = randomColor();
        if (Firefighter.isPlayer)
        {
            colorList.Add(Firefighter.color);
            return;
        }
        while (colorList.Contains(color))
        {
            color = randomColor();
        }
        Firefighter.color = color;
        colorList.Add(color);
    }

    private Color randomColor()
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    protected void setAlertLevel(AlertObject.AlertLevel level)
    {
        Firefighter.alertLevel = level;
        FirefighterList.Find(x => x.personInfo.firstName==Firefighter.personInfo.firstName).alertLevel = level;
    }

    private void currentHighestAlertlevel()
    {
        AlertObject.AlertLevel temp = AlertObject.AlertLevel.none;
        FireFighter tempFighter = ScriptableObject.CreateInstance<FireFighter>();
        foreach (FireFighter f in FirefighterList)
        {
            if ((int)f.alertLevel > (int)temp)
            {
                temp = f.alertLevel;
                tempFighter = f;
            }
        }
        highestAlertFirefighter = tempFighter;
        highestAlert = temp;
    }

}
