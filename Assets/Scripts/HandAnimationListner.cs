using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationListner : MonoBehaviour
{
    Animator handAnimator;

    int getLicenseBack = Animator.StringToHash("Reverse");
    int putLicenseBack = Animator.StringToHash("PlaceLice");


    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
        if (handAnimator == null)
            Debug.LogError("Couldn't load 'Animator'");

        Commands.OnPutBackLicense += PlayAnimationPutBack;
        Commands.OnReturnToIdle += PlayAnimationIdle;
    }

    void PlayAnimationPutBack()
    {
        handAnimator.SetBool(getLicenseBack, false);
        handAnimator.SetBool(putLicenseBack, true);
    }
    void PlayAnimationIdle()
    {
        handAnimator.SetBool(getLicenseBack, false);
        handAnimator.SetBool(putLicenseBack, false);
    }

    private void OnDisable()
    {
        Commands.OnPutBackLicense -= PlayAnimationPutBack;
        Commands.OnReturnToIdle -= PlayAnimationIdle;
    }

}
