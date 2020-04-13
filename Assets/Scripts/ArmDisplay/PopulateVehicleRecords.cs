using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateVehicleRecords : PopulateRecords
{
    private void Start()
    {
        PlateScanListener.OnReady += PopulateUI;
    }

    private void PopulateUI(GameObject _obj)
    {
        records = _obj.GetComponent<StoreVehicleData>().data.records;
        PopulateInfo();
    }
}
