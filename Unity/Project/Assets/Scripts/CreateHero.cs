using System.Collections;
using UnityEngine;

public class CreateHero : MonoBehaviour
{
    public GameObject soldier, hero;
    public Transform[] spawnSpots;

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            //int randPos = Random.Range(0, spawnSpots.Length);
            //Instantiate(hero, spawnSpots[0].position, Quaternion.identity);
        }
    }
    public void Recruit() {
        Instantiate(soldier, spawnSpots[0].position, Quaternion.identity);
        Debug.Log("Success!!");
    }

    public void resHero() {
        int randPos = Random.Range(0, spawnSpots.Length);
        Instantiate(hero, spawnSpots[0].position, Quaternion.identity);
    }
}
