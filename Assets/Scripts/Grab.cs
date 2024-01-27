using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public AudioManager audioManager;
    private bool hold;
    public KeyCode key;
    private void Update()
    {
        if (Input.GetKey(key))
        {
            hold = true;

        }
        else
        {
            hold = false;
            if(GetComponent<FixedJoint2D>() != null){
                if(GetComponent<FixedJoint2D>().connectedBody != null){
                    Debug.Log("throw audio");
                    audioManager.PlaySound();
                }
            }
            Destroy(GetComponent<FixedJoint2D>());
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.CompareTag("Player") && !other.transform.CompareTag("Ground")&& !other.transform.CompareTag("yellowballoon") && !other.transform.CompareTag("orangeballoon"))
        {
            if(hold)
            {
                Debug.Log("grabbed");
                Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
                if(rb != null){
                    FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                    fj.connectedBody = rb;
                }
            }
        }
    }
}
