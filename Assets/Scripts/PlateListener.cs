using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlateListener : MonoBehaviour
{

    GameObject plateHighlighter;

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.OnScanPlate += ShowARPlate;
        AlertsHandler.OnScanPlateResult += ShowResultOfScan;

        //AlertsHandler.TriggerScanPlate += ShowARPlate;
        //AlertsHandler.TriggerResultOfPlateScan += HideScanBar;
        //AlertsHandler.TriggerResultOfPlateScan += ChangeBracketsColor;

        if (gameObject.transform.childCount > 0)
            plateHighlighter = gameObject.transform.GetChild(0).gameObject;
    }

    void ShowARPlate(int scanCode)
    {
        Color alertColor = DefineColorBasedOnAlertCode(scanCode);
        ChangeBracketsColor(alertColor);
        plateHighlighter.SetActive(true);
    }

    void ShowResultOfScan(int scanCode)
    {
        HideScanBar();
        Color alertColor = DefineColorBasedOnAlertCode(scanCode);
        ChangeBracketsColor(alertColor);
    }

    Color DefineColorBasedOnAlertCode(int _scanCode)
    {
        Color returnColor;
        switch (_scanCode)
        {
            case (int)AlertsHandler.ScanCode.Scanning:
                returnColor = Color.yellow;
                break;
            case (int)AlertsHandler.ScanCode.Clear:
                returnColor = Color.green;
                break;
            case (int)AlertsHandler.ScanCode.Warning:
                returnColor = Color.red;
                break;
            default:
                returnColor = Color.white;
                break;
        }
        return returnColor;
    }


    void HideScanBar()
    {
        GameObject plateScan = plateHighlighter.transform.GetChild(1).gameObject;
        plateScan.SetActive(false);
    }

    void ChangeBracketsColor(Color colorCode)
    {
        GameObject brackets = plateHighlighter.transform.GetChild(0).gameObject;
        brackets.GetComponent<Renderer>().material.color = colorCode;
    }

}
