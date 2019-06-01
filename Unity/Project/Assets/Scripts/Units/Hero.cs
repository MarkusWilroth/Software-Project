using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    //public enum states {
    //    attackEnemy,
    //    retreat
    //}  Inte säker på att vi ska använda states?

    public int maxHP, HP, armour, damage, soldiers, maxSoldiers, soldiersLvl, Exp, range, speed, id, respawnTimer, reload;
    public bool activated;
    private bool unlocks, traits, weapon, gatherTroops, inRange, move, alive;
    private Ray ray;
    private Vector2 vecPos;
    private Castle castle;
    private SoldierSpawn recruit;
    private EnemyLeader enemyLeader;
    private Camera cam;
    private Movement movement;
    private Transform heroPos, castlePos, enemyPos;
    public GameObject point, arrowProjectile, enemyO;
    GameObject[] enemysO;
    private Vector2 spawnPoint;

    void Start() {
        recruit = GetComponent<SoldierSpawn>();
        movement = GetComponent<Movement>();
        enemyLeader = GetComponent<EnemyLeader>();
        spawnPoint = new Vector2(-4, -3);
        gatherTroops = false;
        activated = false;
        alive = true;
        
        transform.position = spawnPoint;
    }

    void Update() {
        respawnTimer--;
        reload--;

        if (alive) {            
            if (soldiers < maxSoldiers) {
                Recruit();
            }
            if (HP <= 0) {
                alive = false;
                respawnTimer = 600;
                transform.position = spawnPoint;
            }
            if (activated) {
                if (Input.GetMouseButtonDown(0)) {
                    movement.ChangeTarget();
                }
            }
        }
    }

    public void TakeDamage(int damage) {
        HP -= damage;
    }
    public void MakeActive() {
        activated = true;
    }
    public void DeActivate() {
        activated = false;
    }

    void Recruit() { //Ska vi göra detta utan id tror jag det behöver vara soldier scriptet som kollar hur många soldater varje hero har och om det finns plats för fler soldater spawnar den den typ det plats för
        if (id == 1) {
            heroPos = GameObject.FindGameObjectWithTag("RangeHero").transform;
        } else {
            heroPos = GameObject.FindGameObjectWithTag("WarriorHero").transform;
        }
        vecPos = new Vector2(heroPos.position.x, heroPos.position.y);
        recruit.RecruitSoldier(id, vecPos);
        soldiers++;
    }

    void Respawn() {
        //recruit.resHero();
        alive = true;
        HP = maxHP;
    }
}
