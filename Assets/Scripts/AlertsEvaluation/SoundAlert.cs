using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation { 
    public class SoundAlert : Alert
    {
        public static Action<SoundAlert> OnStartSoundAlert;
        public static Action OnEndSoundAlert;

        public SoundAlertSO AlertParameters { get; set; }

        public override void Run()
        {
            print("Sound Alert: Started -- " + AlertParameters.name);
            OnStartSoundAlert(this);
            base.Run();
        }

        public override void Stop()
        {
            IsActive = false;
            print("Sound Alert: Finished -- " + AlertParameters.name);
            OnEndSoundAlert();
        }

    }
}
