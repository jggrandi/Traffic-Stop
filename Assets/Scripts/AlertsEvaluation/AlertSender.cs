using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    [RequireComponent(typeof(Timer))]
    public class AlertSender : MonoBehaviour
    {
        public Timer alertSnoozeTimer;
        [Range(1, 20)]
        public int minAlertWaitingTime;
        [Range(1, 20)]
        public int maxAlertWaitingTime;
        TrialBuilder trialBuilder;
        Alert alertCandidate;

        public void OnValidate()
        {
            minAlertWaitingTime = Mathf.Min(minAlertWaitingTime, maxAlertWaitingTime);
            maxAlertWaitingTime = Mathf.Max(minAlertWaitingTime, maxAlertWaitingTime);
        }

        void Start()
        {
            //get list of randomized sequence
            trialBuilder = GetComponent<TrialBuilder>();
            //get the timer
            alertSnoozeTimer = GetComponent<Timer>();
            alertSnoozeTimer.Reset();
        }

       
        void Update()
        {
            if (trialBuilder.IsListEmpty()) return;
            if (isAlertActive()) return;

            // wainting finish the time between alerts   
            if (!alertSnoozeTimer.RunTimer) 
            {
                alertSnoozeTimer.TimeLimit = Random.Range(minAlertWaitingTime, maxAlertWaitingTime);
                alertSnoozeTimer.StartRunTimer();
                print("Waiting time: Started -- " + alertSnoozeTimer.TimeLimit + "s");
            }
            // if the waiting time is up, send a new alert
            if (alertSnoozeTimer.TimeIsUp) 
            {
                print("Waiting time: Finished -- " + alertSnoozeTimer.TimeLimit + "s");
                
                // Get one alert from the list
                alertCandidate = trialBuilder.PopAlert();
                
                // Execute the alert
                if (alertCandidate != null)
                    alertCandidate.Run();
                
                alertSnoozeTimer.Reset();
            }
        }

        private bool isAlertActive()
        {
            if (alertCandidate == null) return false;

            if (alertCandidate.IsActive)
                return true;
            return false;
        }

    }
}