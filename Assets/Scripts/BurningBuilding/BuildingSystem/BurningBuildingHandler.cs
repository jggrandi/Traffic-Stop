using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Diagnostics;


public class BurningBuildingHandler : MonoBehaviour
{
    // Delegate responsable to trigger all actions related to minimap content.
    public static Action<GameObject> UpdateContent;

    private void Start()
    {
    }

    void Update()
    {
        // Fires the UpdateContent on all scripts that are listining to this action.
        Action<GameObject> local = UpdateContent;
        if (local != null) UpdateContent(FindObjectOfType<MinimapListener>().gameObject);
    }

}
