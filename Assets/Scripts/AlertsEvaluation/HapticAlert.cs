using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    public class HapticAlert : Alert
    {
        public static Action<HapticAlert> OnStartHapticAlert;
        public static Action OnEndHapticAlert;

        public HapticAlertSO AlertParameters { get; set; }

        public override void Run()
        {
            print("Haptic Alert: Started -- " + AlertParameters.name);
            OnStartHapticAlert(this);
            base.Run();
        }

        public override void Stop()
        {
            IsActive = false;
            print("Haptic Alert: Finished -- " + AlertParameters.name);
            OnEndHapticAlert();
        }
    }
}