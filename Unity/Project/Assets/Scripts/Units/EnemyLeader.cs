using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeader : MonoBehaviour {

    public int maxHP, HP, armour, damage, maxEnemies, enemies, enemiesLvl, range;
    public float speed, minDistance, attackDistance;
    private float warriorHeroDistance, rangeHeroDistance, castleDistance, inRange, attackTimer;
    private Castle castle;
    private Hero scriptWarrior, hero;
    private Transform castlePos, warriorHeroPos, soldierPos, rangeHeroPos;
    private Spawner spawner;
    GameObject warriorO, ranger, tower;

    void Start() {
        HP = maxHP;
        
        castle = GetComponent<Castle>();
        spawner = GetComponent<Spawner>();
        //warriorO = GameObject.FindGameObjectWithTag("WarriorHero");
        //warriorHeroPos = warriorO.transform;
        //warriorO.GetComponent<Hero>().TakeDamage(damage);

    }
    
    void Update() {
        //transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
        Variables();
        attackTimer--;
        //scriptWarrior.TakeDamage(damage);

        if(rangeHeroDistance < attackDistance) {
            AttackRangeEnemy();
        } else if (warriorHeroDistance < attackDistance) {
            AttackWarriorEnemy();        
        } else {
            AttackCastle();
        }
        
        if (enemies < maxEnemies) {
            spawner.SpawnEnemy();
            //enemies++;
            Spawn();
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void Variables() {
        warriorHeroPos = GameObject.FindGameObjectWithTag("WarriorHero").transform;
        rangeHeroPos = GameObject.FindGameObjectWithTag("RangeHero").transform;
        soldierPos = GameObject.FindGameObjectWithTag("Soldier").transform;
        castlePos = GameObject.FindGameObjectWithTag("Castle").transform;
        castleDistance = Vector2.Distance(transform.position, castlePos.position);
        warriorHeroDistance = Vector2.Distance(transform.position, warriorHeroPos.position);
        rangeHeroDistance = Vector2.Distance(transform.position, rangeHeroPos.position);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("WarriorHero") && attackTimer <= 0) {
            scriptWarrior.HP -= damage;
            HP--;
            if(HP <= 0) {
                Destroy(gameObject);
            }
            attackTimer = 60;
        }
        if (other.CompareTag("RangeHero") && attackTimer <= 0) {
            scriptWarrior.HP -= damage;
            HP--;
            if (HP <= 0) {
                Destroy(gameObject);
            }
            attackTimer = 60;
        }
        if (other.CompareTag("Castle") && attackTimer <= 0) {
            castle.HP -= damage;
            HP--;
            if (HP <= 0) {
                Destroy(gameObject);
            }
            attackTimer = 60;
        }
    }

    void AttackRangeEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, rangeHeroPos.position, speed * Time.deltaTime);
    }

    void AttackWarriorEnemy() {
        transform.position = Vector2.MoveTowards(transform.position, warriorHeroPos.position, speed * Time.deltaTime);
    }

    void AttackCastle() {
        transform.position = Vector2.MoveTowards(transform.position, castlePos.position, speed * Time.deltaTime);
    }

    void Spawn() {
        //spawner.SpawnEnemy();
        //enemies++;
    }
}
