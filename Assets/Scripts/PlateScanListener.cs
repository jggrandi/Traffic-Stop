using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlateScanListener : MonoBehaviour
{

    GameObject objHighlighter;

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanPlate += ShowARScanning;
        AlertsHandler.OnScanPlateResult += ShowResultOfScan;

        //AlertsHandler.TriggerScanPlate += ShowARPlate;
        //AlertsHandler.TriggerResultOfPlateScan += HideScanBar;
        //AlertsHandler.TriggerResultOfPlateScan += ChangeBracketsColor;

        if (gameObject.transform.childCount > 0)
            objHighlighter = gameObject.transform.GetChild(0).gameObject;
    }

    void ShowARScanning( int _scanCode)
    {
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
        objHighlighter.SetActive(true);

    }

    void ShowResultOfScan(int _scanCode)
    {
        HideScanBar();
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
        objHighlighter.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 0)); //face the quad to the
    }

    void HideScanBar()
    {
        GameObject scanBar = objHighlighter.transform.GetChild(1).gameObject;
        scanBar.SetActive(false);
    }

    void ChangeBracketsColor(Color colorCode)
    {
        GameObject brackets = objHighlighter.transform.GetChild(0).gameObject;
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanPlate -= ShowARScanning;
        AlertsHandler.OnScanPlateResult -= ShowResultOfScan;
    }

}
