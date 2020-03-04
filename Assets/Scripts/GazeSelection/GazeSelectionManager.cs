using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GazeSelectionManager : MonoBehaviour
{
    private IReticle reticle;
    private UIRaycastProvider uiRaycastProvider;
    private ISelectionMode selector;

    GameObject activeObject;

    // Start is called before the first frame update
    void Awake()
    {
        reticle = GetComponent<IReticle>();
        uiRaycastProvider = GetComponent<UIRaycastProvider>();
        selector = GetComponent<ISelectionMode>();        
    }

    bool foundUIElement = false;

    public GameObject ActiveObject { get => activeObject; set => activeObject = value; }



    // Update is called once per frame
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
            selector.CandidateObject = castedObj.gameObject;
            if (!selector.Exists())
                continue;

            foundUIElement = true;

            if (ActiveObject != selector.CandidateObject)
            {
                Deselect(ActiveObject);
                Select(selector.CandidateObject);
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
            reticle.IsReticleHovering = true;
            uiRaycastProvider.OnHoverStart(ActiveObject);
            if(reticle.IsReadyToClick)
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
        reticle.Reset();
    }


}
