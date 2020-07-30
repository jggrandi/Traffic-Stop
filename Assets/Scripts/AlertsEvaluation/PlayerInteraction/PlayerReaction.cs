using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NextgenUI.AlertsEvaluation
{
    [RequireComponent(typeof(Timer))]

    public class PlayerReaction : MonoBehaviour
    {
        [SerializeField] private Timer timer;

        [SerializeField] private float maxReactionTime;

        [SerializeField] private bool reacted;
        [SerializeField] private float reactionTime;

        [SerializeField] private Alert.Intensity intensityReaction = Alert.Intensity.none;

        private void Start()
        {
            ResetIntensityReaction();
            timer = GetComponent<Timer>();
            timer.TimeLimit = maxReactionTime;

            VisualAlert.OnStartVisualAlert += StartNewReaction;
            SoundAlert.OnStartSoundAlert += StartNewReaction;
            HapticAlert.OnStartHapticAlert += StartNewReaction;

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
            Reset();
            StartTimer();
        }

        private void StartTimer()
        {
            timer.StartRunTimer();
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

            if (IsTimerStarted() && !IsTimerFinished())
                return true;
            return false;   
        }

        public bool IsTimerFinished()
        {
            if (timer.TimeIsUp)
                return true;
            return false;
        }

        public bool IsTimerStarted()
        {
            if (timer.RunTimer)
                return true;
            return false;
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

        public void ReactedIntensity(Alert.Intensity _optionSelected)
        {
            intensityReaction = _optionSelected;
        }

        public float GetReactionTime()
        {
            return reactionTime;
        }
        public Alert.Intensity GetIntensityReaction()
        {
            return intensityReaction;
        }

        private void ResetReaction()
        {
            reacted = false;
        }

        private void ResetIntensityReaction()
        {
            intensityReaction = Alert.Intensity.none;
        }

        public void ResetReactionTime()
        {
            reactionTime = 0;
        }

        public void ResetTimer()
        {
            timer.Reset();
        }

        public void Reset()
        {
            ResetReaction();
            ResetIntensityReaction();
            ResetReactionTime();
            ResetTimer();
        }

        private void Update()
        {
            //if (!IsInReactionWindow())
            //{
            //    ResetReactionTime();
            //    ResetIntensityReaction();
            //    timer.Reset();
            //}
        }

    }
}