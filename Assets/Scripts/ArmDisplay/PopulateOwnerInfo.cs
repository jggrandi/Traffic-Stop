using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateOwnerInfo : PopulatePersonInfo
{

    // Start is called before the first frame update
    void Start()
    {
        PlateScanListener.OnReady += PopulateUI;
    }

    private void PopulateUI(GameObject _obj)
    {
        person = _obj.GetComponent<StoreVehicleData>().data.owner;
        PopulateInfo();
    }

}
