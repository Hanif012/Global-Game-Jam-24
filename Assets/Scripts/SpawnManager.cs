using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform dartSpawnPosition;
    public GameObject dartPrefab;
    [SerializeField]
    private GameObject yellowBalloonPrefab;
    [SerializeField]
    private GameObject orangeBalloonPrefab;
    int maxSpawnYellow = 3;
    int maxSpawnOrange = 3;
    public int numberYellow=0;
    public int numberOrange=0;
    public int counterYellow=0;
    // Start is called before the first frame update
    void Start()
    {
        maxSpawnYellow = Random.Range (1,maxSpawnYellow);
        maxSpawnOrange = Random.Range (0,maxSpawnOrange);
        SpawnDart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(counterYellow == maxSpawnYellow){
            Debug.Log("End");
        }
        if(numberYellow < maxSpawnYellow ){
            SpawnBalloon(yellowBalloonPrefab);
            numberYellow++;
        }
        if(numberOrange < maxSpawnOrange){
            SpawnBalloon(orangeBalloonPrefab);
            numberOrange++;
        }

        
    }
    void SpawnBalloon(GameObject balloonPrefab){
        Vector3 randomizePosition = new Vector3(Random.Range(-13f, 1f), Random.Range(-3f, 1f), 0);
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
        Instantiate(balloonPrefab, randomizePosition, randomizeRotation);
    }

    public void SpawnDart(){
        Instantiate(dartPrefab, dartSpawnPosition.position, Quaternion.identity);
    }
}
