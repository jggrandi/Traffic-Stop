using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDriverHighPriority : ToggleHighPriority
{
    // Start is called before the first frame update
    void Start()
    {
        LicenseScanListener.OnReady += ToggleUION;
    }

}
