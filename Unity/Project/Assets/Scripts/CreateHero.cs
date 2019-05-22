using System.Collections;
using UnityEngine;

public class CreateHero : MonoBehaviour
{
    public GameObject hero;
    public Transform[] spawnSpots;

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(hero, spawnSpots[randPos].position, Quaternion.identity);
        }
    }
}
