using System.Collections.Generic;
using UnityEngine;

public class UILayerSelector : MonoBehaviour
{

    [SerializeField] string layerName = "UI";
    private GameObject _selection;
    private RaycastHit _hit;

    public void Check(Ray ray)
    {
        _selection = null;

        if (!Physics.Raycast(ray, out var hit)) return;

        var selection = hit.transform.gameObject;
        _hit = hit;
        if (selection.layer == LayerMask.NameToLayer(layerName))
        {
            _selection = selection;
        }
    }

    public RaycastHit GetHit()
    {
        return _hit;
    }
    public GameObject GetSelection()
    {
        return _selection;
    }
}