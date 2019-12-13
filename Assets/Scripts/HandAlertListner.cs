using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandAlertListner : MonoBehaviour
{

    Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        AlertsHandler.TriggerResultOfPlateScan += TriggerHapticPulse;
        hand = this.gameObject.GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerHapticPulse()
    {
        hand.TriggerHapticPulse(1f, 100, 1f);
    }
}
