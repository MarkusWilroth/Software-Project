using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour { //Planen är att detta script ska hålla koll på allas HP och när någons hp är 0 ska denna script skicka till den andras hero/soldier/castle script att den är död
    public int hp, maxHP;
    public GameObject prefab;

    void Update() {
        if(hp <= 0) {
            Debug.Log("He is taking damage!!!!");
        }
    }

    public void Respawn() { //Hero classen som dör skickar hit till HealthManager när det är dags att respawna
        hp = maxHP;
        
    }
}
/*
 * Anledningen till att jag ville ha dett för att det ska bli snyggare i enemyLeader scriptet... om detta fungerar borde raderna 122 - 129 kunna ersätta alla attack funktioner i enemyLeader
 * fick problem då alla script kom från olika saker kan inte göra en scriptTarget = targetO.GetComponent<Hero>(); för soldier och castle har inte scriptet hero
 * så om detta fungerar hoppas jag att det kan bli scriptTarget = targetO.GetComponent<HealthManager>();
 * Har du en annan lösning är det bara att säga till eller om du tycker att vi ska ha alla attackfunktioner är det bara att ta bort denna.... tror dock att detta är något som är möjligt och skulle se
 * till att vi inte har en funktion för varje typ av sak som torn, resourceBuilding etc etc
*/
