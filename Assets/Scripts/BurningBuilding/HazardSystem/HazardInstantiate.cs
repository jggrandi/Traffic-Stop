using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardInstantiate : MonoBehaviour
{
    public GameObject hazardMarker;
    private GameObject hazardInstantizated;
    // Start is called before the first frame update
    public void initiate(Transform _obj)
    {
        hazardInstantizated = Instantiate(hazardMarker, _obj);
    }
    
    public void set(Sprite image)
    {
        hazardMarker.GetComponent<HazardMarker>().setHazardImage(image);
    }
    public void deployed()
    {
        hazardInstantizated.transform.parent = this.transform;
    }

}
