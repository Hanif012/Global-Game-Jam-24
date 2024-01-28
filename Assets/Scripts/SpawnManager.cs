using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    AudioSource audioSource;
    public Transform dartSpawnPosition;
    public GameObject dartPrefab;
    public Animator kingAnimator;
    
    [SerializeField]
    private GameObject yellowBalloonPrefab;
    [SerializeField]
    private GameObject orangeBalloonPrefab;
    public int numberYellow=0;
    public int numberOrange=0;
    public int counterYellow=0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SpawnDart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(counterYellow == numberYellow){
            
        }
    }
    public void PopSFX(){
        audioSource.Play();
    }
    // void SpawnBalloon(GameObject balloonPrefab){
    //     Vector3 randomizePosition = new Vector3(Random.Range(-13f, 1f), Random.Range(-3f, 1f), 0);
    //     Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
    //     Instantiate(balloonPrefab, randomizePosition, randomizeRotation);
    // }

    public void SpawnDart(){
        Debug.Log("Spawn Dart");
        GameObject dart = Instantiate(dartPrefab, dartSpawnPosition.position, Quaternion.identity);
        dart.GetComponent<Dart>().spawnManager = this;
        dart.GetComponent<Dart>().animator = kingAnimator;

    }
}
