using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleepiness : MonoBehaviour
{
    public Slider slider;
    public int time = 100;

    private float timer = 0f;
    public float delayAmount = 0f;
    void Update()
    {
        timer += Time.deltaTime;

         if (timer >= delayAmount)
         {
            timer = 0f;
            time--;
            setTime(time);
         }
    }
    public void setTime (int time){
        slider.value = time;
    }
}