using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.TriggerResultOfPlateScan += DisableInstructions;
    }

    void DisableInstructions()
    {
        gameObject.SetActive(false);
    }
}
