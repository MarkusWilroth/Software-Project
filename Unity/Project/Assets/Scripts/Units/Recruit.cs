using System.Collections;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public GameObject ranger, swordsman, captain, warrior;
    public Transform[] spawnSpots;

    void Start(int id) {
        Instantiate(captain, spawnSpots[0].position, Quaternion.identity);
        Instantiate(warrior, spawnSpots[0].position, Quaternion.identity);
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            //int randPos = Random.Range(0, spawnSpots.Length);
            //Instantiate(hero, spawnSpots[0].position, Quaternion.identity);
        }
    }
    public void RecruitSoldier(int id) {
        int randPos = Random.Range(0, spawnSpots.Length);
        Instantiate(swordsman, spawnSpots[randPos].position, Quaternion.identity);
        Instantiate(ranger, spawnSpots[randPos].position, Quaternion.identity);
    }

    public void Die() {
        
    }

    public void resHero() {
        Instantiate(captain, spawnSpots[0].position, Quaternion.identity);
        Instantiate(warrior, spawnSpots[0].position, Quaternion.identity);
    }
}
