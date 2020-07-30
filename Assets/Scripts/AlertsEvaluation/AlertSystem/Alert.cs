using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    public class Alert : MonoBehaviour
    {
        public enum Type {visual, sound, haptic, none};
        public enum Intensity {low, medium, high, none};

        public CoreAlertParameters coreAlertParameters;

        public bool IsActive { get; set; } = false;
        public Type AType { get; set; }
        public Intensity AIntensity { get; set; }

        public virtual void Run()
        {    
            IsActive = true;
            Invoke("Stop", coreAlertParameters.duration);
        }

        public virtual void Stop()
        {
        }
    }
}
