using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private float spawnRangeZ = 20;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerController playerControllerScript;

    public GameObject powerupPrefab;
    private int powerupCount = 0;
    private float powerupSpawnDelay = 15;
    private float powerupSpawnInterval = 60f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, spawnInterval);                                                                                             //Continously Spawn Enemies
        InvokeRepeating("SpawnPowerup", powerupSpawnDelay, powerupSpawnInterval);                                                                                             //Continously Spawn Powerups

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();                                                                       //Get a reference to the playercontroller Script
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        if (playerControllerScript.gameOver == false)                                                                                                                //Stop spawning when Game is Over
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], new Vector3(45, 0, Random.Range(spawnRangeZ, -spawnRangeZ)), enemyPrefabs[enemyIndex].transform.rotation);        //Spawn a random Enemy from the array in a random z position
        }
    }

    void SpawnPowerup()                                                                                                                                              //Spawn the powerup in a random area on the map
    {
        float spawnPowerRangeX = 9;
        float spawnPowerRangeZ = 15;

        if (playerControllerScript.gameOver == false && powerupCount == 0)
        {
            Instantiate(powerupPrefab, new Vector3(Random.Range(-spawnPowerRangeX, spawnPowerRangeX), 0, Random.Range(spawnPowerRangeZ, -spawnPowerRangeZ)), powerupPrefab.transform.rotation);
        }

        powerupCount++;

    }
}
