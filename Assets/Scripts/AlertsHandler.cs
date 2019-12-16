using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlertsHandler : Raycaster
{
    public enum  ScanCode {Scanning, Clear, Warning, Danger}; 

    public static Action<int> OnScanPlate;
    public static Action<int> OnScanPlateResult;
    public static Action<int> OnScanDriverLicense;
    public static Action<int> OnScanDriverLicenseResult;
    //public delegate void OnAlertDelegate();
    //public static event OnAlertDelegate TriggerScanPlate;
    //public static event OnAlertDelegate TriggerResultOfPlateScan;
    //public static event OnAlertDelegate TriggerLicenseScan;
    //public static event OnAlertDelegate TriggerResultOfLicenseScan;

    private IEnumerator coroutine;

    bool plateAlreadyTriggered = false;
    bool driverLicenseAlreadyTriggered = false;

    protected override void OnRaycasterEnter(GameObject target)
    {
        if (target.gameObject.name == "PlateTrigger" && !plateAlreadyTriggered)
        {
            OnScanPlate((int)ScanCode.Scanning);
            //TriggerScanPlate();
            plateAlreadyTriggered = true;
            coroutine = Wait(4f);
            StartCoroutine(coroutine);
        }

        if (target.gameObject.name == "DriverTrigger" && !driverLicenseAlreadyTriggered)
        {
            //TriggerLicenseScan();
            OnScanDriverLicense((int)ScanCode.Scanning);
            coroutine = Wait2(4f);
            StartCoroutine(coroutine);
            driverLicenseAlreadyTriggered = true;
        }

    }


    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OnScanPlateResult((int)ScanCode.Clear);
        //TriggerResultOfPlateScan();

    }

    private IEnumerator Wait2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OnScanDriverLicenseResult((int)ScanCode.Warning);
        //TriggerResultOfLicenseScan();

    }


}
