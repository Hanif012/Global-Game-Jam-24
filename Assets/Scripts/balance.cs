using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{
    public Grab grab1;
    public Grab grab2;
    public balance groundcheck;
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;
    public bool isGroundCheck=false;
    public bool isGrounded;
    public bool isBalanced;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGroundCheck)
        {
            if(!groundcheck.isGrounded )
            {
                isBalanced=false;     
            }
            else
            {
                rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));
                isBalanced=true;  
            }
        }
        else
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(isGroundCheck && (other.tag =="Ground" || other.tag == "Platform")&& !isGrounded)
        {
            isGrounded=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        isGrounded=false;
    }
}
