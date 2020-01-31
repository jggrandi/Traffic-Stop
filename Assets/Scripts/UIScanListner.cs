using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScanListner : MonoBehaviour
{
    public GameObject brackets;
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = Color.white;
    }

    bool isBracketsOn()
    {
        if (brackets != null)
            return true;
        return false;
    }

    protected virtual void ResetBracket()
    {
        if (!isBracketsOn()) return;
        ChangeBracketsColor(defaultColor);
    }

    protected virtual void ShowScanning(int _scanCode)
    {
        if (!isBracketsOn()) return;
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
        brackets.SetActive(true);
    }


    protected virtual void ShowResultOfScan(int _scanCode)
    {
        if (!isBracketsOn()) return;
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
    }


    void ChangeBracketsColor(Color colorCode)
    {
        if (!isBracketsOn()) return;
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }
}
