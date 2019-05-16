using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {
    public int maxHP = 200;
    public int HP = 0;
    public int armor = 10; //procent av skada som räknas bort (halverad effect för AP damage)
    public int damage = 0;
    public int range = 0;

    public bool towerUpgrade; //dessa kommer förmodligen att ändras beroende på vad tutorials visar
    public bool fireArrows;

    void Start() {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update() {
        if (HP <= 0) {
            GameOver();
        }
    }

    void GameOver () {
        //Avslutar spelet/leveln
    }

    public bool Repair() {
        //Ska gå att kommas åt från HUD, betalar man för repair ska
        if (maxHP < HP) { //Se till att om skada tas går den över till repair is done för att inte ha ett odödligt fort
            //Repairing
            return false;
        }
        else {
            //repair is done
            return true;
        }
        
    }

    public void takeDamage (int damage, bool AP) {
        if (AP) {
            damage -= (damage * (armor / 2));
        }
        else {
            damage -= damage * armor;
        }

        HP -= damage;
         
    }
}
