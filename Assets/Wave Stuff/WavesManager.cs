using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour {

    public int currentWave;

    public List<GameObject> spawnPoints = new List<GameObject>();

    public GameObject[] enemies;

    public float minTimeBetweenSpawn, maxTimeBetweenSpawn, spawnTempTimer, timeBetweenWaves, tempTimeBetweenWaves, totalEnemiesThisWave, enemiesSpawned;

    public bool allEnemiesSpawned;

	// Use this for initialization
	void Start () {
        currentWave = 0;
        totalEnemiesThisWave = calculateNumberOfEnemies();
	}
	
	// Update is called once per frame
	void Update () {

        if(enemiesSpawned < totalEnemiesThisWave) //if enemies spawned is LESS THAN total enemies this round
        {
            GameObject enemyToSpawn = enemies[Random.Range(0, 2)];
            var randPick = Random.Range(0, 4);
            print("random spawn point is " + randPick);
            GameObject locationToSpawn = spawnPoints[randPick];
            if(Time.time > spawnTempTimer)
            {
                spawnTempTimer = Time.time + Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
                Instantiate(enemyToSpawn, locationToSpawn.transform);
                enemiesSpawned++;
            }

        }
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) //if you've spawned enough enemies
        {
            tempTimeBetweenWaves += Time.deltaTime;  //timer to wait till next round

            if (tempTimeBetweenWaves >= timeBetweenWaves) //if timer is donw, reset it and start next wave
            {
                currentWave++;
                tempTimeBetweenWaves = 0;
                enemiesSpawned = 0;
                totalEnemiesThisWave = calculateNumberOfEnemies();
            }
        }

		
	}

    int calculateNumberOfEnemies()
    {
        return currentWave * 1;
    }
}
