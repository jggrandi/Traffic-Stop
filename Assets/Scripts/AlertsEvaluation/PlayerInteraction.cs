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

        void Start()
        {
            playerReaction = GetComponent<PlayerReaction>();
            inputDevice = GetComponent<IInputProvider>();
        }

        void Update()
        {
            if (inputDevice.IsMainKeyPressed)
            {
                if (playerReaction.IsReactionAllowed())
                {
                    playerReaction.Reacted();
                    Debug.Log(playerReaction.GetReactionTime());
                }
                playerReaction.SecondPhase(inputDevice.OptionSelected);
                Debug.Log(inputDevice.OptionSelected);
            }

        }
    }
}
