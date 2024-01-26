using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGoingUp = true;
    public float max;
    public float min;
    public GameObject balloon;
  
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        min = rb.position.y;

    }

    // Update is called once per frame
    void Update()
    {
		
        if(rb.position.y > min+max && isGoingUp==true)
        {
            rb.gravityScale *= -1;
            isGoingUp=false;
        }
        else if(rb.position.y < min && isGoingUp==false)
        {
            rb.gravityScale *= -1;
            isGoingUp=true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag =="weapon")
        {
            Destroy(balloon);
        }
    }
}
