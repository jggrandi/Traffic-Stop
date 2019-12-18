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
    bool firstPressVehicle = true;
    bool firstPressOwner = true;
    bool firstPressDriver = true;

    //-------------------------------------------------
    public void ToggleVehicleInfo(Hand hand)
    {
        if(firstPressVehicle)
        {
            TurnWhite(vehicleButton);
            firstPressVehicle = false;
        }
        vehicleInfo.SetActive(!vehicleInfo.activeInHierarchy);
        ownerInfo.SetActive(false);
        driverInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

    public void ToggleOwnerInfo(Hand hand)
    {
        if (firstPressOwner)
        {
            TurnWhite(ownerButton);
            firstPressOwner = false;
        }
        ownerInfo.SetActive(!ownerInfo.activeInHierarchy);
        vehicleInfo.SetActive(false);
        driverInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

    public void ToggleDriverInfo(Hand hand)
    {
        if (firstPressDriver)
        {
            TurnWhite(driverButton);
            firstPressDriver = false;
        }
        driverInfo.SetActive(!driverInfo.activeInHierarchy);
        vehicleInfo.SetActive(false);
        ownerInfo.SetActive(false);
        //canvas.SetActive(!canvas.activeInHierarchy);
    }

    void TurnWhite(GameObject obj)
    {
        Button b = obj.GetComponent<Button>();
        ColorBlock colors = b.colors;
        colors.normalColor = new Color32(225, 225, 225, 0);
        b.colors = colors;
    }

}