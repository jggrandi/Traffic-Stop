using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR.InteractionSystem;

namespace NextgenUI.AlertsEvaluation
{
    public class PlayerInteraction : MonoBehaviour
    {
        //Player player;
        private PlayerReaction playerReaction;
        private IInputProvider inputDevice;

        private bool buttonReleased = false;
        public static Action<PlayerReaction> OnEndTrial;

        void Start()
        {
            playerReaction = GetComponent<PlayerReaction>();
            inputDevice = GetComponent<IInputProvider>();
        }

        
        void Update()
        {

            // Wait until the reaction time window is open
            if (!playerReaction.IsTimerStarted()) return;

            // while the reaction time window is open, accept user inputs
            if (!playerReaction.IsTimerFinished())
            {
                // if the user already reacted
                if (buttonReleased) return;

                // reaction key pressed
                if (inputDevice.KeyStatus == Utils.ButtonStatus.held)
                {
                    // only counts as a reaction if the player was not reacted before to the current trial
                    if (!playerReaction.PreviouslyReacted())
                    {
                        playerReaction.Reacted();
                        Debug.Log(playerReaction.GetReactionTime());
                    }
                }
                // when the reaction key is released
                else if (inputDevice.KeyStatus == Utils.ButtonStatus.released)
                {
                    buttonReleased = true;
                    playerReaction.ReactedIntensity(inputDevice.OptionSelected);
                }
            }
            // when the react time window to the current trial ended sends a message "OnEndTrial" and reset the playerReaction parameters
            else
            {
                buttonReleased = false;
                OnEndTrial(playerReaction);

                playerReaction.Reset();
            }

            //// Dont allow reaction if out of the reaction window time
            //if (!playerReaction.IsInReactionWindow())
            //{
            //    inputDevice.OptionSelected = Alert.Intensity.none;
            //    reactionKeyReleased = false;
            //    return;
            //}

            //if (inputDevice.KeyStatus == Utils.ButtonStatus.none) return;

            //// Holding the reaction key
            //if (inputDevice.KeyStatus == Utils.ButtonStatus.held)
            //{
            //    if (!playerReaction.PreviouslyReacted())
            //    {
            //        playerReaction.Reacted();
            //        Debug.Log(playerReaction.GetReactionTime());
            //    }
            //}
            //// Releasing the reaction key
            //else if (inputDevice.KeyStatus == Utils.ButtonStatus.released)
            //{
            //    reactionKeyReleased = true;
            //    playerReaction.SecondPhase(inputDevice.OptionSelected);

            //    //TODO: Log
            //    OnEndTrial(playerReaction);
            //}


        }
    }
}
