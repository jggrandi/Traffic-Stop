using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlateScanListener : UIScanListner
{

    GameObject objHighlighter;

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanPlate += ShowScanning;
        AlertsHandler.OnScanPlateResult += ShowResultOfScan;

        //if (gameObject.transform.childCount > 0)
        //    objHighlighter = gameObject.transform.GetChild(0).gameObject;
    }



    //void ShowResultOfScan(int _scanCode)
    //{
    //    HideScanBar();
    //    Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
    //    ChangeBracketsColor(alertColor);
    //    objHighlighter.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 0)); //face the quad to the
    //}

    //void HideScanBar()
    //{
    //    GameObject scanBar = objHighlighter.transform.GetChild(1).gameObject;
    //    scanBar.SetActive(false);
    //}


    private void OnDisable()
    {
        AlertsHandler.OnScanPlate -= ShowScanning;
        AlertsHandler.OnScanPlateResult -= ShowResultOfScan;
    }

}
