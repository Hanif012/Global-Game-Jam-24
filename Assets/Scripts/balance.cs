using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{
    public PlayerController playerController;
    public Grab grab1;
    public Grab grab2;

    public float targetRotation;
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.grounded && (grab1.hold || grab2.hold))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));       
        }
    }
}
