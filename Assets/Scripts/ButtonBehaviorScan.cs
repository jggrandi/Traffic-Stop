using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorScan : MonoBehaviour
{
    public Button vbutton;
    public Button obutton;
    public Button dbutton;

    UIHandler uiReference; //temporary to show the drivers info when the alert is triggered

    // Start is called before the first frame update
    private void Start()
    {
        AlertsHandler.OnScanPlateResult += EnableVehicleButton;
        AlertsHandler.OnScanPlateResult += EnableOwnerButton;
        AlertsHandler.OnScanDriverLicenseResult += EnableDriverButton;
        uiReference = GetComponent<UIHandler>();
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanPlateResult -= EnableVehicleButton;
        AlertsHandler.OnScanPlateResult -= EnableOwnerButton;
        AlertsHandler.OnScanDriverLicenseResult -= EnableDriverButton;
    }

    protected void EnableVehicleButton(int _scanCode)
    {

        ChangeButtonColor(_scanCode, vbutton);
        vbutton.interactable = true;
        vbutton.GetComponentInChildren<BoxCollider>().enabled = true;

    }

    protected void EnableOwnerButton(int _scanCode)
    {

        ChangeButtonColor(_scanCode,obutton);
        obutton.interactable = true;
        obutton.GetComponentInChildren<BoxCollider>().enabled = true;

    }

    protected void EnableDriverButton(int _scanCode)
    {

        ChangeButtonColor(_scanCode, dbutton);
        dbutton.interactable = true;
        dbutton.GetComponentInChildren<BoxCollider>().enabled = true;
        uiReference.ToggleDriverInfoTESTING();

    }


    protected void ChangeButtonColor(int _scanCode, Button _b)
    {
        ColorBlock colors = _b.colors;
        colors.normalColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        _b.colors = colors;
    }

}
