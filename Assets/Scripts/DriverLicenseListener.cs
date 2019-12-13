using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLicenseListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpeechRecognitionEngine.EnableDriverLicense += ShowDriverLicense;
        //AlertsHandler.TriggerResultOfLicenseScan += 
    }

    void ShowDriverLicense()
    {
        Debug.Log("AAsasdasdasdasdasd");
        gameObject.SetActive(true);
    }
}
