using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AlertsHandler.TriggerLicenseScan += ShowScanning;
        //AlertsHandler.TriggerResultOfLicenseScan += ShowAlerts;
        AlertsHandler.OnScanDriverLicense += ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult += ShowAlerts;
    }

    void ShowScanning(int _scanCode)
    {
        gameObject.SetActive(true);
        
    }

    void ShowAlerts(int _scanCode)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

    }
}
