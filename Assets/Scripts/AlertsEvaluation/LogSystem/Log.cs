using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;


namespace NextgenUI.AlertsEvaluation
{
    public class Log
    {

        private StreamWriter log;

        private Alert alertInfo;
        private float reactionTime;
        private Alert.Intensity intensityAnswer;
        private float timeStamp;

        public Log(int userID, int condition)
        {
            Debug.Log(Application.persistentDataPath);
            log = File.CreateText(Application.persistentDataPath + "/UserID-" + userID + "-Condition-" + condition + "---" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".csv");

            string header = "TimeStamp;AlertType;AlertIntensity;IntensityAnswer;ReactionTime";

            log.WriteLine(header);

        }

        public void Close()
        {
            log.Close();
        }

        public void Flush()
        {
            log.Flush();
        }


        public void BufferAlertInfo(Alert _alert)
        {
            alertInfo = _alert;
        }

        public void BufferPlayerReaction(PlayerReaction _playerReaction)
        {

            reactionTime = _playerReaction.GetReactionTime();
            intensityAnswer = _playerReaction.GetIntensityReaction();
        }

        public void BufferTimeStamp(float _timeStamp)
        {
            timeStamp = _timeStamp;
        }

        public void Save()
        {
            String line = "";
            line += timeStamp + ";";
            line += alertInfo.AType + ";" + alertInfo.AIntensity + ";";
            line += intensityAnswer + ";"+ reactionTime + ";";

            log.WriteLine(line);
            log.Flush();
        }


        //GameObject ContainsId(int _index, List<GameObject> _players)
        //{
        //    foreach (var p in _players)
        //    {
        //        if (p == null) continue;
        //        if (p.GetComponent<PlayerStuff>().id == _index)
        //            return p;
        //    }
        //    return null;
        //}




    }
}