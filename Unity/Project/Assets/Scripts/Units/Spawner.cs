using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemyLeader, enemy;
    public Transform[] spawnSpots;
    private Transform enemyPos;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    void Start() {
        timeBtwSpawns = startTimeBtwSpawns;
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update() {        
        if (timeBtwSpawns <= 0) {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemyLeader, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        } else {
            timeBtwSpawns -= Time.deltaTime;
        }
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    
    public void SpawnEnemy() {
        Instantiate(enemy, enemyPos.position, Quaternion.identity);
    }
}
