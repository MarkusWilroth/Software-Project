using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeader : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range, outOfGame;
    public float speed, minDistance, attackDistance;
    public float warriorHeroDistance, rangeHeroDistance, castleDistance, soldierDistance, inRange, attackTimer;
    private Castle castle;
    private Hero scriptWarrior, scriptRanger;
    private Transform castlePos, warriorHeroPos, rangeHeroPos, soldierPos;
    private Spawner spawner;
    private Soldiers soldier;
    GameObject warriorO, ranger, tower, soldierO;
    private GameObject[] soldiersO;

    void Start() {
        HP = maxHP;
        outOfGame = 100000;
        castle = GetComponent<Castle>();
        spawner = GetComponent<Spawner>();

    }
    
    void Update() {
        Variables();
        attackTimer--;
        //scriptWarrior.TakeDamage(damage);
        

        if (rangeHeroDistance < attackDistance || warriorHeroDistance < attackDistance || soldierDistance < attackDistance) {
            if(rangeHeroDistance <= warriorHeroDistance && rangeHeroDistance <= soldierDistance) {
                AttackRangeEnemy();
            } else if (warriorHeroDistance <= soldierDistance){
                AttackWarriorEnemy();
            } 
            else {
                AttackSoldierEnemy();
            }
        } else {
            AttackCastle();
        }
        
        if (enemies < maxEnemies) {
            spawner.SpawnEnemy();
            //enemies++;
            Spawn();
        }
        if (HP <= 0) {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void Variables() {
        if (warriorHeroPos == null) {
            warriorHeroDistance = outOfGame;
        }
        if (rangeHeroPos == null) {
            rangeHeroDistance = outOfGame;
        }
        if (soldierPos == null) {
            soldierDistance = outOfGame;
        }

        soldierO = GetClosest();
        warriorHeroPos = GameObject.FindGameObjectWithTag("WarriorHero").transform;
        soldierPos = soldierO.transform;
        rangeHeroPos = GameObject.FindGameObjectWithTag("RangeHero").transform;
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
        soldierDistance = Vector2.Distance(transform.position, soldierPos.position);
        warriorHeroDistance = Vector2.Distance(transform.position, warriorHeroPos.position);
        rangeHeroDistance = Vector2.Distance(transform.position, rangeHeroPos.position);
        scriptWarrior = GameObject.FindGameObjectWithTag("WarriorHero").GetComponent<Hero>();
        scriptRanger = GameObject.FindGameObjectWithTag("RangeHero").GetComponent<Hero>();
        soldier = soldierO.GetComponent<Soldiers>();        
        
    }
    GameObject GetClosest() {
        soldiersO = GameObject.FindGameObjectsWithTag("Soldier");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        //Vector2 position = transform.position;
        foreach (GameObject go in soldiersO) {
            Vector2 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }

    #region Attack
    void AttackRangeEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, rangeHeroPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && rangeHeroDistance <= range) {
            scriptWarrior.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }

    void AttackWarriorEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, warriorHeroPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && warriorHeroDistance <= range) {
            scriptRanger.TakeDamage(damage);
            HP--;
            attackTimer = 60;
        }
    }

    void AttackSoldierEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, soldierPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && soldierDistance <= range) {
            soldier.HP -= damage;
            HP--;
            attackTimer = 60;
        }        
    }
    
    void AttackCastle() {
        transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && castleDistance <= range) {
            castle.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }
    #endregion
    void Spawn() {
        //spawner.SpawnEnemy();
        //enemies++;
    }
}
