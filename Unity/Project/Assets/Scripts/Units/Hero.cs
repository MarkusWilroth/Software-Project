using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    //public enum states {
    //    attackEnemy,
    //    retreat
    //}  Inte säker på att vi ska använda states?

    public int maxHP, HP, armour, damage, soldiers, maxSoldiers, soldiersLvl, Exp, range, speed, id, respawnTimer;
    private bool unlocks, traits, weapon, gatherTroops, inRange, active, move, alive;
    private Ray ray;
    private Vector2 vecPos;
    private Castle castle;
    private SoldierSpawn recruit;
    private EnemyLeader enemyLeader;
    private Camera cam;
    private Movement movement;
    private Transform heroPos, castlePos;
    public GameObject point;

    void Start() {
        recruit = GetComponent<SoldierSpawn>();
        movement = GetComponent<Movement>();
        enemyLeader = GetComponent<EnemyLeader>();
        gatherTroops = false;
        alive = true;

        cam = new Camera();


        //Respawn();
        //castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    void Update() {
        //Debug.Log(active);
        respawnTimer--;
        if (!active && Input.GetKeyDown(id.ToString())) {
            active = true; //endast när heron är aktiv kan han få en punkt att gå till, han ska fortfarande kunna gå
        }
        if (active) {
            if (Input.GetKeyDown("space")) {
                active = false;
            }

            if (Input.GetMouseButtonDown(0)) {
                movement.ChangeTarget();
            }
        }

        if (soldiers < maxSoldiers) {
            Recruit();
        }
        if (HP <= 0 && alive) {
            alive = false;
            respawnTimer = 600;
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
        if (!(alive) && respawnTimer <= 0) {
            Respawn();
        }
        //Debug.Log("Hero HP: " + HP + "Hero ID: "+id);

        if (gatherTroops && Vector2.Distance(transform.position, castlePos.position) > 2) { //Kan vara ett bra sätt att samla sina heros och soldiers //Är detta meningen att det ska vara här man skapar sina soldater?
            //transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        }
        vecPos = new Vector2(heroPos.position.x, heroPos.position.y);
    }
    public void TakeDamage(int damage) {
        HP -= damage;
        Debug.Log("Damage taken! HP: "+HP);
    }

    void Recruit() {
        recruit.RecruitSoldier(id, vecPos);
        soldiers++;
    }
    void Respawn() {
        //recruit.resHero();
        alive = true;
        HP = maxHP;
    }
}
