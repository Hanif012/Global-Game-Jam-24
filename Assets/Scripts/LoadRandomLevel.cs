using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRandomLevel : MonoBehaviour
{
    public void LoadNextLevel(int currentIndex){
        int level = Random.Range(2, 8);
        while(level == currentIndex){
            level = Random.Range(2, 8);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
