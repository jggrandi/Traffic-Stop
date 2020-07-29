using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Enables the driver button on the arm displayu UI after the driver's license is scaned.

public class DriverButton : ButtonBehavior
{

    private void Start()
    {
        LicenseScanListener.OnReady += Enable;
        HandleInteractableArea.OnExitInteractableArea += Disable;
        b = this.GetComponent<Button>();
        Disable();
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

