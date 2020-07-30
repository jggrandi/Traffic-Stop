using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextgenUI.AlertsEvaluation
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
     
        void Start()
        {
            SoundAlert.OnStartSoundAlert += PlaySound;
            SoundAlert.OnEndSoundAlert += PauseSound;
            audioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            SoundAlert.OnStartSoundAlert -= PlaySound;
            SoundAlert.OnEndSoundAlert -= PauseSound;
        }

        private void PauseSound()
        {
            audioSource.Pause();
        }

        private void PlaySound(SoundAlert _alert)
        {
            audioSource.volume = _alert.AlertParameters.loudness;
            audioSource.Play();
        }
    }
}