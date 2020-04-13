using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDriverInfo : PopulatePersonInfo
{

    // Start is called before the first frame update
    void Start()
    {
        LicenseScanListener.OnReady += PopulateUI;
    }

    private void PopulateUI(GameObject _obj)
    {
        person = _obj.GetComponent<StoreDriverData>().data;
        if (person == null)
        {
            Debug.LogWarning("Person data attached to the game object");
            return;
        }
        PopulateInfo();
    }

}
