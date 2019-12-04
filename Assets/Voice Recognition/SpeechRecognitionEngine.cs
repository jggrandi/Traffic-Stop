using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    private bool ready = false;
    public string[] keywords = new string[] { "driver license", "do you know", "left", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public AudioClip[] audios = new AudioClip[] { };
    public AudioSource[] audioSources = new AudioSource[] { };
    protected DictationRecognizer recognizer;
    private string word = "";
    public Animator[] amins = new Animator[] { };
    int HeadRot = Animator.StringToHash("HeadRot");
    int HeadRotBack = Animator.StringToHash("HeadRotBack");
    int Walk = Animator.StringToHash("Walk");
    int LicensePass = Animator.StringToHash("LicensePass");
    int Driving = Animator.StringToHash("Driving");

    void Start()
    {
        recognizer = new DictationRecognizer();
        recognizer.DictationResult += (text, confidence) =>
        {
            word = text;
        };
        recognizer.Start();
    }

    //private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    word = args.text;
    //    results.text = "You said: <b>" + word + "</b>";
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "BodyCollider")
        {
            ready = true;
            amins[0].SetBool(HeadRot, true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        ready = false;
    }

    void Update()
    {
        //var x = target.transform.position.x;
        //var y = target.transform.position.y;

        for (int i = 0; i< keywords.Length; i++)
        {
            if ( ready && word.Contains(keywords[i]))
            {
                switch (i)
                {
                    case 0:
                        amins[0].SetBool(HeadRot, false);
                        amins[0].SetBool(HeadRotBack, true);
                        amins[0].SetBool(LicensePass, true);
                        word = "";
                        break;
                    case 1:
                        audioSources[0].clip = audios[0];
                        audioSources[0].Play();
                        word = "";
                        break;
                    default:
                        amins[0].SetBool(HeadRotBack, false);
                        amins[0].SetBool(LicensePass, false);
                        break;
                }
            }
        }
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
