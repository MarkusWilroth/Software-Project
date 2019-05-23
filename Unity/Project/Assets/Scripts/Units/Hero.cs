using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    //public enum states {
    //    attackEnemy,
    //    retreat
    //}  Inte säker på att vi ska använda states?

    public int maxHP, HP, armour, damage, soldiers, maxSoldiers, soldiersLvl, Exp, range, speed, id;
    private Vector3 taget;
    private bool unlocks, traits, weapon, gatherTroops, inRange, active;
    private Ray ray;    
    private Castle castle;
    private CreateHero createHero;
    private Enemy enemy;
    private Camera cam;
    private Movement movement;
    public Transform heroPos, castlePos;

    void Start() {
        createHero = GetComponent<CreateHero>();
        movement = GetComponent<Movement>();
        enemy = GetComponent<Enemy>();

        cam = new Camera();

        //Respawn();
        //castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    void Update() {
        //Debug.Log(active);
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
        if (HP <= 0) {
            Respawn();
        }
        
        if (gatherTroops && Vector2.Distance(transform.position, castlePos.position) > 2) { //Kan vara ett bra sätt att samla sina heros och soldiers //Är detta meningen att det ska vara här man skapar sina soldater?
            transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        }
    }

    void Recruit() {
        createHero.Recruit(id);
        soldiers++;
    }
    void Respawn() {
        createHero.resHero();
        HP = maxHP;
    }
}
