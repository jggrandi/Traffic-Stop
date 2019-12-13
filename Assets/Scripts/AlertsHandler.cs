using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsHandler : Raycaster
{

    public delegate void OnAlertDelegate();
    public static OnAlertDelegate TriggerScanPlate;
    public static OnAlertDelegate TriggerScanDriver;
    public static OnAlertDelegate TriggerResultOfPlateScan;
    public static OnAlertDelegate TriggerLicenseScan;
    public static OnAlertDelegate TriggerResultOfLicenseScan;

    private IEnumerator coroutine;

    bool plateAlreadyTriggered = false;
    bool driverLicenseAlreadyTriggered = false;

    protected override void OnRaycasterEnter(GameObject target)
    {
        if (target.gameObject.name == "PlateTrigger" && !plateAlreadyTriggered)
        {
            TriggerScanPlate();
            plateAlreadyTriggered = true;
            coroutine = Wait(4f);
            StartCoroutine(coroutine);
        }

        if (target.gameObject.name == "DriverTrigger" && !driverLicenseAlreadyTriggered)
        {
            TriggerLicenseScan();
            coroutine = Wait2(4f);
            StartCoroutine(coroutine);
            driverLicenseAlreadyTriggered = true;
        }

    }


    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TriggerResultOfPlateScan();

    }

    private IEnumerator Wait2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TriggerResultOfLicenseScan();

    }


}
