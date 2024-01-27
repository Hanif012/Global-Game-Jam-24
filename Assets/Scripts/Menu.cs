using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    AudioManager audioManager;
    public Animator animator;
    public GameObject settings;
    public GameObject menu;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void PlayGame(){
        int level = Random.Range(2, 8);
        while(level == SceneManager.GetActiveScene().buildIndex){
            level = Random.Range(2, 8);
        }
        SceneManager.LoadScene(level);
    }
    public void SetVolume(float volume){
        AudioListener.volume = volume;
    }
    public void OpenSettings(){
        audioManager.PlaySound("OpenMenu"); 
        settings.SetActive(true);
        menu.SetActive(false);
        animator.SetBool("settingOpen", true);
    }
    public void CloseSettings(){
        audioManager.PlaySound("CloseMenu"); 
        settings.SetActive(false);
        menu.SetActive(true);
        animator.SetBool("settingOpen", false);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void OnHover(){
        audioManager.PlaySound("Hover");
    }

    public void OnClick(){
        audioManager.PlaySound("Click");
    }
}
