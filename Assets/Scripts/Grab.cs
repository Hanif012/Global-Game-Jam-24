using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool hold;
    public KeyCode key;
    private void Update()
    {
        if(Input.GetKey(key))
        {
            // Debug.Log("pressed");
            hold = true;
        }else{
            hold = false;
            Destroy(GetComponent<FixedJoint2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.CompareTag("Player") && !other.transform.CompareTag("Ground"))
        {
            Debug.Log(hold);
            if(hold)
            {
                Debug.Log("grabbed");
                Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
                Debug.Log(rb);
                if(rb != null){
                    FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                    fj.connectedBody = rb;
                }else{
                    FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                }
            }
        }
    }
}
