using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : MonoBehaviour
{

    public GameObject brackets;
    // Start is called before the first frame update
    void Start()
    {
        //AlertsHandler.TriggerLicenseScan += ShowScanning;
        //AlertsHandler.TriggerResultOfLicenseScan += ShowAlerts;
        AlertsHandler.OnScanDriverLicense += ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult += ShowResultOfScan;
        SpeechRecognitionEngine.onDriverlicenseReturn += ResetBracket;
        //if (gameObject.transform.childCount > 0)
        //    objHighlighter = gameObject.transform.GetChild(0).gameObject;

    }

    void ResetBracket()
    {
        ChangeBracketsColor(Color.white);
    }

    void ShowScanning(int _scanCode)
    {
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
        brackets.SetActive(true);
        //transform.GetChild(0).transform.Rotate(new Vector3(0, 180f, 0)); //face the quad to the
    }


    void ShowResultOfScan(int _scanCode)
    {
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
    }


    void ChangeBracketsColor(Color colorCode)
    {
        //GameObject brackets = objHighlighter.transform.GetChild(0).gameObject;
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicense -= ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult -= ShowResultOfScan;
    }
}
