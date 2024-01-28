using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public SpawnManager spawnManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("yellowballoon"))
        {
            spawnManager.PopSFX();
            Destroy(other.gameObject);
            spawnManager.counterYellow++;
        }
        if(other.CompareTag("orangeballoon"))
        {
            spawnManager.PopSFX();
            Destroy(other.gameObject);
        }
        if(other.CompareTag("DartDelete"))
        {
            Destroy(gameObject);
            spawnManager.SpawnDart();
        }
    }
}
