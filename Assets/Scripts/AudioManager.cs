using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public string audioName;
        public AudioClip audioClip;
    }
    public SoundAudioClip[] soundAudioClipArray;

    public void PlaySound(string name)
    {
        foreach(SoundAudioClip soundAudioClip in soundAudioClipArray)
        {
            if(soundAudioClip.audioName == name)
            {
                audioSource.clip = soundAudioClip.audioClip;
                audioSource.Play(0);
                break;
            }
        }
    }
}
