using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScanListener : AlertListener
{
    public static Action<GameObject> OnReady;

    // Start is called before the first frame update
    void Start()
    {
        InitalSetup();
        alertObj = GetComponent<AlertObject>();       
    }

    protected override void ShowResult(GameObject _candidate)
    {
        base.ShowResult(_candidate);
        if (_candidate != this.gameObject) return;
        OnReady(_candidate);
    }

    protected override void ShowScanning(GameObject _candidate)
    {
        base.ShowScanning(_candidate);
        //OnProcessing(_candidate);
    }
}
