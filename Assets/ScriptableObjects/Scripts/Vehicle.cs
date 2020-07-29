using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Vehicle", menuName ="Traffic-Stop/Vehicle")]
public class Vehicle : ScriptableObject
{
    public VehicleInfo basicInformation;
    public VehicleRegistration registration;
    public RecordsList records;
    public Person owner;

    public AlertObject.AlertLevel alertLevel;
}
