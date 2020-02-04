using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandleInteractableArea : MonoBehaviour
{
    public static Action OnEnterInteractableArea;
    public static Action OnExitInteractableArea;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "HeadCollider")
            OnEnterInteractableArea();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "HeadCollider")
            OnExitInteractableArea();
    }
}
