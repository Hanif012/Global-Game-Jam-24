using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject levelLoader;
    public AudioMixer audioMixer;
    public Animator animator;
    public void PlayGame(){
        levelLoader.GetComponent<LoadRandomLevel>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }
    public void OpenSettings(){
        animator.SetBool("settingOpen", true);
    }
    public void CloseSettings(){
        animator.SetBool("settingOpen", false);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}
