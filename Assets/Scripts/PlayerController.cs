using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    public bool isJumpPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
}
