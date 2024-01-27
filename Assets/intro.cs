using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    void Start()
    {
        //Create timer for 5 seconds
        Invoke("LoadLevel", 5f);
    }

    void LoadLevel()
    {
        //Load level 1
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
