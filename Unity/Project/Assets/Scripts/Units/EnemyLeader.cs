using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeader : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range;
    public float speed, castleDistance, minDistance;
    private Castle castle;
    private Transform castlePos;
    private Spawner spawner;

    void Start() {       

        HP = maxHP;
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
        spawner.GetComponent<Spawner>();
    }
    
    void Update() {
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
        if (castleDistance > minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        }        
        if (enemies < maxEnemies) {
            spawner.SpawnEnemy();
            enemies++;
            //Spawn();
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void Spawn() {
        //spawner.SpawnEnemy();
        //enemies++;
    }
}
