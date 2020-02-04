using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlertsHandler : Raycaster
{
    public enum  ScanCode {Scanning, Clear, Warning, Danger};
    public enum ObjType { Plate, DriverLicense, LegalObj, IllegalObj};


    public static Action<int> OnScanPlate;
    public static Action<int> OnScanPlateResult;
    public static Action<int> OnScanDriverLicense;
    public static Action<int> OnScanDriverLicenseResult;


    private IEnumerator coroutine;

    bool isPlateTriggered = false;
    bool isDriverLicenseTriggered = false;

    
    protected override void OnRaycasterEnter(GameObject target)
    {
        Debug.Log(target);
        SelectionIndicator.selectedObject = target.transform.parent.gameObject;
        if (target.gameObject.name == "PlateTrigger" && !isPlateTriggered)
        {
            OnScanPlate((int)ScanCode.Scanning);
            //TriggerScanPlate();
            coroutine = Wait(4f, ScanCode.Clear);
            StartCoroutine(coroutine);
            isPlateTriggered = true;
        }

        if (target.gameObject.name == "DriverLicense" && !isDriverLicenseTriggered)
        {
            //TriggerLicenseScan();
            OnScanDriverLicense((int)ScanCode.Scanning);
            //OnScanObject((int)ObjType.DriverLicense,(int)ScanCode.Scanning);
            //coroutine = Wait2(4f);
            coroutine = Wait2(4f, ScanCode.Warning);
            StartCoroutine(coroutine);
            isDriverLicenseTriggered = true;
        }
    }

    public static Color DefineColorBasedOnAlertCode(int _scanCode)
    {
        Color returnColor;
        switch (_scanCode)
        {
            case (int)ScanCode.Scanning:
                returnColor = Color.yellow;
                break;
            case (int)ScanCode.Clear:
                returnColor = Color.green;
                break;
            case (int)ScanCode.Warning:
                returnColor = Color.red;
                break;
            default:
                returnColor = Color.white;
                break;
        }
        return returnColor;
    }


    private IEnumerator Wait(float waitTime, ScanCode scanCode)
    {
        yield return new WaitForSeconds(waitTime);
        //OnScanObjectResult((int)objType,(int)scanCode);
        OnScanPlateResult((int)scanCode);
        //TriggerResultOfPlateScan();

    }

    private IEnumerator Wait2(float waitTime, ScanCode scanCode)
    {
        yield return new WaitForSeconds(waitTime);
        OnScanDriverLicenseResult((int)scanCode);
        //TriggerResultOfLicenseScan();

    }


}
