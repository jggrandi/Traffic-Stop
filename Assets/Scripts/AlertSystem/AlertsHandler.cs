using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AlertsHandler : MonoBehaviour
{
    [SerializeField] float waitingTime = 4f;

    public static Action<GameObject> OnScan;
    public static Action<GameObject> OnScanResult;
    
    public ThreeDSelectionManager selectionManager;

    private IEnumerator coroutine;

    private void Start()
    {
        //selectionManager = GetComponent<SelectionManager>();
    }

    void Update()
    {
        if (!selectionManager.IsNewSelection) return;
        
        OnScan(selectionManager.CurrentSelection);

        coroutine = Wait3(selectionManager.CurrentSelection);
        StartCoroutine(coroutine);
    }

    private IEnumerator Wait3(GameObject _obj )
    {
        yield return new WaitForSeconds(waitingTime);
        OnScanResult(_obj);
    }
}
