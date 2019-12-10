using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    private bool ready = false;
    public string[] keywords = new string[] { "license", "do you know", "thank", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public AudioClip[] audios = new AudioClip[] { };
    public AudioSource[] audioSources = new AudioSource[] { };
    protected DictationRecognizer recognizer;
    public string word = "";
    public Animator[] amins = new Animator[] { };
    int HeadRot = Animator.StringToHash("HeadRot");
    int HeadRotBack = Animator.StringToHash("HeadRotBack");
    int LicensePass = Animator.StringToHash("LicensePass");
    int Driving = Animator.StringToHash("Driving");
    int Idle = Animator.StringToHash("Idle");
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
            amins[0].SetBool(Idle, false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "HeadCollider")
        {
            ready = false;
            amins[0].SetBool(HeadRot, false);
            amins[0].SetBool(Idle, true);
            amins[0].SetBool(HeadRotBack, false);
            amins[0].SetBool(LicensePass, false);
            amins[0].SetBool(Driving, false);
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
                amins[0].SetBool(HeadRotBack, true);
                amins[0].SetBool(LicensePass, true);
                amins[0].SetBool(Driving, false);
                amins[0].SetBool(Idle, false);
                break;
            case 1:
                audioSources[0].clip = audios[0];
                audioSources[0].Play();
                break;
            case 2:
                amins[0].SetBool(HeadRot, false);
                amins[0].SetBool(HeadRotBack, false);
                amins[0].SetBool(LicensePass, false);
                amins[0].SetBool(Driving, true);
                amins[0].SetBool(Idle, false);
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
