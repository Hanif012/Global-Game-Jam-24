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
    public Animator animenu;
    public Animator transition;
    public GameObject settings;
    public GameObject menu;
    public GameObject credit;


    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        settings.SetActive(false);
        menu.SetActive(true);
        credit.SetActive(false);
        animenu.SetTrigger("start");

    }

    public void PlayGame(){
        int level = Random.Range(2, 8);
        while(level == SceneManager.GetActiveScene().buildIndex){
            level = Random.Range(2, 8);
        }
        transition.SetTrigger("transIn");
        SceneManager.LoadScene(level);
    }
    public void SetVolume(float volume){
        AudioListener.volume = volume;
    }
    public void OpenSettings(){
        audioManager.PlaySound("OpenMenu"); 
        settings.SetActive(true);
        animenu.SetBool("openMenu", false);
        menu.SetActive(false);
        animator.SetBool("settingOpen", true);
    }
    public void CloseSettings(){
        audioManager.PlaySound("CloseMenu"); 
        settings.SetActive(false);
        menu.SetActive(true);
        animenu.SetBool("openMenu", true);
        animator.SetBool("settingOpen", false);
    }
    public void OpenCredit(){
        audioManager.PlaySound("OpenMenu"); 
        credit.SetActive(true);
        animator.SetBool("creditOpen", true);
        animenu.SetBool("openMenu", false);
        menu.SetActive(false);

    }
    public void CloseCredit(){
        audioManager.PlaySound("CloseMenu"); 
        credit.SetActive(false);
        animator.SetBool("creditOpen", false);
        menu.SetActive(true);
        animenu.SetBool("openMenu", true);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void OnClick(){
        audioManager.PlaySound("Click");
    }
}
