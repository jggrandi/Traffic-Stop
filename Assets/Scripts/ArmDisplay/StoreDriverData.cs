using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDriverData : StoreData<Person>
{
    private void Start()
    {
        InitialSetup();
        alertObjectRef.LevelAlert = data.alertLevel;
    }
}
