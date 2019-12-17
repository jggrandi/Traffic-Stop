using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorDriverScan : MonoBehaviour
{
    public GameObject driverbutton;
    // Start is called before the first frame update
    void Start()
    {
        driverbutton.GetComponent<Button>().interactable = false;
        driverbutton.GetComponentInChildren<BoxCollider>().enabled = false;
        AlertsHandler.OnScanDriverLicense += EnableButton;
    }
    
    void EnableButton( int _scanCode)
    {
        driverbutton.GetComponent<Button>().interactable = true;
        driverbutton.GetComponentInChildren<BoxCollider>().enabled = true;
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicense -= EnableButton;
    }
}
