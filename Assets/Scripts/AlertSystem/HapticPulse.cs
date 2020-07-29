using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace NextgenUI.AlertsEvaluation
{
    public class HapticPulse : MonoBehaviour
    {
        private Hand hand;

        void Start()
        {
            HapticAlert.OnStartHapticAlert += TriggerHapticPulse;
            HapticAlert.OnEndHapticAlert += NotImplemented;
            hand = this.gameObject.GetComponent<Hand>();
        }

        private void OnDisable()
        {
            HapticAlert.OnStartHapticAlert -= TriggerHapticPulse;
            HapticAlert.OnEndHapticAlert -= NotImplemented;
        }

        private void NotImplemented()
        {
            //throw new NotImplementedException();
        }

        void TriggerHapticPulse(HapticAlert _alert)
        {   
            //TODO: put the haptic pulse in a Coroutine
            hand.TriggerHapticPulse(_alert.coreAlertParameters.duration, _alert.AlertParameters.frequency, _alert.AlertParameters.amplitude);   
        }
    }
}