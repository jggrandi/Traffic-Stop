using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UICommands : Commands
{

    // Start is called before the first frame update
    void Start()
    {
        SetupCommands();

        //HandleInteractableArea.OnEnterInteractableArea += AllowVoiceCommands;
        //HandleInteractableArea.OnExitInteractableArea += DenyVoiceCommands;
    }
    private void OnDisable()
    {
        //HandleInteractableArea.OnEnterInteractableArea -= AllowVoiceCommands;
        //HandleInteractableArea.OnExitInteractableArea -= DenyVoiceCommands;

    }


    //void AllowVoiceCommands()
    //{
    //    isAllowVoiceCommands = true;
    //}

    //void DenyVoiceCommands()
    //{
    //    isAllowVoiceCommands = false;
    //}


    public void Greeting()
    {
        SayHello();
    }

    public void AskReasonToStop()
    {
        SayIDontKnow();
    }

    public void AskLicense()
    {
        FindDriversLicense();
    }

    public void Thank()
    {
        SayOk();
        WhenOfficerGetDriversLicense();
    }


}
