using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    public class Alert : MonoBehaviour
    {
        public CoreAlertParameters coreAlertParameters;

        public bool IsActive { get; set; } = false;

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
