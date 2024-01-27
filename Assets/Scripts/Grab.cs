using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool hold;
    public KeyCode key;
    private void Update()
    {
        if (Input.GetKey(key))
        {
            // Debug.Log("pressed");
            hold = true;
        }
        else
        {
            hold = false;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if(!collision.transform.CompareTag("Player") && !collision.transform.CompareTag("Ground") && !hold)
        {
            Debug.Log("exit");
            //not working 
            SoundManager.PlaySound(SoundManager.Sound.PlayerThrow);
        }
    }
}
