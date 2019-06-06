using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;

public class SoldierMovement : MonoBehaviour {
    public enum MovementState {
        follow,
        fighting,
        retreating,
        dead,
        respawn,
    }
    private float distEnemy, attackRange;
    public int unitType;
    public bool activated;
    public Transform heroPos;
    public Vector3 target;
    public MovementState movementState;
    private HealthManager scriptHealth;
    private GetClosestEnemy scriptGetEnemy;
    private GameObject enemyO, spawnPoint, heroO;
    private GameObject hero;
    private Hero_Movement scriptHero;

    
    public float speed, maxDistance, minDistance, heroDistance;
    private Transform enemyPos;

    void Start() {
        
        scriptGetEnemy = gameObject.GetComponent<GetClosestEnemy>();
        scriptHealth = gameObject.GetComponent<HealthManager>();
        spawnPoint = GameObject.Find("CastleSpawn");

        movementState = MovementState.follow;
        attackRange = 4;

        switch (unitType) {
            case 1:
                hero = GameObject.FindGameObjectWithTag("RangeHero");
                heroPos = hero.transform;
                scriptHero = hero.GetComponent<Hero_Movement>();
                break;
            case 2:
                hero = GameObject.FindGameObjectWithTag("WarriorHero");
                heroPos = hero.transform;
                scriptHero = hero.GetComponent<Hero_Movement>();
                break;
        }
        //heroO = Hero.
    }

    void Update() {

        if (scriptHero.movementState == Hero_Movement.MovementState.idle) {
            movementState = MovementState.follow;
        } else if (scriptHero.movementState == Hero_Movement.MovementState.fighting) {
            movementState = MovementState.fighting;
        } else if (scriptHero.movementState == Hero_Movement.MovementState.retreating) {
            movementState = MovementState.retreating;
        } else if (scriptHero.movementState == Hero_Movement.MovementState.respawn) {
            movementState = MovementState.follow;
        } else if (scriptHero.movementState == Hero_Movement.MovementState.dead) {
            movementState = MovementState.fighting;
        }

        enemyO = scriptGetEnemy.GetClosest();
        if (!(enemyO == null)) {
            distEnemy = Vector2.Distance(transform.position, enemyO.transform.position);
        }

        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        switch (movementState) {
            case MovementState.follow:
                FollowHero();
                break;
            case MovementState.fighting:
                Fight();
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
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void FollowHero() {
        if (heroDistance > maxDistance) {
            target = heroPos.position;
        } 
        else {
            target = transform.position;
        }
    }

    void Fight() {
        if(distEnemy <= attackRange) {
            target = enemyO.transform.position;
        }
        else {
            target = transform.position;
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
    }

    void Respawn() {
        target = spawnPoint.transform.position;

        if (transform.position == target && !(scriptHero.movementState == Hero_Movement.MovementState.dead)) {
            movementState = MovementState.follow;
        }

    }
}
