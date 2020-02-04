using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScanListner : MonoBehaviour
{
    public GameObject brackets;
    private Color defaultColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void InitalSetup()
    {
        if (!IsBracketsOn())
        {
            Debug.Log("The Brackets are not assigned to the object");
            return;
        }
        ResetBracketColor();
        HideBrackets();
    }

    bool IsBracketsOn()
    {
        if (brackets != null)
            return true;
        return false;
    }

    protected virtual void HideBrackets()
    {
        if (!IsBracketsOn()) return;
        brackets.GetComponent<MeshRenderer>().enabled = false;
    }

    protected virtual void ShowBrackets()
    {
        if (!IsBracketsOn()) return;
        brackets.GetComponent<MeshRenderer>().enabled = true;
    }

    protected virtual bool IsBracketsShowing()
    {
        if (brackets.GetComponent<MeshRenderer>().enabled)
            return true;
        return false;
    }

    protected virtual void ResetBracketColor()
    {
        if (!IsBracketsOn()) return;
        ChangeBracketsColor(defaultColor);
    }

    protected virtual void ShowScanning(int _scanCode)
    {
        if (!IsBracketsOn()) return;
        if(!IsBracketsShowing()) ShowBrackets();
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
    }


    protected virtual void ShowResultOfScan(int _scanCode)
    {
        if (!IsBracketsOn()) return;
        if (!IsBracketsShowing()) ShowBrackets();
        Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        ChangeBracketsColor(alertColor);
    }


    void ChangeBracketsColor(Color colorCode)
    {
        if (!IsBracketsOn()) return;
        if (!IsBracketsShowing()) ShowBrackets();
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }
}
