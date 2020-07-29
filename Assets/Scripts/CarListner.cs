using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarListner : MonoBehaviour
{
    int openWindow = Animator.StringToHash("Open");
    int closeWindow = Animator.StringToHash("Close");

    Animator windowAnimator;

    // Start is called before the first frame update
    void Start()
    {
        windowAnimator = GetComponent<Animator>();
        if (windowAnimator == null)
            Debug.LogError("Couldn't load 'Animator'");
        Commands.OnOfficerApproach += OpenCarWindow;
        Commands.OnReturnToIdle += CloseCarWindow;
       
    }

    void OpenCarWindow()
    {
        windowAnimator.SetBool(closeWindow, false);
        windowAnimator.SetBool(openWindow, true);
    }

    void CloseCarWindow()
    {
        windowAnimator.SetBool(closeWindow, true);
        windowAnimator.SetBool(openWindow, false);
    }

    private void OnDisable()
    {
        Commands.OnOfficerApproach -= OpenCarWindow;
        Commands.OnReturnToIdle -= CloseCarWindow;
    }
}
