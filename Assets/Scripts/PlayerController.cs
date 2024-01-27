using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    public bool isJumpPressed = false;
    [SerializeField] bool grounded;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
           isJumpPressed = true;
        //    Debug.Log("Update Jump");
         } 
    }

    void FixedUpdate()
    {
        if (isJumpPressed)
        {
            // Debug.Log("FixedUpdate Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);   
            isJumpPressed = false;
        }
        PlayerMovement();
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log(other.tag);
        if(other.tag =="Ground"&& !grounded)
        {
            grounded=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        grounded=false;
    }
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
}
