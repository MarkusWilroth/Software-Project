using System.Collections;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public GameObject soldier, hero;
    public Transform[] spawnSpots;

    void Start(int id) {
        Instantiate(hero, spawnSpots[1].position, Quaternion.identity);
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            //int randPos = Random.Range(0, spawnSpots.Length);
            //Instantiate(hero, spawnSpots[0].position, Quaternion.identity);
        }
    }
    public void RecruitSoldier(int id) {
        int randPos = Random.Range(0, spawnSpots.Length);
        Instantiate(soldier, spawnSpots[randPos].position, Quaternion.identity);
        Debug.Log("Success!!");
    }

    public void Die() {
        
    }

    public void resHero() {        
        Instantiate(hero, spawnSpots[0].position, Quaternion.identity);
    }
}
