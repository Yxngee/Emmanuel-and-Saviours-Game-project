using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    private PlayerController pcScript;
    private float spawnRangeX = 13.0f;
    private float spawnPosZ = 14.0f;
    private float startDelay = 2.0f;
    private float repeatRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomEnemy", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn enemy as long game not over
    void SpawnRandomEnemy()
    {
        if (pcScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); ;

            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
        } 

    }
}
