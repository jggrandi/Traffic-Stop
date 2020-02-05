using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;


public class VoiceCommands : Commands
{
    Dictionary<DriverInteraction, string> keywords = new Dictionary<DriverInteraction, string>();
    //string[] keywords = new string[] { "license", "do you know", "thank", "hello" };
    protected DictationRecognizer recognizer;
    public string word = "";
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    private bool isAllowVoiceCommands = false;


    // Start is called before the first frame update
    void Start()
    {
        SetupCommands();

        AddWordsToKeywords();

        recognizer = new DictationRecognizer();
        recognizer.Start();
        recognizer.DictationResult += (text, confidence) =>
        {
            word = text;
        };

        HandleInteractableArea.OnEnterInteractableArea += AllowVoiceCommands;
        HandleInteractableArea.OnExitInteractableArea += DenyVoiceCommands;
    }
    private void OnDisable()
    {
        HandleInteractableArea.OnEnterInteractableArea -= AllowVoiceCommands;
        HandleInteractableArea.OnExitInteractableArea -= DenyVoiceCommands;

    }

    void AddWordsToKeywords()
    {
        keywords.Add(DriverInteraction.Greeting, "hello");
        keywords.Add(DriverInteraction.AskReasonToStop, "do you know");
        keywords.Add(DriverInteraction.Thank, "thank");
        keywords.Add(DriverInteraction.AskLicense, "license");
    }

    void AllowVoiceCommands()
    {
        isAllowVoiceCommands = true;
    }
    
    void DenyVoiceCommands()
    {
        isAllowVoiceCommands = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (recognizer.Status == SpeechSystemStatus.Stopped)
            recognizer.Start();

        if (!isAllowVoiceCommands) { word = ""; return; }
        if (word == "") return;
        DriverInteraction idWord = MatchSpeachToDatabase(word);
        if (idWord == DriverInteraction.Null) return;

        switch (idWord)
        {
            case DriverInteraction.AskLicense:
                FindDriversLicense();
                break;
            case DriverInteraction.AskReasonToStop:
                SayIDontKnow();
                break;
            case DriverInteraction.Thank:
                SayOk();
                WhenOfficerGetDriversLicense();
                break;
            case DriverInteraction.Greeting:
                SayHello();
                //LipSyncAction(LipAnim[1]);
                break;
            default:
                break;
        }
        word = "";
        idWord = DriverInteraction.Null;
    }

    DriverInteraction MatchSpeachToDatabase(string phraseSaid)
    {
        foreach(KeyValuePair<DriverInteraction,string> keyword in keywords)
            if (phraseSaid.Contains(keyword.Value))
                return keyword.Key;
        return DriverInteraction.Null;
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
