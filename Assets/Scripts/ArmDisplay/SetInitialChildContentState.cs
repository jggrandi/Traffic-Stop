using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialChildContentState : MonoBehaviour
{
    private void Start()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }
}
