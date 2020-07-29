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
        //AlertsHandler.TriggerResultOfPlateScan += TriggerHapticPulse;
        //AlertsHandler.TriggerResultOfLicenseScan += TriggerHapticPulse;

        //AlertsHandler.OnScanDriverLicenseResult += TriggerHapticPulse;
        //AlertsHandler.OnScanPlateResult += TriggerHapticPulse;

        PlateScanListener.OnReady += TriggerHapticPulse;
        LicenseScanListener.OnReady += TriggerHapticPulse;

        hand = this.gameObject.GetComponent<Hand>();
    }

    //void TriggerHapticPulse( int _scanCode)
    //{
    //    hand.TriggerHapticPulse(1f, 100, 1f);
    //}

    void TriggerHapticPulse(GameObject _obj)
    {
        hand.TriggerHapticPulse(1f, 100, 1f);
    }

    private void OnDisable()
    {
        PlateScanListener.OnReady -= TriggerHapticPulse;
        LicenseScanListener.OnReady -= TriggerHapticPulse;
        //AlertsHandler.OnScanDriverLicenseResult -= TriggerHapticPulse;
        //AlertsHandler.OnScanPlateResult -= TriggerHapticPulse;
    }
}
