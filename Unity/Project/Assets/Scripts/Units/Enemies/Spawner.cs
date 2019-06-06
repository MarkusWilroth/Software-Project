using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
    public GameObject enemyLeader, enemy;
    private GameObject enemyLeaderO, enemyO;
    public Transform[] spawnSpots;
    public int activeLeader, spawnLeaders, goldGained;
    private int waveCounter;
    private Transform enemyPos;
    private float timeStamp;
    public float waveTimer;
    private bool isSpawning;
    private string txtWave;
    public Text waveInfo;
    private LevelScript scriptLevel;

    void Start() {
        isSpawning = true;
        scriptLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>();
    }

    void Update() {
        timeStamp += Time.deltaTime;

        if(waveTimer <= timeStamp) {
            StartWave();
        }

        if(isSpawning) {
            Spawning();
        }
        waveInfo.text = "Next wave: "+((int)(waveTimer-timeStamp))+"\nEnemies: " + activeLeader;
        
    }
    public void Spawning() {
        if (activeLeader < spawnLeaders) {
            activeLeader++;
            int randPos = Random.Range(0, spawnSpots.Length);
            enemyLeaderO = Instantiate(enemyLeader, spawnSpots[randPos].position, Quaternion.identity) as GameObject;
            enemyLeaderO.transform.parent = GameObject.Find("Spawner").transform;
        }
        else {
            isSpawning = false;
        }
    }

    public void StartWave() {
        waveCounter++;
        goldGained = (int)(waveTimer - timeStamp);
        scriptLevel.gold += goldGained;
        scriptLevel.Generate(waveCounter);
        timeStamp = 0;
        waveTimer += 2;
        spawnLeaders += 2;
        activeLeader = 0;
        isSpawning = true;
    }

    public void SpawnEnemy(Vector2 enemyPos) {
        enemyO = Instantiate(enemy, enemyPos, Quaternion.identity) as GameObject;
        enemyO.transform.parent = GameObject.Find("Spawner").transform;
    }
}
