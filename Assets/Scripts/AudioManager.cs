using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    enum Sound{
        PlayerThrow,
        PlayerJump,
        PlayerWalk
    }
    [System.Serializable]
    public class SoundAudioClip
    {
        public string audioName;
        public AudioClip audioClip;
    }
    public SoundAudioClip[] soundAudioClipArray;

    public void PlaySound()
    {
        audioSource.clip = soundAudioClipArray[0].audioClip;
        audioSource.Play(0);
    }
}
