using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public bool isRespawning;
    public bool isRanged;

    public float spawnTime;
    private float timeStamp;

    HealthManager scriptHealth;
    Hero_Movement scriptMovement;
    FireArrow scriptArrow;

    void Start() {
        scriptHealth = gameObject.GetComponent<HealthManager>();
        scriptArrow = gameObject.GetComponent<FireArrow>();
        scriptMovement = gameObject.GetComponent<Hero_Movement>();
    }
    
    void Update() {
        if(isRespawning) {
            scriptMovement.movementState = Hero_Movement.MovementState.dead;
            timeStamp += Time.deltaTime;

            if(isRanged) {
                scriptArrow.enabled = false;
            }

            if(spawnTime <= timeStamp) {
                scriptMovement.movementState = Hero_Movement.MovementState.respawn;
                isRespawning = false;
                timeStamp = 0;

                if(isRanged) {
                    scriptArrow.enabled = true;
                }
            }

        }
    }
}
