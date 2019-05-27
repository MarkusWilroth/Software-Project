using System.Collections;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public GameObject captain, warrior;
    public Transform[] spawnSpots;

    void Start() {
        Instantiate(captain, spawnSpots[0].position, Quaternion.identity);
        Instantiate(warrior, spawnSpots[0].position, Quaternion.identity);
    }
    
}
