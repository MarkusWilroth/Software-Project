using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemyLeader, enemy;
    private GameObject enemyLeaderO, enemyO;
    public Transform[] spawnSpots;
    public int activeLeader, maxLeader;
    private Transform enemyPos;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    private bool isSpawning;

    void Start() {
        timeBtwSpawns = startTimeBtwSpawns;
        isSpawning = true;
    }

    void Update() {
        if (activeLeader < maxLeader && isSpawning) {
            activeLeader++;
            int randPos = Random.Range(0, spawnSpots.Length);
            enemyLeaderO = Instantiate(enemyLeader, spawnSpots[randPos].position, Quaternion.identity) as GameObject;
            enemyLeaderO.transform.parent = GameObject.Find("Spawner").transform;
        } 

        if(activeLeader == maxLeader) {
            isSpawning = false;
        }
        if(activeLeader <= 0) {
            isSpawning = true;
            maxLeader++;
        }
    }

    public void SpawnEnemy(Vector2 enemyPos) {
        enemyO = Instantiate(enemy, enemyPos, Quaternion.identity) as GameObject;
        enemyO.transform.parent = GameObject.Find("Spawner").transform;
    }
}
