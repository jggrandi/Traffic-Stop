using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using RogoDigital.Lipsync;

public class SpeechRecognitionEngine : MonoBehaviour
{
    private Valve.VR.InteractionSystem.Sample.InteractableExample license;
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
    int GrabLicense = Animator.StringToHash("GrabLicense");
    int GetLicense = Animator.StringToHash("GetLicense");
    int LicensePass = Animator.StringToHash("LicensePass");
    int LicensePassReset = Animator.StringToHash("LicensePassReset");
    int Leave = Animator.StringToHash("Leave");
    int Open = Animator.StringToHash("Open");
    int Close = Animator.StringToHash("Close");
    int Reverse = Animator.StringToHash("Reverse");
    int PlaceLice = Animator.StringToHash("PlaceLice");


    public GameObject Selector3D;
    public GameObject driverLicense;
    private IEnumerator coroutine;

    void Start()
    {
        license = driverLicense.GetComponent<Valve.VR.InteractionSystem.Sample.InteractableExample>();
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
        if (other.name == "HeadCollider")
        {
            ready = true;
            amins[0].SetBool(HeadRot, true);
            amins[0].SetBool(LicensePassReset, false);
            amins[1].SetBool(Open, true);
            amins[1].SetBool(Close, false);
            //amins[0].SetBool(Leave, false);
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
            amins[1].SetBool(Close, true);
            amins[1].SetBool(Open, false);
        }
    }

    void Update()
    {
        if(license.isGrabing && !amins[0].GetBool(LicensePassReset))
        {
            amins[0].SetBool(LicensePassReset, true);
            amins[0].SetBool(HeadRot, false);
            amins[0].SetBool(LicensePass, false);
            amins[2].SetBool("Reset", true);
        }
        KeyTrigAnimation();
        if (!ready) return;
        if (word == "") return;
        int idWord = MatchSpeachToDatabase(word);
        if (idWord == -1) return;

        switch (idWord)
        {
            case 0:
                DriverLicensePass();
                break;
            case 1:
                LipSyncAction(LipAnim[0]);
                break;
            case 2:
                RestoreHandToNormalPose();
                break;
            case 3:
                ReturnDriverLicense();
                break;
            case 4:
            case 5:
                LipSyncAction(LipAnim[1]);
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

    void DriverLicensePass()
    {
        LipSyncAction(LipAnim[2]);
        amins[0].SetBool(HeadRot, false);
        amins[0].SetBool(LicensePass, true);
        amins[0].SetBool(Leave, false);
        amins[0].SetBool(LicensePassReset, false);

        coroutine = WaitToShowDriverLicense(5.7f);
        StartCoroutine(coroutine);

    }

    void LipSyncAction(LipSyncData lipAnim)
    {
        LipSync.Play(lipAnim);
    }

    void RestoreHandToNormalPose()
    {
        LipSyncAction(LipAnim[3]);
        amins[0].SetBool(HeadRot, false);
        amins[0].SetBool(LicensePass, false);
        amins[0].SetBool(LicensePassReset, true);
        amins[0].SetBool(Leave, false);
        amins[2].SetBool(Reverse, false);
        amins[2].SetBool(PlaceLice, false);
        driverLicense.SetActive(false);
        Selector3D.SetActive(false);
    }

    void ReturnDriverLicense()
    {
        amins[0].SetBool(HeadRot, false);
        amins[0].SetBool(LicensePass, false);
        amins[0].SetBool(LicensePassReset, false);
        amins[0].SetBool(Leave, false);
        amins[0].SetBool(GetLicense, true);
        amins[0].SetBool(GrabLicense, false);
    }

    void PutLicense()
    {
        driverLicense.SetActive(true);
        amins[0].SetBool(HeadRot, false);
        amins[0].SetBool(LicensePass, false);
        amins[0].SetBool(LicensePassReset, false);
        amins[0].SetBool(Leave, false);
        amins[0].SetBool(GetLicense, false);
        amins[0].SetBool(GrabLicense, true);
        amins[2].SetBool(Reverse, false);
        amins[2].SetBool(PlaceLice, true);
    }

    void KeyTrigAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DriverLicensePass();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LipSyncAction(LipAnim[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RestoreHandToNormalPose();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ReturnDriverLicense();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PutLicense();
        }

    }


    IEnumerator WaitToShowDriverLicense(float time)
    {
        Debug.Log("TTT");
        yield return new WaitForSeconds(time);
        driverLicense.SetActive(true);
    }

}