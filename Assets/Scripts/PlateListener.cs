using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.triggerScanPlate += ShowARPlate;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ShowARPlate()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject g = gameObject.transform.GetChild(i).gameObject;
            g.SetActive(true);
        }
    }
}
