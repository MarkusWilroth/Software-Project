using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public bool isRespawning;
    public bool isRanged;

    public float spawnTime;
    private float timeStamp;

    HealthManager scriptHealth;
    FireArrow scriptArrow;

    void Start() {
        scriptHealth = gameObject.GetComponent<HealthManager>();
        scriptArrow = gameObject.GetComponent<FireArrow>();
    }
    
    void Update() {
        if(isRespawning) {
            timeStamp += Time.deltaTime;
            scriptHealth.enabled = false;

            if(isRanged) {
                scriptArrow.enabled = false;
            }

            if(spawnTime <= timeStamp) {
                isRespawning = false;
                scriptHealth.enabled = true;

                if(isRanged) {
                    scriptArrow.enabled = true;
                }
            }

        }
    }
}
