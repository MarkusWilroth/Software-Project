using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range;
    public float speed, castleDistance, minDistance;
    public Transform enemyPos;
    private Castle castle;
    private Transform castlePos;

    void Start() {
        HP = maxHP;
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
    }
    
    void Update() {
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
        if (castleDistance > minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        }        
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
