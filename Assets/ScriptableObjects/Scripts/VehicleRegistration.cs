using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Vehicle Registration", menuName ="Traffic-Stop/VehicleRegistration")]
public class VehicleRegistration : ScriptableObject
{
    public string plateNumber;
    public string issueDate;
    public string expirationDate;
    public string vin;
    public AlertElement inspectionStatus;
}
