using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Vehicle Information", menuName ="Traffic-Stop/VehicleInfo")]
public class VehicleInfo : ScriptableObject
{
    public string make;
    public string model;
    public int year;
    
    public Sprite vehiclePicture;

}
