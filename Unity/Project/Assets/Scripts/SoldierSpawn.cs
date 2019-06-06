using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawn : MonoBehaviour {
    public GameObject soldier;
    private GameObject soldierO, spawnPoint;
    public int maxSoldiers, soldiers;
    Hero_Movement scriptHeroPos;
    private Vector2 heroPos;

    void Start() {
        spawnPoint = GameObject.Find("CastleSpawn");
    }

    void Update() {
        if(soldiers <= maxSoldiers) {
            soldierO = Instantiate(soldier, spawnPoint.transform.position, Quaternion.identity);
            soldiers++;
        }
    }

    public void RecruitSoldier(int id, Vector2 heroPos) {
        
    }
}
