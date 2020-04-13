using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVehicleHighPriority : ToggleHighPriority
{
    // Start is called before the first frame update
    void Start()
    {
        LicenseScanListener.OnReady += ToggleUION;
    }

}
