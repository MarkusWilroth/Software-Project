using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range;
    public float speed = 10f;
    public Transform enemyPos;

    void Start() {
        HP = maxHP;
        //pos = map.SpawnPoint;
    }
    
    void Update() {
        if (enemies < maxEnemies) {
            Recruit();
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void Recruit() {
        //Skapar en ny fiende o ger dess stats beroende på vilka stats den kan ha
        enemies++;
    }
}
