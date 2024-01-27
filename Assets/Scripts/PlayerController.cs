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
    [SerializeField] public bool grounded;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
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
    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log(other.tag);
        if((other.tag =="Ground" || other.tag == "Platform")&& !grounded)
        { 

            grounded=true;
            audioManager.PlaySound("Landing");
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
