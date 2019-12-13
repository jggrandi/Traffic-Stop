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
        //change the brackets material color to inform that the system scanned the plate and the car is good.
    }

}
