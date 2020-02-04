using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;


public class VoiceCommands : Commands
{
    public string[] keywords = new string[] { "license", "do you know", "thank", "right" };
    protected DictationRecognizer recognizer;
    public string word = "";

    private bool ready = false;


    // Start is called before the first frame update
    void Start()
    {
        recognizer = new DictationRecognizer();
        recognizer.Start();
        recognizer.DictationResult += (text, confidence) =>
        {
            word = text;
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;
        if (word == "") return;
        int idWord = MatchSpeachToDatabase(word);
        if (idWord == -1) return;

        switch (idWord)
        {
            case 0:
                FindDriversLicense();
                //DriverLicensePass();
                break;
            case 1:
                SayIDontKnow();
                //LipSyncAction(LipAnim[0]);
                break;
            case 2:
                WhenOfficerGetDriversLicense();
                //RestoreHandToNormalPose();
                break;
            case 3:
                GoGetLicenseBack();
                //ReturnDriverLicense();
                break;
            case 4:
            case 5:
                SayHello();
                //LipSyncAction(LipAnim[1]);
                break;
            default:
                break;
        }
        word = "";
        idWord = -1;
    }

    int MatchSpeachToDatabase(string phraseSaid)
    {
        for (int i = 0; i < keywords.Length; i++)
            if (phraseSaid.Contains(keywords[i]))
                return i;
        return -1;
    }

    void OnApplicationQuit()
    {
        if (recognizer != null)
        {
            recognizer.Dispose();
            recognizer.Stop();
        }
    }

}
