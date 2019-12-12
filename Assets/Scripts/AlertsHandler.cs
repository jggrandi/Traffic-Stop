using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsHandler : Raycaster
{

    public delegate void OnAlertDelegate();
    public static OnAlertDelegate triggerScanPlate;


    protected override void OnRaycasterEnter(GameObject target)
    {
        if (target.gameObject.name == "PlateTrigger")
            triggerScanPlate();
    }



}
