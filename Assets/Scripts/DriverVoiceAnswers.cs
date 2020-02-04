using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogoDigital.Lipsync;

[RequireComponent(typeof(LipSync))]
[RequireComponent(typeof(AudioSource))]

public class DriverVoiceAnswers : MonoBehaviour
{

    LipSync lipSync;
    public LipSyncData[] lipAnim = new LipSyncData[] { };
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        lipSync = GetComponent<LipSync>();
        if (lipSync == null)
            Debug.LogError("Couldn't load 'LipSync'");

        audioSource = GetComponent<AudioSource>();
        if (lipSync == null)
            Debug.LogError("Couldn't load 'AudioSource'");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayIDontKnow()
    {
        lipSync.Play(lipAnim[0]);
    }

    public void PlayHiOfficer()
    {
        lipSync.Play(lipAnim[1]);
    }

    public void PlayLetMeFind()
    {
        lipSync.Play(lipAnim[2]);
    }

    public void PlayOk()
    {
        lipSync.Play(lipAnim[3]);
    }


}
