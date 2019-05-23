using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public int weapon, soldierLvl, HP, maxHP;
    public float speed, maxDistance, minDistance, heroDistance;
    bool retreat;
    private Transform heroPos;
    private CreateHero createHero;

    void Start()
    {
        HP = maxHP;
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform;
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        ////soldierPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        Movement();
        if(HP <= 0) {
            createHero.Die();
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
