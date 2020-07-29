using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NextgenUI.AlertsEvaluation 
{
    public struct TypeLevel
    {
        public int type; //0-Visual, 1-Audio, 2-Haptic
        public int level; //0-Low, 1-Med, 2-High
    }

    public class TrialBuilder : MonoBehaviour
    {
        private int alertTypesQnt;
        private int alertLevelsQnt;
        private Alert[] alert = new Alert[3];
        
        [SerializeField] private int trials;       
        
        public VisualAlertSO[] visualParameters = new VisualAlertSO[3];
        public SoundAlertSO[] soundParameters = new SoundAlertSO[3];
        public HapticAlertSO[] hapticParameters = new HapticAlertSO[3];

        public List<TypeLevel> AtlList { get; set; } = new List<TypeLevel>();

        void Start()
        {
            alert[0] = GetComponent<VisualAlert>();
            alert[1] = GetComponent<SoundAlert>();
            alert[2] = GetComponent<HapticAlert>();

            alertTypesQnt = alert.Length;
            alertLevelsQnt = visualParameters.Length;

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
                        temp.type = j;
                        temp.level = k;
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
            alert[_alertCandidate.type].coreAlertParameters.intensity = _alertCandidate.level;
            if (alert[_alertCandidate.type] is VisualAlert v)
            {
                v.AlertParameters = visualParameters[_alertCandidate.level];
                return v;
            }
            else if (alert[_alertCandidate.type] is SoundAlert s)
            {
                s.AlertParameters = soundParameters[_alertCandidate.level];
                return s;
            }
            else if (alert[_alertCandidate.type] is HapticAlert h)
            {
                h.AlertParameters = hapticParameters[_alertCandidate.level];
                return h;
            }
            return null;
        }

        public bool IsListEmpty()
        {
            if (AtlList.Count == 0) 
                return true;
            return false;
        }

    }
}