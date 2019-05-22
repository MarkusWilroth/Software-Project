using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    //public enum states {
    //    attackEnemy,
    //    retreat
    //}  Inte säker på att vi ska använda states?

    public int maxHP, HP, armour, damage, soldiers, maxSoldiers, soldiersLvl, Exp, range;
    private bool unlocks, traits, weapon, gatherTroops, inRange;
    private Ray ray;    
    private Castle castle;
    private CreateHero createHero;
    private Enemy enemy;
    private Camera cam;
    public Transform heroPos;

    void Start() {
        createHero = GetComponent<CreateHero>();
        cam = new Camera();
        
        //Respawn();
        //castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    void Update() {
        if (soldiers < maxSoldiers) {
            Recruit();
        }
        if (HP <= 0) {
            Respawn();
        }
        if (gatherTroops) { //Kan vara ett bra sätt att samla sina heros och soldiers //Är detta meningen att det ska vara här man skapar sina soldater?
            heroPos = GameObject.FindGameObjectWithTag("Castle").transform;
        }
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
