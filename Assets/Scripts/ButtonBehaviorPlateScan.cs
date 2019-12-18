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
        //AlertsHandler.TriggerResultOfPlateScan += EnableButton;
        AlertsHandler.OnScanPlateResult += EnableButton;
    }
    
    void EnableButton( int _scanCode)
    {
        Button b1 = vbutton.GetComponent<Button>();
        TurnGreen(b1);
        b1.interactable = true;        
        vbutton.GetComponentInChildren<BoxCollider>().enabled = true;

        Button b2 = obutton.GetComponent<Button>();
        TurnGreen(b2);
        b2.interactable = true;
        obutton.GetComponentInChildren<BoxCollider>().enabled = true;

    }

    private void OnDisable()
    {
        AlertsHandler.OnScanPlateResult -= EnableButton;
    }

    public void TurnGreen(Button b)
    {
        ColorBlock colors = b.colors;
        colors.normalColor = new Color32(0, 225, 0, 80);
        b.colors = colors;
    }

}
