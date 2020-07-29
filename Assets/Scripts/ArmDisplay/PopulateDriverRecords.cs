using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PopulateDriverRecords : PopulateRecords
{

    private void Start()
    {
        LicenseScanListener.OnReady += PopulateUI; 
    }

    private void PopulateUI(GameObject _obj)
    {
        records = _obj.GetComponent<StoreDriverData>().data.records;
        PopulateInfo();
    }
}
