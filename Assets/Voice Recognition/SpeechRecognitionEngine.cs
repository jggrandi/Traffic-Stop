using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using RogoDigital.Lipsync;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public LipSync LipSync;
    public LipSyncData[] LipAnim = new LipSyncData[] { };
    private bool ready = false;
    public string[] keywords = new string[] { "license", "do you know", "thank", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public AudioSource[] audioSources = new AudioSource[] { };
    protected DictationRecognizer recognizer;
    public string word = "";
    //public bool trigger = false;
    public Animator[] amins = new Animator[] { };
    int HeadRot = Animator.StringToHash("HeadRot");
    int HeadRotBack = Animator.StringToHash("HeadRotBack");
    int LicensePass = Animator.StringToHash("LicensePass");
    int Driving = Animator.StringToHash("Driving");
    int LicensePassReset = Animator.StringToHash("LicensePassReset");
    int Leave = Animator.StringToHash("Leave");
    int Open = Animator.StringToHash("Open");
    int Close = Animator.StringToHash("Close");

    void Start()
    {
        recognizer = new DictationRecognizer();
        recognizer.Start();
        recognizer.DictationResult += (text, confidence) =>
        {
            word = text;
        };
        
    }

    //private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    word = args.text;
    //    results.text = "You said: <b>" + word + "</b>";
    //}
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if(other.name == "HeadCollider")
        {
            ready = true;
            amins[0].SetBool(HeadRotBack, false);
            amins[0].SetBool(HeadRot, true);
            amins[0].SetBool(LicensePassReset, false);
            amins[1].SetBool(Open, true);
            amins[1].SetBool(Close, false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "HeadCollider")
        {
            ready = false;
            amins[0].SetBool(HeadRot, false);
            amins[0].SetBool(LicensePassReset, false);
            amins[0].SetBool(Leave, true);
            amins[0].SetBool(LicensePass, false);
            amins[0].SetBool(Driving, false);
            amins[1].SetBool(Close, true);
            amins[1].SetBool(Open, false);
        }
    }

    void Update()
    {
        if (!ready) return;
        if (word == "") return;
        int idWord = MatchSpeachToDatabase(word);
        Debug.Log("ggg " + idWord);
        if (idWord == -1) return;

        switch (idWord)
        {
            case 0:
                amins[0].SetBool(HeadRot, false);
                amins[0].SetBool(HeadRotBack, false);
                amins[0].SetBool(LicensePass, true);
                amins[0].SetBool(Driving, false);
                amins[0].SetBool(Leave, false);
                amins[0].SetBool(LicensePassReset, false);
                break;
            case 1:
                LipSync.Play(LipAnim[0]);
                break;
            case 2:
                amins[0].SetBool(HeadRot, false);
                amins[0].SetBool(HeadRotBack, false);
                amins[0].SetBool(LicensePass, false);
                amins[0].SetBool(Driving, false);
                amins[0].SetBool(LicensePassReset, true);
                amins[0].SetBool(Leave, false);
                break;
            case 3:
                amins[0].SetBool(HeadRot, false);
                amins[0].SetBool(HeadRotBack, false);
                amins[0].SetBool(LicensePass, false);
                amins[0].SetBool(Driving, true);
                amins[0].SetBool(LicensePassReset, false);
                amins[0].SetBool(Leave, false);
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
        if (recognizer != null )
        {
            recognizer.Dispose();
            recognizer.Stop();
        }
    }
}
