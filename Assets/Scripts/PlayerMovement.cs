using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 mousePos;

    GameObject grabPoint;
    public float handspeed = 2f;
    public float speed;
    Rigidbody2D rb;
    Rigidbody2D grabPointRB;
    public bool grabable = false;
    bool grabbing = false;
    Vector2 movement;

    public GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grabPoint = transform.GetChild(0).gameObject;
        grabPointRB = grabPoint.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, player.GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //make vector direction from player to mouse
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;

        rb.velocity = direction * handspeed;

        RaycastHit2D hit = Physics2D.Raycast(grabPoint.transform.position, Vector3.forward, 1f,1<<3);
        Debug.DrawRay(grabPoint.transform.position, Vector3.forward * 2f, Color.green);

        if (hit.collider != null)
        {
            Debug.Log("grabable");
            Debug.Log(hit.collider.gameObject.name);
            grabable = true;
        }else{
            Debug.Log("not grabable");
            grabable = false;
        }

        if (Input.GetMouseButton(0) && grabable){
            grabbing = true;
            player.GetComponent<DistanceJoint2D>().connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            player.GetComponent<DistanceJoint2D>().connectedAnchor = grabPoint.transform.position;
            player.GetComponent<DistanceJoint2D>().enabled = true;
            GetComponent<HingeJoint2D>().connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            GetComponent<HingeJoint2D>().enabled = true;
            // rb.bodyType = RigidbodyType2D.Static;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }else{
            grabbing = false;
            // rb.bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<HingeJoint2D>().enabled = false;
        }
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     Debug.Log("grabbed");
    //     if(Input.GetMouseButton(0)){
    //         this.GetComponent<HingeJoint2D>().connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
    //         this.GetComponent<HingeJoint2D>().enabled = true;
    //     }else{
    //         this.GetComponent<HingeJoint2D>().enabled = false;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     Debug.Log("exit");
    //     this.GetComponent<HingeJoint2D>().enabled = false;
    // }
    
    // private void OnCollisionStay2D(Collision2D other)
    // {
        
    // }
    // private void OnCollisionExit2D(Collision2D other)
    // {
        
    // }
}
