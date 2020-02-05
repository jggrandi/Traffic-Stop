using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBehaviorDriverScan : MonoBehaviour
{
    GameObject driverbutton;
    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanDriverLicense += EnableButton;
    }
    
    void EnableButton( int _scanCode)
    {
        Button b1 = driverbutton.GetComponent<Button>();
        TurnRed(b1);
        b1.interactable = true;
        driverbutton.GetComponentInChildren<BoxCollider>().enabled = true;
    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicense -= EnableButton;
    }

    public void TurnRed(Button b)
    {
        ColorBlock colors = b.colors;
        colors.normalColor = Color.red;
        b.colors = colors;
    }
}
