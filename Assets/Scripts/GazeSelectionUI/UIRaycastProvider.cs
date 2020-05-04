using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

// Provides a list of UI element that were casted.

public class UIRaycastProvider : MonoBehaviour
{
    public List<RaycastResult> RaycastResults { get => raycastResults; set => raycastResults = value; }

    PointerEventData pointerEvent;
    EventSystem eventSystem;
    private List<RaycastResult> raycastResults;

    public void Start()
    {
        eventSystem = EventSystem.current;
        pointerEvent = new PointerEventData(eventSystem);
        pointerEvent.button = PointerEventData.InputButton.Left;
    }

    // Stores all UI element that the ray casted.
    private void RaycastUI()
    {
        RaycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEvent, RaycastResults);
    }

    public void SendClickAction(GameObject _obj)
    {
        IPointerClickHandler _clickHandler = _obj.GetComponent<IPointerClickHandler>();
        _clickHandler.OnPointerClick(pointerEvent);
    }

    public void OnHoverStart(GameObject _obj)
    {
        _obj.GetComponent<Selectable>().OnPointerEnter(pointerEvent);
    }

    public void OnHoverEnd(GameObject _obj)
    {
        _obj.GetComponent<Selectable>().OnPointerExit(pointerEvent);
    }


    private void Update()
    {
        // Updates the pointer position. It is center of the screen.
        pointerEvent.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight / 2);
        // Feeds the raycastResults list
        RaycastUI();

    }

}