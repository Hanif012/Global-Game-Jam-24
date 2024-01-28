using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Animator animator;
    public TimerSlider timers;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("yellowballoon"))
        {
            spawnManager.PopSFX();
            Destroy(other.gameObject);
            spawnManager.counterYellow++;
        }
        if(other.CompareTag("orangeballoon"))
        {
            spawnManager.PopSFX();
            // timers.time -= timers.time / 20;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("DartDelete"))
        {
            Destroy(gameObject);
            spawnManager.SpawnDart();
        }
        if(other.CompareTag("King"))
        {
            Destroy(gameObject);
            //King kena
            animator.SetBool("isHit", true);
        }
    }
}
