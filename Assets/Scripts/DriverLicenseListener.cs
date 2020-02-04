using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : UIScanListner
{

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanDriverLicense += ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult += ShowResultOfScan;
        SpeechRecognitionEngine.onDriverlicenseReturn += ResetBracketColor;

    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicense -= ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult -= ShowResultOfScan;
    }
}
