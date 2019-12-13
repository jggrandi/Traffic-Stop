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
    public GameObject ownerButton;
    public GameObject driverButton;

    //-------------------------------------------------
    public void ToggleVehicleInfo(Hand hand)
    {
        vehicleInfo.SetActive(!vehicleInfo.activeInHierarchy);
        ownerInfo.SetActive(false);
        driverInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

    public void ToggleOwnerInfo(Hand hand)
    {
        ownerInfo.SetActive(!ownerInfo.activeInHierarchy);
        vehicleInfo.SetActive(false);
        driverInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

    public void ToggleDriverInfo(Hand hand)
    {
        driverInfo.SetActive(!driverInfo.activeInHierarchy);
        vehicleInfo.SetActive(false);
        ownerInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

}