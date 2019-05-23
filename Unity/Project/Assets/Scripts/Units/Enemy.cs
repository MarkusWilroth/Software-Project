using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int weapon, soldierLvl, HP, maxHP;
    public float speed, maxDistance, minDistance, EnemyDistance;
    bool retreat;
    private Transform enemyLeaderPos;
    void Start()
    {
        HP = maxHP;
        enemyLeaderPos = GameObject.FindGameObjectWithTag("EnemyLeader").transform;
        EnemyDistance = Vector2.Distance(transform.position, enemyLeaderPos.position);
    }

    void Update()
    {
        EnemyDistance = Vector2.Distance(transform.position, enemyLeaderPos.position);
        Movement();
    }

    void Movement() {
        if (EnemyDistance > maxDistance) {
            transform.position = Vector2.MoveTowards(transform.position, enemyLeaderPos.position, speed * Time.deltaTime);
        } else if (EnemyDistance < minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, enemyLeaderPos.position, -speed * Time.deltaTime);
        }
    }
}
