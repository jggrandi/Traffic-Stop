using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardInstantiate : MonoBehaviour
{
    public GameObject hazardMarker;
    public Sprite[] images;
    private GameObject hazardInstantizated;
    // Start is called before the first frame update
    public void initiate(Transform _obj)
    {
        hazardInstantizated = Instantiate(hazardMarker, _obj);
        hazardInstantizated.GetComponent<HazardMarker>().active();
    }

    public void deployed()
    {
        hazardInstantizated.transform.parent = this.transform;
    }
}
