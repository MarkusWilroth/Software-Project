using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Movement : MonoBehaviour {

    public enum MovementState {
        idle,
        fighting,
        retreating,
        dead,
        respawn,
    }
    public float speed;
    private float distEnemy, attackRange;
    public bool activated;
    public Vector2 heroPos;
    public Vector3 target;
    public MovementState movementState;
    private HealthManager scriptHealth;
    private GetClosestEnemy scriptGetEnemy;
    private GameObject enemyO, spawnPoint;

    void Start() {
        movementState = MovementState.idle;
        scriptGetEnemy = gameObject.GetComponent<GetClosestEnemy>();
        scriptHealth = gameObject.GetComponent<HealthManager>();
        spawnPoint = GameObject.Find("CastleSpawn");

        activated = false;
        attackRange = 2;
    }

    void Update() {
        heroPos = transform.position;
        enemyO = scriptGetEnemy.GetClosest();
        if(!(enemyO == null)) {
            distEnemy = Vector2.Distance(transform.position, enemyO.transform.position);
        }
        else {
            distEnemy = 1000;
        }
        

        switch (movementState) {
            case MovementState.idle:
                target = MovingToTarget();
                break;

            case MovementState.fighting:
                InCombat();
                break;
                
            case MovementState.retreating:
                FallBack();
                break;

            case MovementState.dead:
                target = new Vector3(0, 0, 0);
                transform.position = target;
                break;

            case MovementState.respawn:
                Respawn();
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    Vector3 MovingToTarget() {
        if(Input.GetMouseButtonDown(1) && activated) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        if (distEnemy <= attackRange) {
            movementState = MovementState.fighting;
        }
        return target;
    }

    void InCombat() {
        target = enemyO.transform.position;

        if (Input.GetKeyDown("space") && activated) {
            movementState = MovementState.retreating;
        }
        if(distEnemy >= attackRange) {
            target = transform.position;
            movementState = MovementState.idle;
        }
    }

    void FallBack() {
        enemyO = scriptGetEnemy.GetClosest();
        distEnemy = Vector2.Distance(transform.position, enemyO.transform.position);

        if (distEnemy <= attackRange) {
            //Förlorar hp
        }
        //Ska inte kunna göra skada eller skjuta
        target = spawnPoint.transform.position;

        if(transform.position == target) {
            movementState = MovementState.idle;
        }
    }

    void Respawn() {
        target = spawnPoint.transform.position;
        //transform.position = target;
        if(transform.position == target) {
            movementState = MovementState.idle;
        }
        
    }

    public void MakeActive() {
        activated = true;
    }

    public void DeActivate() {
        activated = false;
    }
}
