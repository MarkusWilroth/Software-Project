using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour { //Planen är att detta script ska hålla koll på allas HP och när någons hp är 0 ska denna script skicka till den andras hero/soldier/castle script att den är död
    public int hp, maxHP;

    void Update() {
        if(hp <= 0) {
            Respawn();
        }
    }

    public void Respawn() { //Hero classen som dör skickar hit till HealthManager när det är dags att respawna
        hp = maxHP; //Ska också flyttas och inte kunna ta/göra damage under en viss tid
        gameObject.GetComponent<Respawn>().isRespawning = true;
        
    }
}
