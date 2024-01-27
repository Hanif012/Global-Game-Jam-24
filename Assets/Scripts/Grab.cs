using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public AudioManager audioManager;
    public bool hold;
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
                    if(GetComponent<FixedJoint2D>().connectedBody.transform.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Kinematic){
                        audioManager.PlaySound("Throw");
                    }
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
                Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
                if(rb != null){
                    Debug.Log("grabbed");
                    audioManager.PlaySound("Grab");
                    FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                    fj.connectedBody = rb;
                }
            }
        }
    }
}
