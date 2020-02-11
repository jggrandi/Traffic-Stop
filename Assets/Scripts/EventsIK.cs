using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsIK : MonoBehaviour
{
    // THESE FUNCTIONS ARE BEING CALLED AS EVENTS IN THE HUMAN1.fbx 

    protected bool rightHandLock = true, getLicense = false, headIK = false;
    protected float weight = 1f, headWeight = 1f;
    public static bool allowLicenseReturn = false;

    public static Action OnSetGetLicense;
    public static Action OnReturnLicense;
    public static Action OnResetGetLicense;

    void SetrightHandLock()
    {
        rightHandLock = true;
        getLicense = false;
    }

    void SetHeadIK()
    {
        headIK = true;
    }

    void ResetHeadIK()
    {
        headIK = false;
    }

    void ResetrightHandLock()
    {
        rightHandLock = false;
    }

    void SetGetLicense()
    {
        allowLicenseReturn = false;
        ActLicense();
        weight = 1f;
        OnSetGetLicense();
    }

    void ActLicense()
    {
        getLicense = true;
    }

    void ReturnLicense()
    {
        ResetrightHandLock();
        ActLicense();
        weight = 1f;
        OnReturnLicense();
    }

    void InactLicense()
    {
        getLicense = false;
    }

    void ResetGetLicense()
    {
        InactLicense();
        OnResetGetLicense();
    }

    void AllowDriversLicenseRerturn()
    {
        allowLicenseReturn = true;
    }
}
