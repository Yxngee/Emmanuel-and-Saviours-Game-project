using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefab;

    private PlayerController pcScript;
    private float spawnRangeX = 13.0f;
    private float spawnPosZ = 14.0f;
    private float startDelay = 2.0f;
    private float repeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
       InvokeRepeating("SpawnRandomFood", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // spawn food as long as game not over
    void SpawnRandomFood()
    {
        if (pcScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2, spawnPosZ); ;

            int foodIndex = Random.Range(0, foodPrefab.Length);
            Instantiate(foodPrefab[foodIndex], spawnPos, foodPrefab[foodIndex].transform.rotation );
        }

    }
    
}