using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    public class LogHandler : MonoBehaviour
    {
        Log log;

        void Start()
        {
            StartLogRecording();
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
            Save();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //if (!isServer) return;
            //if (!isRecording) return;
            //if (isPaused) return;

            //RecordActiveTime();

            //if (countFrames % 5 == 0)
            //{
            //    var objId = syncParameters.activeTrial;
            //    log.SaveFull(objId, dockParameters.errorTrans[objId], dockParameters.errorRot[objId], dockParameters.errorRotAngle[objId], dockParameters.errorScale[objId], testParameters.playersActiveInScene);
            //}
        }

        public void StartLogRecording()
        {
            log = new Log(0,1);
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