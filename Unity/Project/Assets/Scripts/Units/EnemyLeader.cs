﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeader : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range, outOfGame;
    public float speed, minDistance, attackDistance, waveTimer;
    public float warriorDist, rangeDist, castleDist, soldierDist, inRange, attackTimer;
    private bool alive, isAttacking;
    private Castle scriptCastle;
    private Hero scriptWarrior, scriptRanger;
    private Transform castlePos, warriorHeroPos, rangeHeroPos, soldierPos, targetPos;
    private Spawner spawner;
    private Soldiers scriptSoldier;
    private HealthManager scriptHP;
    private LevelScript scriptLvl;
    GameObject warriorO, rangerO, towerO, soldierO, castleO, spawnerO, lvlManagerO;
    private GameObject[] soldiersO;

    void Start() {
        HP = maxHP;
        outOfGame = 100000;
        soldierO = GetClosestSoldier();
        spawnerO = GameObject.FindGameObjectWithTag("enemySpawn");
        warriorO = GameObject.FindGameObjectWithTag("WarriorHero");
        rangerO = GameObject.FindGameObjectWithTag("RangeHero");
        castleO = GameObject.FindGameObjectWithTag("Castle");
        lvlManagerO = GameObject.FindGameObjectWithTag("lvlManager");
        isAttacking = false;
    }
    
    void Update() {
        Variables();
        attackTimer--;
        waveTimer++;
        if (waveTimer >= 120) {
            isAttacking = true;
        }
        if (enemies < maxEnemies) {
            spawner.SpawnEnemy(transform.position);
            enemies++;
            Spawn();
        }
        if (isAttacking) {
            GetClosestTarget();
        }

        if (HP <= 0) {
            spawner.activeLeader--;
            scriptLvl.gold += 10;
            scriptLvl.score += 5;
            Destroy(gameObject);
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void TakeDamage(int damage) {
        HP -= damage;
    }

    void Variables() {
        if (warriorHeroPos == null) {
            warriorDist = outOfGame;
        }
        if (rangeHeroPos == null) {
            rangeDist = outOfGame;
        }
        if (soldierPos == null) {
            soldierDist = outOfGame;
        }

        warriorHeroPos = warriorO.transform;
        soldierPos = soldierO.transform;
        rangeHeroPos = rangerO.transform;
        castlePos = castleO.transform;

        castleDist = Vector2.Distance(transform.position, castlePos.position);
        soldierDist = Vector2.Distance(transform.position, soldierPos.position);
        warriorDist = Vector2.Distance(transform.position, warriorHeroPos.position);
        rangeDist = Vector2.Distance(transform.position, rangeHeroPos.position);

        scriptWarrior = warriorO.GetComponent<Hero>();
        scriptRanger = rangerO.GetComponent<Hero>();
        scriptSoldier = soldierO.GetComponent<Soldiers>();
        scriptCastle = castleO.GetComponent<Castle>();
        scriptLvl = lvlManagerO.GetComponent<LevelScript>();
        spawner = spawnerO.GetComponent<Spawner>();
    }

    #region Target
    GameObject GetClosestSoldier() {
        soldiersO = GameObject.FindGameObjectsWithTag("Soldier");
        GameObject closest = null;
        float distance = Mathf.Infinity;

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

    void GetClosestTarget() {
        GameObject target = null;
        float dist;

        if(rangeDist < attackDistance || warriorDist < attackDistance || soldierDist < attackDistance) {
            if (rangeDist <= warriorDist && rangeDist <= soldierDist) {
                dist = rangeDist;
                target = rangerO;
                AttackHero(dist, scriptRanger);
            } 
            else if (warriorDist <= soldierDist) {
                dist = warriorDist;
                target = warriorO;
                AttackHero(dist, scriptWarrior);
            } 
            else {
                dist = soldierDist;
                target = soldierO;
                AttackSoldier(dist);
            }
        }
        else {
            dist = castleDist;
            target = castleO;
            AttackBuilding(dist, scriptCastle);
        }
        
        targetPos = target.transform;
        scriptHP = target.GetComponent<HealthManager>();
        TargetPos(targetPos);
    }
    #endregion

    #region Attack
    void TargetPos(Transform pos) {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
    }

    void AttackHero(float dist, Hero scriptHero) {
        if (attackTimer <= 0 && dist <= range) {
            scriptHero.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }
    void AttackSoldier(float dist) {
        if (attackTimer <= 0 && dist <= range) {
            scriptSoldier.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }
    void AttackBuilding(float dist, Castle scriptCastle) { //Tycker vi ändrar namnet på denna script till building och så tower = castle fast mindre hp och man förlorar inte om de går sönder
        if (attackTimer <= 0 && dist <= range) {
            scriptCastle.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Arrow")) {
            HP--;
            Destroy(other.gameObject);
        }
    }

    //void Attack(GameObject target, Transform pos, float dist, HealthManager scriptHP) {

    //    if (attackTimer <= 0 && dist <= range) {
    //        scriptHP.hp -= damage;
    //        HP--;
    //        attackTimer = 60;
    //    }
    //}

    //void AttackRangeEnemy() {
    //    if(attackTimer <= 0 && rangeDist <= range) {
    //        scriptRanger.HP -= damage;
    //        HP--;
    //        attackTimer = 60;
    //    }
    //}

    //void AttackWarriorEnemy() {
    //    transform.position = Vector2.MoveTowards(transform.position, warriorHeroPos.position, speed * Time.deltaTime);
    //    if(attackTimer <= 0 && warriorDist <= range) {
    //        scriptWarrior.HP -= damage;
    //        HP--;
    //        attackTimer = 60;
    //    }
    //}

    //void AttackSoldierEnemy() {
    //    transform.position = Vector2.MoveTowards(transform.position, soldierPos.position, speed * Time.deltaTime);
    //    if(attackTimer <= 0 && soldierDist <= range) {
    //        scriptSoldier.HP -= damage;
    //        HP--;
    //        attackTimer = 60;
    //    }        
    //}

    //void AttackCastle() {
    //    transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
    //    if(attackTimer <= 0 && castleDist <= range) {
    //        scriptCastle.HP -= damage;
    //        HP--;
    //        attackTimer = 60;
    //    }
    //}
    #endregion

    void Spawn() {
        //spawner.SpawnEnemy();
        //enemies++;
    }
}
