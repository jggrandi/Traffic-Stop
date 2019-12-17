using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorPlateScan : MonoBehaviour
{
    public GameObject vbutton;
    public GameObject obutton;

    // Start is called before the first frame update
    void Start()
    {
        vbutton.GetComponent<Button>().interactable = false;
        vbutton.GetComponentInChildren<BoxCollider>().enabled = false;
        obutton.GetComponent<Button>().interactable = false;
        obutton.GetComponentInChildren<BoxCollider>().enabled = false;
        //AlertsHandler.TriggerResultOfPlateScan += EnableButton;
        AlertsHandler.OnScanPlateResult += EnableButton;
    }
    
    void EnableButton( int _scanCode)
    {
        vbutton.GetComponent<Button>().interactable = true;
        vbutton.GetComponentInChildren<BoxCollider>().enabled = true;
        obutton.GetComponent<Button>().interactable = true;
        obutton.GetComponentInChildren<BoxCollider>().enabled = true;

    }

    private void OnDisable()
    {
        AlertsHandler.OnScanPlateResult -= EnableButton;
    }
}
