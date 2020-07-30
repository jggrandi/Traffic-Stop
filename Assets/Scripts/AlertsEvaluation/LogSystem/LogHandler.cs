using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    public class LogHandler : MonoBehaviour
    {
        private Log log;
        private Timer timer;

        private float timeStamp;

        void Start()
        {
            timer = GetComponent<Timer>();
            timer.StartRunTimer();
            CreateNewLog(1,0);
            PlayerInteraction.OnEndTrial += SavePlayerReaction;
            VisualAlert.OnStartVisualAlert += SaveAlertInfo;
            SoundAlert.OnStartSoundAlert += SaveAlertInfo;
            HapticAlert.OnStartHapticAlert += SaveAlertInfo;
        }

        private void SaveAlertInfo(VisualAlert _alert)
        {
            SaveAlertInfo_(_alert);
        }
        private void SaveAlertInfo(SoundAlert _alert)
        {
            SaveAlertInfo_(_alert);
        }
        private void SaveAlertInfo(HapticAlert _alert)
        {
            SaveAlertInfo_(_alert);
        }

        private void SaveAlertInfo_(Alert _alert)
        {
            log.BufferAlertInfo(_alert);
        }


        private void SavePlayerReaction(PlayerReaction _playerReaction)
        {
            if (log == null) return;
            log.BufferPlayerReaction(_playerReaction);
            log.BufferTimeStamp(timer.elapsedTime);
            Save();
        }


        public void CreateNewLog(int _userID, int _condition)
        {
            log = new Log(_userID,_condition);
        }

        public void StopLogRecording()
        {
            log.Close();
        }

        public void Save()
        {
            log.Save();
        }

 
        void OnApplicationQuit()
        {
            StopLogRecording();
            PlayerInteraction.OnEndTrial -= SavePlayerReaction;
        }
    }
}