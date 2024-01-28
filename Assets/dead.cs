using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{
    public TimerSlider timer;
    public HingeJoint2D hinge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.time==0){
            hinge.enabled=false;
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().TimerFinish();
        }
    }
}
