using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NextgenUI.AlertsEvaluation
{
    [RequireComponent(typeof(Timer))]

    public class PlayerReaction : MonoBehaviour
    {
        public Timer timer;

        [SerializeField] private float maxReactionTime;

        [SerializeField] private bool reacted;
        [SerializeField] private float reactionTime;

        [SerializeField] private Alert.Intensity intensityReaction;

        private void Start()
        {
            ResetSecondPhaseSelection();
            timer = GetComponent<Timer>();
            timer.TimeLimit = maxReactionTime;

            VisualAlert.OnStartVisualAlert += StartNewReaction;
            SoundAlert.OnStartSoundAlert += StartNewReaction;
            HapticAlert.OnStartHapticAlert += StartNewReaction;

        }

        private void ResetSecondPhaseSelection()
        {
            intensityReaction = Alert.Intensity.none;
        }

        private void OnDisable()
        {
            SoundAlert.OnStartSoundAlert -= StartNewReaction;
            VisualAlert.OnStartVisualAlert -= StartNewReaction;
            HapticAlert.OnStartHapticAlert -= StartNewReaction;
        }

        private void StartNewReaction(SoundAlert obj)
        {
            StartNewReaction();
        }
        private void StartNewReaction(VisualAlert obj)
        {
            StartNewReaction();
        }
        private void StartNewReaction(HapticAlert obj)
        {
            StartNewReaction();
        }

        private void StartNewReaction()
        {
            ResetReaction();
            ResetReactionTime();
            ResetSecondPhaseSelection();
            StartTimer();
        }

        private void StartTimer()
        {
            timer.StartRunTimer();
        }

        public void ResetReaction()
        {
            reacted = false;
        }

        public void Reacted()
        {
            reacted = true;
            reactionTime = timer.elapsedTime;
        }

        public bool IsInReactionWindow()
        {
            //  Start      Finish
            //    |----------| reaction window
            // RunTimer   TimeIsUP

            if (timer.RunTimer && !timer.TimeIsUp )
                return true;
            return false;   
        }

        private void ResetReactionTime()
        {
            reactionTime = 0;
        }

        public bool PreviouslyReacted()
        {
            return reacted;
        }

        //  Check if reaction is allowed
        //public bool IsReactionAllowed()
        //{
        //    // the reaction needs to occur before the time window finished && just once.
        //    // if the time window finishes reset the reacted variable
        //    if (!timer.RunTimer) return false;

        //    if (!IsInReactionWindow() && PreviouslyReacted())
        //        return false;
                
        //    return true;
        //}

        public void SecondPhase(Alert.Intensity _optionSelected)
        {
            intensityReaction = _optionSelected;
        }

        public float GetReactionTime()
        {
            return reactionTime;
        }
        public Alert.Intensity GetSecondPhase()
        {
            return intensityReaction;
        }

        private void Update()
        {
            if (!IsInReactionWindow())
            {
                ResetReactionTime();
                ResetSecondPhaseSelection();
                timer.Reset();
            }
        }

    }
}