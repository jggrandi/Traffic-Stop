using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


// Controls the behavior on when elements in the scene are scanned (Plate, Drivers License...).  

public class AlertsHandler : MonoBehaviour
{

    // Time delay to display the scan result.  
    [SerializeField] float scanningTime = 4f;

    // Delegate responsable to trigger all actions related to scan.
    public static Action<GameObject> OnScan;

    // Delegate responsable to trigger all actions related to scan results.
    public static Action<GameObject> OnScanResult;
    
    // Reference to the selection based on reticle in the center of the vision.
    public ThreeDSelectionManager selectionManager;

    private IEnumerator coroutine;

    void Update()
    {
        // Dont perform any check it is not a new element.
        if (!selectionManager.IsNewSelection) return;

        // Fires the OnScan on all scripts that are listining to this action.
        OnScan(selectionManager.CurrentSelection);

        coroutine = Wait(selectionManager.CurrentSelection);
        StartCoroutine(coroutine);
    }

    private IEnumerator Wait(GameObject _obj )
    {
        yield return new WaitForSeconds(scanningTime);
        // Fires the OnScanResult on all scripts that are listining to this action.
        OnScanResult(_obj);
    }
}
