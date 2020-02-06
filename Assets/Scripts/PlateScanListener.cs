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
        HandleInteractableArea.OnExitInteractableArea += InitalSetup;
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanPlate -= ShowScanning;
        AlertsHandler.OnScanPlateResult -= ShowResultOfScan;
        HandleInteractableArea.OnExitInteractableArea -= InitalSetup;
    }

}
