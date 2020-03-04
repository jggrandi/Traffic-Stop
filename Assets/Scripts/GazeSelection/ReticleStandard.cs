using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class ReticleStandard : MonoBehaviour, IReticle
{

    private bool isReadyToClick;
    private bool isReticleHovering;

    public bool IsReadyToClick { get => isReadyToClick; set => isReadyToClick = value; }
    public bool IsReticleHovering { get => isReticleHovering; set => isReticleHovering = value; }

    private void Start()
    {
        for (int i = 1; i < this.transform.childCount; i++) // disable all but reticle point;
            this.transform.GetChild(i).gameObject.SetActive(false);
    }

    public void Reset()
    {
        IsReadyToClick = false;
        IsReticleHovering = false;
    }

    private void Update()
    {
        IsReadyToClick = true;

    }


}