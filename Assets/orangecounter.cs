using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangecounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TimerSlider timers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("weapon"))
        {
            timers.time -= 2000;
        }
    }
}
