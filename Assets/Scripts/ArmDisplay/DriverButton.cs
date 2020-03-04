﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriverButton : ButtonBehavior
{

    private void Start()
    {
        LicenseScanListener.OnReady += Enable;
        HandleInteractableArea.OnExitInteractableArea += Disable;
        b = this.GetComponent<Button>();
    }
    private void OnDisable()
    {
        PlateScanListener.OnReady -= Enable;
        HandleInteractableArea.OnExitInteractableArea -= Disable;
    }

    protected override void Enable(GameObject _obj)
    {
        base.Enable(_obj);
    }

    protected override void Disable()
    {
        base.Disable();
    }
}

