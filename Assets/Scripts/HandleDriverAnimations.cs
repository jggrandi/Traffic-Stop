using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandleDriverAnimations : MonoBehaviour
{


    Animator driverAnimator;
    int headRot = Animator.StringToHash("HeadRot");
    int grabLicense = Animator.StringToHash("GrabLicense");
    int getLicense = Animator.StringToHash("GetLicense");
    int licensePass = Animator.StringToHash("LicensePass");
    int licensePassReset = Animator.StringToHash("LicensePassReset");
    int leaveInteractionArea = Animator.StringToHash("Leave");

    void Start()
    {
        driverAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetLicenseBack()
    {
        //onDriverlicenseReturn(); // NECESSARY TO other scripts to be aware that the driver license was returned to the driver
        //Selector3D.SetActive(false); //Old stuff that deactivated the UI on the vehicle's plate
        driverAnimator.SetBool(headRot, false);
        driverAnimator.SetBool(licensePass, false);
        driverAnimator.SetBool(licensePassReset, false);
        driverAnimator.SetBool(leaveInteractionArea, false);
        driverAnimator.SetBool(getLicense, true);
        driverAnimator.SetBool(grabLicense, false);
    }

    public void PutBackLicense()
    {
        //driverLicense.SetActive(true);
        driverAnimator.SetBool(headRot, false);
        driverAnimator.SetBool(licensePass, false);
        driverAnimator.SetBool(licensePassReset, false);
        driverAnimator.SetBool(leaveInteractionArea, false);
        driverAnimator.SetBool(getLicense, false);
        driverAnimator.SetBool(grabLicense, true);
        //animators[2].SetBool(getLicenseBack, false);
        //animators[2].SetBool(putLicenseBack, true);
        //OnPutBackLicense();
    }


    public void RestoreHandToNormalPose()
    {
        //LipSyncAction(LipAnim[3]);
        driverAnimator.SetBool(headRot, false);
        driverAnimator.SetBool(licensePass, false);
        driverAnimator.SetBool(licensePassReset, true);
        driverAnimator.SetBool(leaveInteractionArea, false);
        //animators[2].SetBool(getLicenseBack, false);
        //animators[2].SetBool(putLicenseBack, false);
        //OnReturnToIdle();
        //driverLicense.SetActive(false);
        //Selector3D.SetActive(false);
    }


    public void DriverLicensePass()
    {
        //Selector3D.SetActive(true);
        //LipSyncAction(LipAnim[2]);
        driverAnimator.SetBool(headRot, false);
        driverAnimator.SetBool(licensePass, true);
        driverAnimator.SetBool(leaveInteractionArea, false);
        driverAnimator.SetBool(licensePassReset, false);
        driverAnimator.SetBool(grabLicense, false);
        driverAnimator.SetBool(getLicense, false);
        //coroutine = WaitToShowDriverLicense(5.7f);
        //StartCoroutine(coroutine);
    }

    public void OfficerApproach()
    {
       // ready = true;
        driverAnimator.SetBool(headRot, true);
        driverAnimator.SetBool(licensePassReset, false);
        //animators[1].SetBool(openWindow, true);
        //animators[1].SetBool(closeWindow, false);
        driverAnimator.SetBool(leaveInteractionArea, false);
        //OnOfficerApproach();

}


    public void ReturnToIdle()
    {
       // ready = false;
        driverAnimator.SetBool(headRot, false);
        driverAnimator.SetBool(licensePassReset, false);
        driverAnimator.SetBool(leaveInteractionArea, true);
        driverAnimator.SetBool(licensePass, false);
        //animators[1].SetBool(closeWindow, true);
        //animators[1].SetBool(openWindow, false);
        //OnReturnToIdle();
    }



}
