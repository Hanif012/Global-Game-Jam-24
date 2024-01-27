using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioSource footstep;
    public Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    public bool isJumpPressed = false;
    public balance groundCheck;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            isJumpPressed = true;
            audioManager.PlaySound("Jump");
        //    Debug.Log("Update Jump");
        } 
        if(Mathf.Abs(rb.velocity.x) > 0.5f && grounded){
            if(!footstep.isPlaying){
                footstep.Play();
            }
        }
        else{
            footstep.Stop();
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
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
}
