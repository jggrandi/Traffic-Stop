using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Commands : MonoBehaviour
{

    public static Action OnPutBackLicense;
    public static Action OnReturnToIdle;
    public static Action OnOfficerApproach;
    public static Action OnReturnToIdlePosition;

    HandleDriverAnimations driverAnimations;
    DriverVoiceAnswers driverAnswers;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void SetupCommands()
    {
        HandleInteractableArea.OnEnterInteractableArea += WhenOfficerApproach;
        HandleInteractableArea.OnExitInteractableArea += ResetToIdle;
        GrabDriversLicense.OnHoldLicense += WhenOfficerGetDriversLicense;
        GrabDriversLicense.OnReturnLicense += GoGetLicenseBack;
        GrabDriversLicense.OnPutLicenseBack += ReturnLicenseToOriginalPlace;

        driverAnimations = GetComponent<HandleDriverAnimations>();
        if (driverAnimations == null)
            Debug.LogError("Couldn't load 'HandleDriverAnimations'");

        driverAnswers = GetComponent<DriverVoiceAnswers>();
        if (driverAnswers == null)
            Debug.LogError("Couldn't load 'AvatarVoiceAnswers'");
    }

    private void OnDisable()
    {
        HandleInteractableArea.OnEnterInteractableArea -= WhenOfficerApproach;
        HandleInteractableArea.OnExitInteractableArea -= ResetToIdle;
        GrabDriversLicense.OnHoldLicense -= WhenOfficerGetDriversLicense;
        GrabDriversLicense.OnReturnLicense -= GoGetLicenseBack;
        GrabDriversLicense.OnPutLicenseBack -= ReturnLicenseToOriginalPlace;
    }

    protected virtual void FindDriversLicense()
    {
        driverAnswers.PlayLetMeFind();
        driverAnimations.PassDriversLicense();
    }

    protected virtual void SayIDontKnow()
    {
        driverAnswers.PlayIDontKnow();
    }

    protected virtual void SayHello()
    {
        driverAnswers.PlayHiOfficer();
    }

    protected virtual void WhenOfficerGetDriversLicense()
    {
        driverAnswers.PlayOk();
        driverAnimations.RestoreHandToNormalPose();
    }

    protected virtual void GoGetLicenseBack()
    {
        driverAnimations.GetLicenseBack();
    }

    protected virtual void ReturnLicenseToOriginalPlace()
    {
        driverAnimations.PutBackLicense();
        OnPutBackLicense();
    }

    public void WhenOfficerApproach()
    {
        driverAnimations.OfficerApproach();
        OnOfficerApproach();
    }

    public void ResetToIdle()
    {
        driverAnimations.ReturnToIdle();
        OnReturnToIdle();
    }




}
