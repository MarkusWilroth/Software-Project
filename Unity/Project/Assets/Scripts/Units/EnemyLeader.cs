using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeader : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range, outOfGame;
    public float speed, minDistance, attackDistance;
    public float warriorDist, rangeDist, castleDist, soldierDist, inRange, attackTimer;
    private Castle scriptCastle;
    private Hero scriptWarrior, scriptRanger;
    private Transform castlePos, warriorHeroPos, rangeHeroPos, soldierPos, targetPos;
    private Spawner spawner;
    private Soldiers scriptSoldier;
    private HealthManager scriptHP;
    GameObject warriorO, rangerO, towerO, soldierO, castleO;
    private GameObject[] soldiersO;

    void Start() {
        HP = maxHP;
        outOfGame = 100000;
        
        spawner = GetComponent<Spawner>();

    }
    
    void Update() {
        Variables();
        attackTimer--;
        //scriptWarrior.TakeDamage(damage);

        GetClosestTarget();
        
        if (enemies < maxEnemies) {
            spawner.SpawnEnemy();
            //enemies++;
            Spawn();
        }
        if (HP <= 0) {
            //Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
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

        soldierO = GetClosestSoldier();
        warriorO = GameObject.FindGameObjectWithTag("WarriorHero");
        rangerO = GameObject.FindGameObjectWithTag("RangeHero");
        castleO = GameObject.FindGameObjectWithTag("Castle");

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
    }

    GameObject GetClosestSoldier() {
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
    void GetClosestTarget() {
        GameObject target = null;
        float dist;

        if (rangeDist <= warriorDist && rangeDist <= soldierDist) {
            dist = rangeDist;
            target = rangerO;
        } 
        else if (warriorDist <= soldierDist) {
            dist = warriorDist;
            target = warriorO;
        } 
        else {
            dist = soldierDist;
            target = soldierO;
        }
        if (dist > attackDistance) {
            dist = castleDist;
            target = castleO;
        }
        
        targetPos = target.transform;
        scriptHP = target.GetComponent<HealthManager>();
        Attack(target, targetPos, dist, scriptHP);
    }

    #region Attack

    void Attack(GameObject target, Transform pos, float dist, HealthManager scriptHP) {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
        if (attackTimer <= 0 && dist <= range) {
            scriptHP.hp -= damage;
            HP--;
            attackTimer = 60;
        }
    }

    void AttackRangeEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, rangeHeroPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && rangeDist <= range) {
            scriptRanger.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }

    void AttackWarriorEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, warriorHeroPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && warriorDist <= range) {
            scriptWarrior.HP -= damage;
            HP--;
            attackTimer = 60;
        }
    }

    void AttackSoldierEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, soldierPos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && soldierDist <= range) {
            scriptSoldier.HP -= damage;
            HP--;
            attackTimer = 60;
        }        
    }
    
    void AttackCastle() {
        transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        if(attackTimer <= 0 && castleDist <= range) {
            scriptCastle.HP -= damage;
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
