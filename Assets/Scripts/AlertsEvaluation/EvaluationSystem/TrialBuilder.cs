using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NextgenUI.AlertsEvaluation 
{
    public struct TypeLevel
    {
        public Alert.Type type; 
        public Alert.Intensity intensity;
    }

    public class TrialBuilder : MonoBehaviour
    {
        private int alertTypesQnt = 3;
        private int alertLevelsQnt = 3;
        private Alert alert;
        
        [SerializeField] private int trials;       
        
        public VisualAlertSO[] visualParameters = new VisualAlertSO[3];
        public SoundAlertSO[] soundParameters = new SoundAlertSO[3];
        public HapticAlertSO[] hapticParameters = new HapticAlertSO[3];

        public List<TypeLevel> AtlList { get; set; } = new List<TypeLevel>();

        void Start()
        {
            //alert[0] = GetComponent<VisualAlert>();
            //alert[1] = GetComponent<SoundAlert>();
            //alert[2] = GetComponent<HapticAlert>();

            //alertTypesQnt = alert.Length;
            //alertLevelsQnt = visualParameters.Length;

            // Create the trials list
            CreateList();

            // Randomize the list;
            AtlList.Shuffle();
        }

        private void CreateList()
        {
            for (int i = 0; i < trials; i++)
            {
                for (int j = 0; j < alertTypesQnt; j++)
                {
                    for (int k = 0; k < alertLevelsQnt; k++)
                    {
                        TypeLevel temp;
                        temp.type = (Alert.Type)j;
                        temp.intensity = (Alert.Intensity)k;
                        AtlList.Add(temp);
                    }
                }
            }
        }

        // Remove and return an alert
        public Alert PopAlert()
        {
            if (IsListEmpty()) return null;
            
            TypeLevel alertCandidate = AtlList[AtlList.Count - 1];
            AtlList.RemoveAt(AtlList.Count - 1);

            return BuildAlert(alertCandidate);
        }

        // Setup the alert based on the codification TypeLevel.
        private Alert BuildAlert(TypeLevel _alertCandidate)
        {
            if (_alertCandidate.type == Alert.Type.visual)
            {
                alert = GetComponent<VisualAlert>();
                ((VisualAlert)alert).AlertParameters = visualParameters[(int)_alertCandidate.intensity];
            }
            else if (_alertCandidate.type == Alert.Type.sound)
            {
                alert = GetComponent<SoundAlert>();
                ((SoundAlert)alert).AlertParameters = soundParameters[(int)_alertCandidate.intensity];
            }
            else if (_alertCandidate.type == Alert.Type.haptic)
            {
                alert = GetComponent<HapticAlert>();
                ((HapticAlert)alert).AlertParameters = hapticParameters[(int)_alertCandidate.intensity];
            }

            alert.AType = _alertCandidate.type;
            alert.AIntensity = _alertCandidate.intensity;

            return alert;
        }

        public bool IsListEmpty()
        {
            if (AtlList.Count == 0) 
                return true;
            return false;
        }

    }
}