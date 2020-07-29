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

        [SerializeField] private int secondPhaseSelection;

        private void Start()
        {
            ResetSecondPhaseSelection();
            timer = GetComponent<Timer>();
            timer.TimeLimit = maxReactionTime;
            SoundAlert.OnStartSoundAlert += StartNewReaction;
            VisualAlert.OnStartVisualAlert += StartNewReaction;
            HapticAlert.OnStartHapticAlert += StartNewReaction;

            //SoundAlert.OnEndSoundAlert += ResetReaction;
            //VisualAlert.OnEndVisualAlert += ResetReaction;
            //HapticAlert.OnEndHapticAlert += ResetReaction;
        }

        private void ResetSecondPhaseSelection()
        {
            secondPhaseSelection = -1;
        }

        private void OnDisable()
        {
            SoundAlert.OnStartSoundAlert -= StartNewReaction;
            VisualAlert.OnStartVisualAlert -= StartNewReaction;
            HapticAlert.OnStartHapticAlert = StartNewReaction;

            //SoundAlert.OnEndSoundAlert -= ResetReaction;
            //VisualAlert.OnEndVisualAlert -= ResetReaction;
            //HapticAlert.OnEndHapticAlert -= ResetReaction;
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
            timer.Reset();
        }

        public bool IsInReactionWindow()
        {            
            if (!timer.TimeIsUp)
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
        public bool IsReactionAllowed()
        {
            // the reaction needs to occur before the time window finished && just once.
            // if the time window finishes reset the reacted variable
            if (!timer.RunTimer) return false;

            if (!IsInReactionWindow() && PreviouslyReacted())
                return false;
                
            return true;
        }

        public void SecondPhase(int _optionSelected)
        {
            secondPhaseSelection = _optionSelected;
        }

        public float GetReactionTime()
        {
            return reactionTime;
        }

        private void Update()
        {
            if (!timer.RunTimer) return;

            if (!IsInReactionWindow())
            {
                ResetReactionTime();
                timer.Reset();
            }
        }

    }
}