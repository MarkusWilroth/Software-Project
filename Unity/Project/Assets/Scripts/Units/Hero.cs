using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    //public enum states {
    //    attackEnemy,
    //    retreat
    //}  Inte säker på att vi ska använda states?

    public int maxHP, HP, armour, damage, soldiers, maxSoldiers, soldiersLvl, Exp, range, speed;
    private bool unlocks, traits, weapon, gatherTroops, inRange;
    private Ray ray;    
    private Castle castle;
    private CreateHero createHero;
    private Enemy enemy;
    private Camera cam;
    public Transform heroPos, castlePos;

    void Start() {
        createHero = GetComponent<CreateHero>();
        cam = new Camera();

        //Respawn();
        //castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    void Update() {        
        if (soldiers < maxSoldiers) {
            Recruit();
        }
        if (HP <= 0) {
            Respawn();
        }
        //if (input.getbuttondown("space")) {
            //    gatherTroops = true;
            //}
            //if (gatherTroops && Vector2.Distance(transform.position, castlePos.position) > 2) { //Kan vara ett bra sätt att samla sina heros och soldiers //Är detta meningen att det ska vara här man skapar sina soldater?
            //    transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
            //}
        }

    void Recruit() {
        createHero.Recruit();
        soldiers++;
    }
    void Respawn() {
        createHero.resHero();
        HP = maxHP;
        Start();
    }
}
