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
        HandleInteractableArea.OnEnterInteractableArea += OfficerApproach;
        HandleInteractableArea.OnExitInteractableArea += ResetToIdle;
        GrabDriversLicense.OnHoldLicense += HandDriversLicense;
        GrabDriversLicense.OnReturnLicense += GetLicenseBack;
        GrabDriversLicense.OnPutLicenseBack += ReturnLicenseToOriginalPlace;

        driverAnimations = GetComponent<HandleDriverAnimations>();
        if (driverAnimations == null)
            Debug.LogError("Couldn't load 'HandleDriverAnimations'");

        driverAnswers = GetComponent<DriverVoiceAnswers>();
        if (driverAnswers == null)
            Debug.LogError("Couldn't load 'AvatarVoiceAnswers'");
    }

    protected virtual void FindDriversLicense()
    {
        driverAnswers.PlayLetMeFind();
        driverAnimations.DriverLicensePass();
    }

    protected virtual void SayIDontKnow()
    {
        driverAnswers.PlayIDontKnow();
    }

    protected virtual void SayHello()
    {
        driverAnswers.PlayHiOfficer();
    }

    protected virtual void HandDriversLicense()
    {
        driverAnswers.PlayOk();
        driverAnimations.RestoreHandToNormalPose();
        OnReturnToIdle();
    }

    protected virtual void GetLicenseBack()
    {
        driverAnimations.GetLicenseBack();
    }

    protected virtual void ReturnLicenseToOriginalPlace()
    {
        driverAnimations.PutBackLicense();
        OnPutBackLicense();
    }

    public void OfficerApproach()
    {
        driverAnimations.OfficerApproach();
        OnOfficerApproach();
    }

    public void ResetToIdle()
    {
        driverAnimations.ReturnToIdle();
        OnReturnToIdle();
    }


    private void OnDisable()
    {
        HandleInteractableArea.OnEnterInteractableArea -= OfficerApproach;
        HandleInteractableArea.OnExitInteractableArea -= ResetToIdle;
    }

}
