using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Sprite deadSprite;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            GameObject.Find("Pupil").SetActive(false);
            GameObject.Find("Pupilkiri").SetActive(false);
            GameObject.Find("Head").SetActive(false);
            GameObject.Find("bone_1").GetComponent<PlayerController>().dead = true;
            GameObject.Find("bone_1").GetComponent<PlayerController>().groundCheck.dead = true;
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().Died();
        }
    }
}
