using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hazard Information", menuName = "Burning-Building/HazardInfo")]
public class HazardInfo : ScriptableObject
{
    public string hazardName;
    public string briefDescription;

    public Sprite picture;

}
