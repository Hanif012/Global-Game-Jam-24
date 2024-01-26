using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int numberYellow=0;
    public int numberOrg=0;
    public int maxSpawnYellow=0;
    public int maxSpawnOrg=0;
    public int counterYellow=0;
    public int counterOrange=0;
     [SerializeField] public GameObject stuffOverRoad;
    GameObject thingOverRoad;
    [SerializeField] public GameObject stuffOverRoadOrg;
    GameObject thingOverRoadOrg;
   
    void CreateStuffOnRoad()
    {
        //update the x & z values depending on the specific boundaries of your scene
        Vector3 randomizePosition = new Vector3(Random.Range(-13, 1), Random.Range(-3, 1), 0);
 
        //update the y value depending on how much you want the thing to randomly rotate
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
 
        thingOverRoad = Instantiate(stuffOverRoad, randomizePosition, randomizeRotation);
    }
    void CreateStuffOnRoadOrg()
    {
        //update the x & z values depending on the specific boundaries of your scene
        Vector3 randomizePosition = new Vector3(Random.Range(-13, 1), Random.Range(-3, 1), 0);
 
        //update the y value depending on how much you want the thing to randomly rotate
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
 
        thingOverRoadOrg = Instantiate(stuffOverRoadOrg, randomizePosition, randomizeRotation);
    }
    void Start()
    {
        numberYellow = Random.Range (1,maxSpawnYellow);
        numberOrg = Random.Range (0,maxSpawnOrg);
    }

    void Update()
    {
         if(numberYellow > 0){
            CreateStuffOnRoad();
            numberYellow--;
         }
         if(numberOrg > 0){
            CreateStuffOnRoadOrg();
            numberOrg--;
         }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag =="yellowballoon")
        {
            counterYellow++;
            Debug.Log(counterYellow);
        }
        if(other.tag =="orangeballoon")
        {
            counterOrange++;
            Debug.Log(counterOrange);
        }
    }
}
