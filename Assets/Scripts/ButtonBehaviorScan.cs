using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorScan : MonoBehaviour
{
    public Button vbutton;
    public Button obutton;
    public Button dbutton;

    UIHandler uiReference; //temporary to show the drivers info when the alert is triggered

    // Start is called before the first frame update
    private void Start()
    {
        PlateScanListener.OnReady += EnableVehicleButton;

        //AlertsHandler.OnScanPlateResult += EnableVehicleButton;
        //AlertsHandler.OnScanPlateResult += EnableOwnerButton;
        //AlertsHandler.OnScanDriverLicenseResult += EnableDriverButton;
        HandleInteractableArea.OnExitInteractableArea += ResetButtons;
        uiReference = GetComponent<UIHandler>();
    }

    private void EnableVehicleButton(GameObject obj)
    {
        EnableButton(obj, vbutton);
    }

    private void ResetButtons()
    {
        DisableButton(vbutton);
        DisableButton(obutton);
        DisableButton(dbutton);
    }

    private void OnDisable()
    {
        PlateScanListener.OnReady -= EnableVehicleButton;
        //AlertsHandler.OnScanPlateResult -= EnableVehicleButton;
        //AlertsHandler.OnScanPlateResult -= EnableOwnerButton;
        //AlertsHandler.OnScanDriverLicenseResult -= EnableDriverButton;
        HandleInteractableArea.OnExitInteractableArea -= ResetButtons;
    }

    //protected void EnableVehicleButton(int _scanCode)
    //{
    //    EnableButton(_scanCode, vbutton);
    //}

    //protected void EnableOwnerButton(int _scanCode)
    //{
    //    EnableButton(_scanCode, obutton);
    //}

    //protected void EnableDriverButton(int _scanCode)
    //{
    //    EnableButton(_scanCode, dbutton);
    //    uiReference.ToggleDriverInfo();
    //}

    private void EnableButton(GameObject _obj, Button _b)
    {
        Utils.ChangeButtonColor(Utils.DefineColorBasedOnAlertCode(_obj.GetComponent<AlertObject>().LevelAlert),_b);
        //AlertsHandler.ChangeButtonColor(_scanCode, _b);
        _b.interactable = true;
        _b.GetComponentInChildren<BoxCollider>().enabled = true;
    }


    //private void EnableButton(int _scanCode, Button _b)
    //{
    //    AlertsHandler.ChangeButtonColor(_scanCode, _b);
    //    _b.interactable = true;
    //    _b.GetComponentInChildren<BoxCollider>().enabled = true;
    //}

    private void DisableButton(Button _b)
    {
        Utils.ChangeButtonColor(new Color32(225, 225, 225, 0), _b);
        //AlertsHandler.ChangeButtonColor((int)AlertsHandler.ScanCode.Null, _b);
        _b.interactable = false;
        _b.GetComponentInChildren<BoxCollider>().enabled = false;
    }

}
