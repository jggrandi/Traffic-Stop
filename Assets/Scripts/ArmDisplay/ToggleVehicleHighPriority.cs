using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displays the Vehicle info if the 

public class ToggleVehicleHighPriority : ToggleHighPriority
{
    // Start is called before the first frame update
    void Start()
    {
        LicenseScanListener.OnReady += ToggleUION;
    }

}
