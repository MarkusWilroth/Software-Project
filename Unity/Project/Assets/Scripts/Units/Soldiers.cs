using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public int weapon, soldierLvl, HP, maxHP, id, range;
    public float speed, maxDistance, minDistance, heroDistance, reload;
    bool retreat, inRange;
    private Transform heroPos, enemyPos;
    private Hero scriptWarrior, scriptRanger;
    public GameObject arrowProjectile;

    void Start()
    {        
        scriptWarrior = GameObject.FindGameObjectWithTag("WarriorHero").GetComponent<Hero>();
        scriptRanger = GameObject.FindGameObjectWithTag("RangeHero").GetComponent<Hero>();

        HP = maxHP;
        switch (id) {
            case 1:
                heroPos = GameObject.FindGameObjectWithTag("RangeHero").transform;
                enemyPos = GameObject.FindGameObjectWithTag("EnemyLeader").transform;
                break;
            case 2:
                heroPos = GameObject.FindGameObjectWithTag("WarriorHero").transform;
                break;
        }
        
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        ////soldierPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Vector2.Distance(transform.position, enemyPos.position) < range;
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        Movement();
        reload--;

        if(HP <= 0) {
            Destroy(gameObject);
        }

        switch (id) {
            case 1:
                if(scriptRanger.HP <= 0) {
                    scriptRanger.soldiers--;
                    Destroy(gameObject);                    
                }
                break;
            case 2:
                if (scriptWarrior.HP <= 0) {
                    scriptWarrior.soldiers--;
                    Destroy(gameObject);
                }
                break;
        }

        switch (id) {
            case 1:
                if(inRange && reload == 0) {
                    Instantiate(arrowProjectile, transform.position, Quaternion.identity);
                    reload = 60;
                }
                break;
            case 2:
                break;
        }
    }

    void Movement() {
            if (heroDistance > maxDistance) {
                transform.position = Vector2.MoveTowards(transform.position, heroPos.position, speed * Time.deltaTime);
            } else if (heroDistance < minDistance) {
                transform.position = Vector2.MoveTowards(transform.position, heroPos.position, -speed * Time.deltaTime);
            }        
    }
}
