using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlateListener : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.TriggerScanPlate += ShowARPlate;
        AlertsHandler.TriggerResultOfPlateScan += HideScanBar;
        AlertsHandler.TriggerResultOfPlateScan += ChangeBracketsColor;
    }

    void ShowARPlate()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject g = gameObject.transform.GetChild(i).gameObject;
            g.SetActive(true);
        }
    }

    void HideScanBar()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    void ChangeBracketsColor()
    {
        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
    }

}
