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
    public bool activated;
    public Vector2 heroPos;
    public Vector3 target;
    public MovementState movementState;
    private HealthManager scriptHealth;
    private GetClosestEnemy scriptGetEnemy;
    private GameObject enemyO, spawnPoint, heroO;
    public GameObject hero;
    private Hero_Movement scriptHero;

    
    public float speed, maxDistance, minDistance, heroDistance;
    private Transform enemyPos;

    void Start() {
        scriptHero = hero.GetComponent<Hero_Movement>();
        scriptGetEnemy = gameObject.GetComponent<GetClosestEnemy>();
        scriptHealth = gameObject.GetComponent<HealthManager>();
        spawnPoint = GameObject.Find("CastleSpawn");

        movementState = MovementState.follow;
        attackRange = 4;
        //heroO = Hero.
    }

    void Update() {
        heroPos = scriptHero.heroPos;
        Debug.Log("Hero position: " + heroPos);

        if (scriptHero.movementState == Hero_Movement.MovementState.fighting) {
            movementState = MovementState.fighting;
        }
        if (scriptHero.movementState == Hero_Movement.MovementState.retreating) {
            movementState = MovementState.retreating;
        }
        if (scriptHero.movementState == Hero_Movement.MovementState.respawn) {
            movementState = MovementState.follow;
        }
        if (scriptHero.movementState == Hero_Movement.MovementState.dead) {
            movementState = MovementState.fighting;
        }

        enemyO = scriptGetEnemy.GetClosest();
        if (!(enemyO == null)) {
            distEnemy = Vector2.Distance(transform.position, enemyO.transform.position);
        }

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
    }

    void FollowHero() {
        heroDistance = Vector2.Distance(transform.position, hero.transform.position);
        //if (heroDistance > maxDistance) {
            target = hero.transform.position;
        //} 
        //else if (heroDistance < minDistance) {
        //    transform.position = Vector2.MoveTowards(transform.position, heroPos, -speed * Time.deltaTime);
        //}
    }
    void Fight() {
        if(distEnemy <= attackRange) {
            target = enemyO.transform.position;
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

        if (transform.position == target) {
            movementState = MovementState.follow;
        }

    }
}
