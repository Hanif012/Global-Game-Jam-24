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
    public GameObject credit;
    // public GameObject hoverPlay;
    // public GameObject hoverSetting;
    // public GameObject hoverCredit;
    // public GameObject hoverExit;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        settings.SetActive(false);
        menu.SetActive(true);
        credit.SetActive(false);
        // hoverExit.SetActive(false);
        // hoverCredit.SetActive(false);
        // hoverPlay.SetActive(false);
        // hoverSetting.SetActive(false);
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
    public void OpenCredit(){
        audioManager.PlaySound("OpenMenu"); 
        credit.SetActive(true);
        menu.SetActive(false);
        animator.SetBool("creditOpen", true);
    }
    public void CloseCredit(){
        audioManager.PlaySound("CloseMenu"); 
        credit.SetActive(false);
        menu.SetActive(true);
        animator.SetBool("creditOpen", false);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void QuitGame(){
        Application.Quit();
    }

    // public void OnHoverPlay(){
    //     audioManager.PlaySound("Hover");
    //     hoverExit.SetActive(false);
    //     hoverCredit.SetActive(false);
    //     hoverPlay.SetActive(true);
    //     hoverSetting.SetActive(false);
    // }
    // public void OnHoverCredit(){
    //     audioManager.PlaySound("Hover");
    //     hoverExit.SetActive(false);
    //     hoverCredit.SetActive(true);
    //     hoverPlay.SetActive(false);
    //     hoverSetting.SetActive(false);
    // }
    // public void OnHoverSetting(){
    //     audioManager.PlaySound("Hover");
    //     hoverExit.SetActive(false);
    //     hoverCredit.SetActive(false);
    //     hoverPlay.SetActive(false);
    //     hoverSetting.SetActive(true);
    // }
    // public void OnHoverQuit(){
    //     audioManager.PlaySound("Hover");
    //     hoverExit.SetActive(true);
    //     hoverCredit.SetActive(false);
    //     hoverPlay.SetActive(false);
    //     hoverSetting.SetActive(false);   
    // }

    public void OnClick(){
        audioManager.PlaySound("Click");
    }
}
