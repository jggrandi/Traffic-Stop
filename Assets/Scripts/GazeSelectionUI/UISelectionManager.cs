using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UISelectionManager : MonoBehaviour
{
    private TimerClick timerClick;
    private UIRaycastProvider uiRaycastProvider;
    private ISelectionMode selectorMode;

    GameObject activeObject;

    // Start is called before the first frame update
    void Awake()
    {
        timerClick = GetComponent<TimerClick>();
        uiRaycastProvider = GetComponent<UIRaycastProvider>();
        selectorMode = GetComponent<ISelectionMode>();        
    }

    bool foundUIElement = false;

    public GameObject ActiveObject { get => activeObject; set => activeObject = value; }

    void Update()
    {
        //Debug.Log(uiRaycastProvider.CountRays);
        if ( uiRaycastProvider.CountRays <= 2)
        {
            Deselect(ActiveObject);
            return;
        }
        foundUIElement = false;

        foreach (var castedObj in uiRaycastProvider.RaycastResults)
        {
            selectorMode.CandidateObject = castedObj.gameObject;
            if (!selectorMode.Exists())
                continue;

            foundUIElement = true;

            if (ActiveObject != selectorMode.CandidateObject)
            {
                Deselect(ActiveObject);
                Select(selectorMode.CandidateObject);
                break;
            }
        }

        if (!foundUIElement)
        {
            Deselect(ActiveObject);
            return;
        }

        if (ActiveObject)
        {
            timerClick.StartRunTimer();

            uiRaycastProvider.OnHoverStart(ActiveObject);
            if(timerClick.isReadyToClick)
                uiRaycastProvider.SendClickAction(ActiveObject);
        }
    }

    private void Select(GameObject _obj)
    {
        ActiveObject = _obj;
    }

    private void Deselect(GameObject _obj)
    {
        if (_obj != null)
        {
            uiRaycastProvider.OnHoverEnd(_obj);
            _obj = null;
        }
        timerClick.Reset();
    }
}
