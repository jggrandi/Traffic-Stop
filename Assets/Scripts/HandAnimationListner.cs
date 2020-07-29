using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationListner : MonoBehaviour
{
    Animator handAnimator;

    int handSteeringWheelToWindow = Animator.StringToHash("Reverse");
    int licenseWindowToDash = Animator.StringToHash("PlaceLice");
    int licenseDashToWindow = Animator.StringToHash("Play");
    int handWindowToSteeringWheel = Animator.StringToHash("Reset");


    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
        if (handAnimator == null)
            Debug.LogError("Couldn't load 'Animator'");

        Commands.OnPutBackLicense += PlayAnimationPutBack;
        Commands.OnReturnToIdle += PlayAnimationIdle;
        Driver_IK.OnSetGetLicense += PlayAnimationDashToWindow;
        Driver_IK.OnReturnLicense += PlayAnimationSteeringWheelToWindow;
        Driver_IK.OnResetGetLicense += PlayAnimationHandBackToSteeringWheel;
    }
    private void OnDisable()
    {
        Commands.OnPutBackLicense -= PlayAnimationPutBack;
        Commands.OnReturnToIdle -= PlayAnimationIdle;
        Driver_IK.OnSetGetLicense -= PlayAnimationDashToWindow;
        Driver_IK.OnReturnLicense -= PlayAnimationSteeringWheelToWindow;
        Driver_IK.OnResetGetLicense -= PlayAnimationHandBackToSteeringWheel;
    }
    void PlayAnimationPutBack()
    {
        handAnimator.SetBool(handSteeringWheelToWindow, false);
        handAnimator.SetBool(licenseWindowToDash, true); // window to dash
    }
    void PlayAnimationIdle()
    {
        handAnimator.SetBool(handSteeringWheelToWindow, false);
        handAnimator.SetBool(licenseWindowToDash, false);
    }

    void PlayAnimationDashToWindow()
    {
        handAnimator.SetBool(licenseDashToWindow, true); // license animation from dash to window
        handAnimator.SetBool(handWindowToSteeringWheel, false); // go to steering wheel
    }

    void PlayAnimationSteeringWheelToWindow()
    {
        handAnimator.SetBool(handSteeringWheelToWindow, true); // license animation from steering wheel to window
        handAnimator.SetBool(handWindowToSteeringWheel, false); //
        handAnimator.SetBool(licenseWindowToDash, false); // window to dash
    }

    void PlayAnimationHandBackToSteeringWheel()
    {
        handAnimator.SetBool(licenseDashToWindow, false);
        handAnimator.SetBool(handWindowToSteeringWheel, true);
    }



}
