using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public int weapon, soldierLvl, HP, maxHP, id;
    public float speed, maxDistance, minDistance, heroDistance;
    bool retreat;
    private Transform heroPos;
    private Hero scriptWarrior, scriptRanger;

    void Start()
    {
        scriptWarrior = GameObject.FindGameObjectWithTag("WarriorHero").GetComponent<Hero>();
        scriptRanger = GameObject.FindGameObjectWithTag("RangeHero").GetComponent<Hero>();

        HP = maxHP;
        switch (id) {
            case 1:
                heroPos = GameObject.FindGameObjectWithTag("RangeHero").transform;
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
        heroDistance = Vector2.Distance(transform.position, heroPos.position);
        Movement();

        if(HP <= 0) {
            Destroy(gameObject);
        }

        switch (id) {
            case 1:
                if(scriptRanger.HP <= 0) {
                    scriptRanger.soldiers--;
                    Debug.Log("Soldiers: " + scriptRanger.soldiers);
                    Destroy(gameObject);                    
                }
                break;
            case 2:
                if (scriptWarrior.HP <= 0) {
                    scriptWarrior.soldiers--;
                    Debug.Log("Soldiers: " + scriptWarrior.soldiers);
                    Destroy(gameObject);
                }
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
