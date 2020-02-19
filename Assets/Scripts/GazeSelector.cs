using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.XR;
using DentedPixel;
public class GazeSelector : MonoBehaviour
{
    [SerializeField, Tooltip("In seconds")]
    float m_loadingTime;

    GameObject reticle;
    GameObject radialProgressBar;
    
    Image imageRadialProgressBar;


    float m_elapsedTime = 0;

    // Prevents loop over the same selectable
    Selectable m_excluded; 
    Selectable m_currentSelectable;

    IPointerClickHandler m_clickHandler;

    EventSystem m_eventSystem;
    PointerEventData m_pointerEvent;

    private void Start()
    {
        m_eventSystem = EventSystem.current;
        m_pointerEvent = new PointerEventData(m_eventSystem);
        m_pointerEvent.button = PointerEventData.InputButton.Left;

        reticle = this.transform.GetChild(0).gameObject;
        radialProgressBar = this.transform.GetChild(1).gameObject;
        
        imageRadialProgressBar = radialProgressBar.GetComponent<Image>();
        imageRadialProgressBar.fillAmount = 0;
    }

    void Update()
    {
        // Set pointer position
        m_pointerEvent.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight / 2);


        List<RaycastResult> raycastResults = new List<RaycastResult>();
        m_eventSystem.RaycastAll(m_pointerEvent, raycastResults);

        // Detect selectable
        if (raycastResults.Count > 0)
        {
            foreach(var result in raycastResults)
            {
                var newSelectable = result.gameObject.GetComponentInParent<Selectable>();

                if (newSelectable)
                {
                    LeanTween.scale(reticle, new Vector3(1.8f, 1.8f, 1.8f), 1f).setEase(LeanTweenType.easeInExpo);
                    if(newSelectable != m_excluded && newSelectable != m_currentSelectable)
                        Select(newSelectable);
                    break;
                }
            }
        }
        else
        {
            LeanTween.scale(reticle, new Vector3(1f, 1f, 1f), 0.1f);
            if (m_currentSelectable || m_excluded)
            {
                Select(null, null);
            }
        }

        // Target is being activating
        if (m_currentSelectable)
        {
            m_elapsedTime += Time.deltaTime;
            imageRadialProgressBar.fillAmount = m_elapsedTime / m_loadingTime;
            //m_onLoad.Invoke(m_elapsedTime / m_loadingTime);

            if (m_elapsedTime > m_loadingTime)
            {
                if (m_clickHandler != null)
                {
                    m_clickHandler.OnPointerClick(m_pointerEvent);
                    Select(null, m_currentSelectable);
                }
                //else if (m_dragHandler != null)
                //{
                //    m_pointerEvent.pointerPressRaycast = m_currentRaycastResult;
                //    m_dragHandler.OnDrag(m_pointerEvent);
                //}
            }
        }
    }

    void Select(Selectable s, Selectable exclude = null)
    {
        m_excluded = exclude;

        if (m_currentSelectable)
            m_currentSelectable.OnPointerExit(m_pointerEvent);

        m_currentSelectable = s;

        if (m_currentSelectable)
        {
            m_currentSelectable.OnPointerEnter(m_pointerEvent);
            m_clickHandler = m_currentSelectable.GetComponent<IPointerClickHandler>();
        }

        m_elapsedTime = 0;
        imageRadialProgressBar.fillAmount = m_elapsedTime / m_loadingTime;
    }
}
