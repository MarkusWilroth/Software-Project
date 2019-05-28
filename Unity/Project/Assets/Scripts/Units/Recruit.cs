using System.Collections;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public GameObject captain, captainO, warrior, warriorO;
    public Transform[] spawnSpots;

    void Start() {
        captainO = Instantiate(captain, spawnSpots[0].position, Quaternion.identity) as GameObject;
        warriorO = Instantiate(warrior, spawnSpots[0].position, Quaternion.identity) as GameObject;
        captainO.transform.parent = GameObject.Find("HeroManager").transform;
        warriorO.transform.parent = GameObject.Find("HeroManager").transform;
        // Instantiate(captain, spawnSpots[0].position, Quaternion.identity);
        //Instantiate(warrior, spawnSpots[0].position, Quaternion.identity);
    }
}
