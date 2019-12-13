using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsHandler : Raycaster
{

    public delegate void OnAlertDelegate();
    public static OnAlertDelegate TriggerScanPlate;
    public static OnAlertDelegate TriggerResultOfPlateScan;

    private IEnumerator coroutine;

    bool plateAlreadyTriggered = false;

    protected override void OnRaycasterEnter(GameObject target)
    {
        if (target.gameObject.name == "PlateTrigger" && !plateAlreadyTriggered)
        {
            TriggerScanPlate();
            plateAlreadyTriggered = true;
            coroutine = Wait(4f);
            StartCoroutine(coroutine);
        }
    }


    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TriggerResultOfPlateScan();

    }


}
