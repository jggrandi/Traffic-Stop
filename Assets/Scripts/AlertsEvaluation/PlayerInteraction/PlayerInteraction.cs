using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace NextgenUI.AlertsEvaluation
{
    public class PlayerInteraction : MonoBehaviour
    {
        Player player;
        PlayerReaction playerReaction;
        IInputProvider inputDevice;

        private bool reactionKeyReleased = false;

        public static Action<PlayerReaction> OnEndTrial;

        void Start()
        {
            playerReaction = GetComponent<PlayerReaction>();
            inputDevice = GetComponent<IInputProvider>();
        }

        void Update()
        {
            // Dont allow reaction if out of the reaction window time
            if (!playerReaction.IsInReactionWindow())
            {
                inputDevice.OptionSelected = Alert.Intensity.none;
                reactionKeyReleased = false;
                return;
            }

            if (inputDevice.KeyStatus == Utils.ButtonStatus.none) return;

            // Holding the reaction key
            if (inputDevice.KeyStatus == Utils.ButtonStatus.held)
            {
                if (!playerReaction.PreviouslyReacted())
                {
                    playerReaction.Reacted();
                    Debug.Log(playerReaction.GetReactionTime());
                }
            }
            // Releasing the reaction key
            else if (inputDevice.KeyStatus == Utils.ButtonStatus.released)
            {
                reactionKeyReleased = true;
                playerReaction.SecondPhase(inputDevice.OptionSelected);

                //TODO: Log
                OnEndTrial(playerReaction);
            }


        }
    }
}
