using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawn : MonoBehaviour {
    public GameObject ranger, swordsman;
    public Transform spawnSpots;

    public void RecruitSoldier(int id, Vector2 heroPos) {
        Debug.Log("Spawned: " + id);
        switch (id) {
            case 1:
                Instantiate(ranger, heroPos, Quaternion.identity);
                break;
            case 2:
                Instantiate(swordsman, heroPos, Quaternion.identity);
                break;
        }
        Debug.Log("HeroPos: " + heroPos);
    }
}
