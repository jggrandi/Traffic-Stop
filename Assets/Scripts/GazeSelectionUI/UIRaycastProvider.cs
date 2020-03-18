using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class UIRaycastProvider : MonoBehaviour
{

    PointerEventData m_pointerEvent;
    IPointerClickHandler m_clickHandler;
    EventSystem m_eventSystem;
    private List<RaycastResult> raycastResults;

    int countRays;

    public List<RaycastResult> RaycastResults { get => raycastResults; set => raycastResults = value; }
    public int CountRays { get => countRays; set => countRays = raycastResults.Count; }

    public void Start()
    {
        m_eventSystem = EventSystem.current;
        m_pointerEvent = new PointerEventData(m_eventSystem);
        m_pointerEvent.button = PointerEventData.InputButton.Left;
    }

    public List<RaycastResult> RaycastUI()
    {
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        m_eventSystem.RaycastAll(m_pointerEvent, raycastResults);
        return raycastResults;
    }

    public void SendClickAction(GameObject _obj)
    {
        IPointerClickHandler clickHandler = _obj.GetComponent<IPointerClickHandler>();
        clickHandler.OnPointerClick(m_pointerEvent);
    }

    public void OnHoverStart(GameObject _obj)
    {
        _obj.GetComponent<Selectable>().OnPointerEnter(m_pointerEvent);
    }

    public void OnHoverEnd(GameObject _obj)
    {
        _obj.GetComponent<Selectable>().OnPointerExit(m_pointerEvent);
    }


    private void Update()
    {
        m_pointerEvent.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight / 2);
        RaycastResults = RaycastUI();
        CountRays = raycastResults.Count;
    }

}