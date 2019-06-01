using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour {
    public GameObject arrow;
    private GameObject arrowO;
    private ArrowProjectile scriptArrow;
    public float scale, reloadTime;
    public int damage, range, minRange;
    private float distEnemy, timeStamp;
    private bool isFireReady;
    Transform transEnemy;

    private Vector2 startPos, target;
    EnemyHealth scriptEnemyHP;
    GameObject[] enemysO;
    GameObject enemyO;

    void Update() {
        timeStamp += Time.deltaTime;

        if(reloadTime <= timeStamp) {
            enemyO = GetClosestEnemy();
            transEnemy = enemyO.transform;
            distEnemy = Vector2.Distance(transform.position, transEnemy.position);

            if(distEnemy <= range && distEnemy >= minRange) {
                //scriptEnemyHP = enemyO.GetComponent<EnemyHealth>();
                target = transEnemy.position;
                CreateArrow();
                timeStamp = 0;
            }
        } 
    }

    GameObject GetClosestEnemy() {
        enemysO = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject go in enemysO) {
            Vector2 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void CreateArrow() {
        arrowO = Instantiate(arrow, transform.position, Quaternion.identity) as GameObject;
        arrowO.transform.parent = GameObject.Find("ArrowManager").transform;

        scriptArrow = arrowO.GetComponent<ArrowProjectile>();
        scriptArrow.target = target;
        scriptArrow.scale = scale;
        scriptArrow.damage = damage;
        scriptArrow.enemyO = enemyO;
        scriptArrow.scriptEnemyHP = enemyO.GetComponent<EnemyHealth>();
    }
}
