using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public bool isRespawning, isHero;
    public bool isRanged;

    public float spawnTime;
    private float timeStamp;

    HealthManager scriptHealth;
    Hero_Movement scriptHeroMovement;
    SoldierMovement scriptSoldierMovement;
    FireArrow scriptArrow;

    void Start() {
        scriptHealth = gameObject.GetComponent<HealthManager>();
        scriptArrow = gameObject.GetComponent<FireArrow>();
        if(isHero) {
            scriptHeroMovement = gameObject.GetComponent<Hero_Movement>();
        }
        else {
            scriptSoldierMovement = gameObject.GetComponent<SoldierMovement>();
        }
        
    }
    
    void Update() {
        if(isRespawning) {
            if(isHero) {
                scriptHeroMovement.movementState = Hero_Movement.MovementState.dead;
            }
            else {
                scriptSoldierMovement.movementState = SoldierMovement.MovementState.dead;
            }
            
            timeStamp += Time.deltaTime;

            if(isRanged) {
                scriptArrow.enabled = false;
            }

            if(spawnTime <= timeStamp) {
                if (isHero) {
                    scriptHeroMovement.movementState = Hero_Movement.MovementState.respawn;
                } else {
                    scriptSoldierMovement.movementState = SoldierMovement.MovementState.respawn;
                }
                isRespawning = false;
                timeStamp = 0;

                if(isRanged) {
                    scriptArrow.enabled = true;
                }
            }

        }
    }
}
