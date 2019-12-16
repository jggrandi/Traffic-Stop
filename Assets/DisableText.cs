using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanPlateResult += DisableInstructions;
        //AlertsHandler.TriggerResultOfPlateScan += DisableInstructions;
    }

    void DisableInstructions(int _scanCode)
    {
        gameObject.SetActive(false);
    }
}
