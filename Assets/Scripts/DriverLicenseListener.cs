using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.TriggerLicenseScan += ShowScanning;
        AlertsHandler.TriggerResultOfLicenseScan += ShowAlerts;
    }

    void ShowScanning()
    {
        gameObject.SetActive(true);
        
    }

    void ShowAlerts()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

    }
}
