using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

// Controls the selection of the UI elements in the scene.

[RequireComponent(typeof(TagSelector))]
public class UISelectionManager : MonoBehaviour
{
    public GameObject ActiveObject { get => activeObject; set => activeObject = value; }

    // Handle timer to confirm selection.
    private TimerClick timerClick;
    
    // Ray provider for the UI selector
    private UIRaycastProvider uiRaycastProvider;

    // Define what is the rule to select UI elements (currently it is using the TagSelector script).
    private TagSelector selector;
    private bool foundCandidateUIElement = false;
    private GameObject activeObject;

    void Awake()
    {
        selector = GetComponent<TagSelector>();

        uiRaycastProvider = GetComponent<UIRaycastProvider>();

        timerClick = GetComponent<TimerClick>();
    }

    void Update()
    {
        foundCandidateUIElement = false;

        foreach (var castedObj in uiRaycastProvider.RaycastResults)
        {
            selector.CandidateObject = castedObj.gameObject;
            if (!selector.Exists())
                continue;

            foundCandidateUIElement = true;

            if (ActiveObject != selector.CandidateObject)
            {
                Deselect(ActiveObject);
                Select(selector.CandidateObject);
                break;
            }
        }

        if (!foundCandidateUIElement)
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
