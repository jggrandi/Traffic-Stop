using System.Collections.Generic;
using UnityEngine;

// Checks if the ray is casting elements with the UI layer name.

public class UILayerSelector : MonoBehaviour
{

    [SerializeField] string layerName = "UI";
    private GameObject selection;
    private RaycastHit hit;

    public void Check(Ray _ray)
    {
        selection = null;

        if (!Physics.Raycast(_ray, out var _hit)) return;

        var _selection = _hit.transform.gameObject;
        hit = _hit;
        if (_selection.layer == LayerMask.NameToLayer(layerName))
            selection = _selection;
    }

    public RaycastHit GetHit()
    {
        return hit;
    }
    public GameObject GetSelection()
    {
        return selection;
    }
}