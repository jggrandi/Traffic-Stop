using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NextgenUI.AlertsEvaluation
{

    public class ManualAlertTester : MonoBehaviour
    {
        [SerializeField] VisualAlert visualAlert;
        [SerializeField] SoundAlert soundAlert;
        [SerializeField] HapticAlert hapticAlert;

        public VisualAlertSO[] visualIntensities = new VisualAlertSO[3];
        public SoundAlertSO[] soundIntensities = new SoundAlertSO[3];
        public HapticAlertSO[] hapticIntensities = new HapticAlertSO[3];

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                visualAlert.AlertParameters = visualIntensities[0];
                soundAlert.AlertParameters = soundIntensities[0];
                hapticAlert.AlertParameters = hapticIntensities[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                visualAlert.AlertParameters = visualIntensities[1];
                soundAlert.AlertParameters = soundIntensities[1];
                hapticAlert.AlertParameters = hapticIntensities[1];
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                visualAlert.AlertParameters = visualIntensities[2];
                soundAlert.AlertParameters = soundIntensities[2];
                hapticAlert.AlertParameters = hapticIntensities[2];
            }


            if (isAnyAlertActive()) return;

            if (Input.GetKeyDown(KeyCode.A))
                SendVAlert(); 
            if (Input.GetKeyDown(KeyCode.S))
                SendSAlert();
            if (Input.GetKeyDown(KeyCode.D))
                SendHAlert();

        }
        private bool isAnyAlertActive()
        {
            if (visualAlert.IsActive || soundAlert.IsActive || hapticAlert.IsActive)
                return true;
            return false;
        }

        private void SendHAlert()
        {
            hapticAlert.Run();
            HapticAlert.OnStartHapticAlert(hapticAlert);
        }

        private void SendSAlert()
        {
            soundAlert.Run();
            SoundAlert.OnStartSoundAlert(soundAlert);
        }


        void SendVAlert()
        {
            visualAlert.Run();
            VisualAlert.OnStartVisualAlert(visualAlert);
        }
    }
}
