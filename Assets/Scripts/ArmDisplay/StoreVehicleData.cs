using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreVehicleData : StoreData<Vehicle>
{
    private void Start()
    {
        InitialSetup();
        alertObjectRef.LevelAlert = data.alertLevel; 
    }

}
