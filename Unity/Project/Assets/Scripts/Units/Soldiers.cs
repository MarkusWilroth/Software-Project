using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    private int weapon, soldierLvl, HP, maxHP;
    private float speed;
    bool retreat;
    private Hero hero;
    private Transform soldierPos;

    void Start()
    {
        HP = maxHP;
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        ////soldierPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        soldierPos = GameObject.FindGameObjectWithTag("Hero").transform;
    }
}
