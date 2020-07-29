using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBottle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HandleInteractableArea.OnEnterInteractableArea += ActivateIt; 
    }

    void ActivateIt()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }


}
