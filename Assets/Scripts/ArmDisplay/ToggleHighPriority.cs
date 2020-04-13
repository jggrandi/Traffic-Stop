using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHighPriority : MonoBehaviour
{
    protected void ToggleUION(GameObject _obj)
    {
        AlertObject aObj = _obj.GetComponent<AlertObject>();
        if (aObj.LevelAlert == AlertObject.AlertLevel.high)
        {
            ToggleElement te = GetComponent<ToggleElement>();
            te.menuElement.SetActive(true);
            te.canvasElement.GetComponent<CanvasGroup>().alpha = 1.0f;
        }

    }

}
