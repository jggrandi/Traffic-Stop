using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInterFaceOnLook : Raycaster
{
    protected override void OnRaycasterEnter(GameObject target)
    {
        Debug.Log("HIT!");
        target.transform.GetChild(0).gameObject.SetActive(true);
    }

    protected override void OnRaycasterLeave(GameObject target)
    {
        Debug.Log("LEAVE!");
        target.transform.GetChild(0).gameObject.SetActive(false);
    }

}