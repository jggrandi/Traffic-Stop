//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates the use of the controller hint system
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

//-------------------------------------------------------------------------
public class UIHandler : MonoBehaviour
{
    //public GameObject canvas;
    public GameObject vehicleInfo;
    public GameObject ownerInfo;
    public GameObject driverInfo;

    public GameObject vehicleButton;
    public Button ownerButton;
    public Button driverButton;
    //bool firstPressVehicle = true;
    //bool firstPressOwner = true;
    //bool firstPressDriver = true;

    //-------------------------------------------------
    private void Start()
    {
        HandleInteractableArea.OnExitInteractableArea += ToggleAllOff;
        ToggleAllOff();
    }

    private void OnDisable()
    {
        HandleInteractableArea.OnExitInteractableArea -= ToggleAllOff;
    }

    //private bool ColorMatch(Button _b, int _colorCode)
    //{
    //    if (AlertsHandler.GetButtonColor(_b) == AlertsHandler.DefineColorBasedOnAlertCode(_colorCode))
    //        return true;
    //    return false;
    //}

    public void ToggleVehicleInfo()
    {
        //if(!ColorMatch(vehicleButton, (int)AlertsHandler.ScanCode.Null))        
        //    AlertsHandler.ChangeButtonColor((int) AlertsHandler.ScanCode.Null, vehicleButton);
        vehicleInfo.SetActive(!vehicleInfo.activeInHierarchy);
        driverInfo.SetActive(false);
        ownerInfo.SetActive(false);
    }

    public void ToggleOwnerInfo()
    {
        //if (!ColorMatch(ownerButton, (int)AlertsHandler.ScanCode.Null))
        //    AlertsHandler.ChangeButtonColor((int)AlertsHandler.ScanCode.Null, ownerButton);

        ownerInfo.SetActive(!ownerInfo.activeInHierarchy);
        driverInfo.SetActive(false);
        vehicleInfo.SetActive(false);
    }

    public void ToggleDriverInfoWithVerification()
    {
        //if (!ColorMatch(driverButton, (int)AlertsHandler.ScanCode.Null))
        //    AlertsHandler.ChangeButtonColor((int)AlertsHandler.ScanCode.Null, driverButton);

        ToggleDriverInfo();
    }

    public void ToggleDriverInfo()
    {
        driverInfo.SetActive(!driverInfo.activeInHierarchy);
        vehicleInfo.SetActive(false);
        ownerInfo.SetActive(false);
    }

    void ToggleAllOff()
    {
        driverInfo.SetActive(false);
        vehicleInfo.SetActive(false);
        ownerInfo.SetActive(false);
    }


}