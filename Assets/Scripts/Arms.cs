using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private int speed = 300;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector2 difference = new Vector2(playerpos.x - transform.position.x, playerpos.y - transform.position.y);
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if(Input.GetKey(key))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotation, speed * Time.fixedDeltaTime));   
        }  

        
    }
}
