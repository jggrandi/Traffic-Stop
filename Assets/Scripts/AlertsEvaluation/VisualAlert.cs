using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NextgenUI.AlertsEvaluation
{
    public class VisualAlert : Alert
    {
        public static Action<VisualAlert> OnStartVisualAlert;
        public static Action OnEndVisualAlert;

        public VisualAlertSO AlertParameters { get; set; }

        public override void Run()
        {
            print("Visual Alert: Started -- " + AlertParameters.name);
            OnStartVisualAlert(this);
            base.Run();
        }

        public override void Stop()
        {
            IsActive = false;
            print("Visual Alert: Finished -- " + AlertParameters.name);
            OnEndVisualAlert(); 
        }
  
    }
}
