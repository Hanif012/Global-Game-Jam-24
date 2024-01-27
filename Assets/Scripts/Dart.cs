using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("yellowballoon"))
        {
            Destroy(other.gameObject);
            spawnManager.counterYellow--;
        }
        if(other.CompareTag("orangeballoon"))
        {
            Destroy(other.gameObject);
        }
        if(other.CompareTag("DartDelete"))
        {
            Destroy(gameObject);
            spawnManager.SpawnDart();
        }
    }
}
