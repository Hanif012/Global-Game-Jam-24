using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.CompareTag("Door") || other.transform.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}
