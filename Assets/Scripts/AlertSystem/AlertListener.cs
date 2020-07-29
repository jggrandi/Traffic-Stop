using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertListener : MonoBehaviour
{
    protected AlertObject alertObj;
    
    
    public GameObject highlighter;

    protected Color scanningColor = Color.magenta;
    private Color defaultColor = Color.white;

    //public GameObject Highlighter { get => highlighter; set => highlighter = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    protected void InitalSetup()
    {
        AlertsHandler.OnScan += ShowScanning;
        AlertsHandler.OnScanResult += ShowResult;
        HandleInteractableArea.OnExitInteractableArea += Reset;
        if (highlighter == null)
        {
            Debug.Log("No highlighter objects assigned.");
            return;
        }
        ResetHighlighColor();
        HideBrackets();
    }

    private void OnDisable()
    {
        AlertsHandler.OnScan -= ShowScanning;
        AlertsHandler.OnScanResult -= ShowResult;
        HandleInteractableArea.OnExitInteractableArea -= Reset;
    }


    private void Reset()
    {
        ResetHighlighColor();
        HideBrackets();
    }

    protected virtual void HideBrackets()
    {
        highlighter.GetComponent<MeshRenderer>().enabled = false;
    }

    protected virtual void ShowHighlight()
    {        
        highlighter.GetComponent<MeshRenderer>().enabled = true;
    }

    protected virtual bool IsHighlighing()
    {
        if (highlighter.GetComponent<MeshRenderer>().enabled)
            return true;
        return false;
    }

    protected virtual void ResetHighlighColor()
    {
        ChangeHighlighColor(defaultColor);
    }

    protected virtual void ShowScanning(GameObject _candidate)
    {
        if (_candidate != this.gameObject) return;
        if (!IsHighlighing()) ShowHighlight();
        Debug.Log("Scanning:" + _candidate);
        ChangeHighlighColor(scanningColor);
    }

    //protected virtual void ShowScanning(int _scanCode)
    //{
    //    if (!IsHighlighing()) ShowHighlight();
    //    Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
    //    ChangeHighlighColor(alertColor);
    //}


    protected virtual void ShowResult(GameObject _candidate)
    {   
        if (_candidate != this.gameObject) return;
        if (!IsHighlighing()) ShowHighlight();
        Debug.Log("Scan Result:" + _candidate);
        ChangeHighlighColor(Utils.DefineColorBasedOnAlertCode(alertObj.LevelAlert));
    }

    //protected virtual void ShowResultOfScan(int _scanCode)
    //{
    //    if (!IsHighlighing()) ShowHighlight();
    //    Color alertColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
    //    ChangeHighlighColor(alertColor);
    //}

    protected void ChangeHighlighColor(Color colorCode)
    {
        if (!IsHighlighing()) ShowHighlight();
        highlighter.GetComponent<Renderer>().material.color = colorCode;
    }
}
