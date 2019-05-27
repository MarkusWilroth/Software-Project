﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public int weapon, soldierLvl, HP, maxHP, id;
    public float speed, maxDistance, minDistance, heroDistance;
    bool retreat;
    private Transform heroPos;

    void Start()
    {
        HP = maxHP;
        switch (id) {
            case 1:
                heroPos = GameObject.FindGameObjectWithTag("RangerHero").transform;
                break;
            case 2:
                heroPos = GameObject.FindGameObjectWithTag("WarriorHero").transform;
                break;
        }
        Debug.Log(heroPos);
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        ////soldierPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        Movement();
    }

    void Movement() {
            if (heroDistance > maxDistance) {
                transform.position = Vector2.MoveTowards(transform.position, heroPos.position, speed * Time.deltaTime);
            } else if (heroDistance < minDistance) {
                transform.position = Vector2.MoveTowards(transform.position, heroPos.position, -speed * Time.deltaTime);
            }        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyLeader") || other.CompareTag("Enemy")) {
            HP--;
        }
    }
}
