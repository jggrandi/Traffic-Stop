using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorDriverScan : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().interactable = false;
        this.GetComponentInChildren<BoxCollider>().enabled = false;
        AlertsHandler.TriggerResultOfLicenseScan += EnableButton;
    }
    
    void EnableButton()
    {
        this.GetComponent<Button>().interactable = true;
        this.GetComponentInChildren<BoxCollider>().enabled = true;

    }
}
