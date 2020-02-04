using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommands : Commands
{
    // Start is called before the first frame update
    void Start()
    {
        SetupCommands();
    }

    // Update is called once per frame
    void Update()
    {
        KeyTrigAnimation();
    }

    void KeyTrigAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindDriversLicense();
            //DriverLicensePass();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SayIDontKnow();
            //LipSyncAction(LipAnim[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WhenOfficerGetDriversLicense();
            //RestoreHandToNormalPose();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GoGetLicenseBack();
            //ReturnDriverLicense();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ReturnLicenseToOriginalPlace();
            //PutBackLicense();
        }

    }

}
