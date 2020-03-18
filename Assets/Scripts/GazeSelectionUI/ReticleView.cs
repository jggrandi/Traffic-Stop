using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleView : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private UILayerSelector _selector;

    private Image _image; 

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<UILayerSelector>();

        _image = GetComponent<Image>();
    }

    private void Update()
    {
        DisableReticle();
        
        _selector.Check(_rayProvider.CreateRay());
        
        if (_selector.GetSelection() == null) return;
        
        EnableReticle();
    }

    void DisableReticle()
    {
        _image.enabled = false;
    }

    void EnableReticle()
    {
        _image.enabled = true;
    }
}
