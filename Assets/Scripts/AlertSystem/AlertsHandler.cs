using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AlertsHandler : Raycaster
{
    public enum ScanCode { Scanning, Clear, Warning, Danger, Null };
    public enum ObjType { Plate, DriverLicense, LegalObj, IllegalObj };


    public static Action<int> OnScanPlate;
    public static Action<int> OnScanPlateResult;
    public static Action<int> OnScanDriverLicense;
    public static Action<int> OnScanDriverLicenseResult;

    public enum Type { plate, license, obj };
    public static Action<GameObject> OnScan;
    public static Action<GameObject> OnScanResult;
    SceneConfigurator sconfig;

    private IEnumerator coroutine;

    //bool isPlateTriggered = false;
    //bool isDriverLicenseTriggered = false;

    private void Start()
    {
        sconfig = SceneConfigurator.Instance;
        HandleInteractableArea.OnExitInteractableArea += ResetTriggers;
        ResetTriggers();
    }

    private void OnDisable()
    {
        HandleInteractableArea.OnExitInteractableArea -= ResetTriggers;
    }

    void ResetTriggers()
    {
        //isPlateTriggered = false;
        //isDriverLicenseTriggered = false;
        sconfig.CurrentObject = null;
    }

    protected override void OnRaycasterEnter(GameObject target)
    {


        if (!sconfig.IsObjectInList(target.gameObject)) return; // If the object gazed is not AlertObject type
        if (!target.gameObject.GetComponent<AlertObject>().IsInteractable) return; //if the object gazed is not interactable yet
        if (sconfig.CurrentObject == target.gameObject) return; 

        sconfig.CurrentObject = target.gameObject;
        
        OnScan(sconfig.CurrentObject);
        //coroutine = Wait2(4f);
        coroutine = Wait3(4f, sconfig.CurrentObject);
        StartCoroutine(coroutine);


    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.P))
    //        OnScanResult(sconfig.CurrentObject);
    //}
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
            case (int)ScanCode.Null:
                returnColor = new Color32(225, 225, 225, 0);
                break;
            default:
                returnColor = Color.white;
                break;
        }
        return returnColor;
    }

    //public static void ChangeButtonColor(int _scanCode, Button _b)
    //{
    //    ColorBlock colors = _b.colors;
    //    colors.normalColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
    //    _b.colors = colors;
    //}

    //public static Color GetButtonColor(Button _b)
    //{
    //    ColorBlock colors = _b.colors;
    //    return colors.normalColor;
    //}

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
    private IEnumerator Wait3(float waitTime, GameObject _obj )
    {
        yield return new WaitForSeconds(waitTime);
        OnScanResult(_obj);
        //TriggerResultOfLicenseScan();

    }


}
