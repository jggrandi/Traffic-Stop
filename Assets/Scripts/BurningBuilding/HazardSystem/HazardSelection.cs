using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class HazardSelection : MonoBehaviour
{
    public void OnPress()
    {
        GameObject.FindObjectOfType<HazardInstantiate>().set(GetComponent<Image>().sprite);
    }

}
