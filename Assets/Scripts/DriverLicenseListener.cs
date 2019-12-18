using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : MonoBehaviour
{
    GameObject objHighlighter;
    // Start is called before the first frame update
    void Start()
    {
        //AlertsHandler.TriggerLicenseScan += ShowScanning;
        //AlertsHandler.TriggerResultOfLicenseScan += ShowAlerts;
        AlertsHandler.OnScanDriverLicense += ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult += ShowResultOfScan;

        if (gameObject.transform.childCount > 0)
            objHighlighter = gameObject.transform.GetChild(0).gameObject;

    }

    void ShowScanning(int _scanCode)
    {
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
        objHighlighter.SetActive(true);
        //objHighlighter.transform.GetChild(0).transform.Rotate(new Vector3(0, 180f, 0)); //face the quad to the
    }


    void ShowResultOfScan(int _scanCode)
    {
        HideScanBar();
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
    }


    void ChangeBracketsColor(Color colorCode)
    {
        GameObject brackets = objHighlighter.transform.GetChild(0).gameObject;
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }

    void HideScanBar()
    {
        GameObject scanBar = objHighlighter.transform.GetChild(1).gameObject;
        scanBar.SetActive(false);
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicense -= ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult -= ShowResultOfScan;
    }
}
