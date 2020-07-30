using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace NextgenUI.AlertsEvaluation
{
    public class KeyboardInput : MonoBehaviour, IInputProvider
    {
        public Utils.ButtonStatus KeyStatus { get; set; }
        public Alert.Intensity OptionSelected { get; set; }

        private void Update()
        {
            KeyStatus = Utils.ButtonStatus.none;
            if (Input.GetKeyDown(KeyCode.Space))
                KeyStatus = Utils.ButtonStatus.presed; // first press
            else if (Input.GetKey(KeyCode.Space))
                KeyStatus = Utils.ButtonStatus.held; // held
            else if (Input.GetKeyUp(KeyCode.Space))
                KeyStatus = Utils.ButtonStatus.released; // released

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                OptionSelected = Alert.Intensity.low; // Low
            if (Input.GetKeyDown(KeyCode.DownArrow))
                OptionSelected = Alert.Intensity.medium; // High
            if (Input.GetKeyDown(KeyCode.RightArrow))
                OptionSelected = Alert.Intensity.high; // Med

        }
    }
}
