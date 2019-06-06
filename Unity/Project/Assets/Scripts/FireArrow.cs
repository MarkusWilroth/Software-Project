using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour {
    public GameObject arrow;
    private GameObject arrowO;
    private ArrowProjectile scriptArrow;
    public float scale, reloadTime;
    public int damage, range, minRange;
    private float distEnemy, timeStamp, angle;
    private Vector3 direction;
    Transform transEnemy;
    Quaternion rotation;

    private Vector2 target;
    GetClosestEnemy scriptGetEnemy;
    GameObject enemyO;

    void Start() {
        scriptGetEnemy = gameObject.GetComponent<GetClosestEnemy>();
    }

    void Update() {
        timeStamp += Time.deltaTime;

        if(reloadTime <= timeStamp) {
            enemyO = scriptGetEnemy.GetClosest();
            transEnemy = enemyO.transform;
            distEnemy = Vector2.Distance(transform.position, transEnemy.position);
            
            if (distEnemy <= range && distEnemy >= minRange) {
                target = transEnemy.position;

                direction = enemyO.transform.position - transform.position;
                //angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //q = Quaternion.AngleAxis(angle, Vector3.forward);

                CreateArrow();
                timeStamp = 0;
            }
        } 
    }
    
    public void CreateArrow() {
        arrowO = Instantiate(arrow, transform.position, Quaternion.identity) as GameObject;
        arrowO.transform.parent = GameObject.Find("ArrowManager").transform;
        //arrowO.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
        rotation = Quaternion.LookRotation(Vector3.forward, direction);
        arrowO.transform.rotation = rotation * Quaternion.Euler(0, 0, 90);

        scriptArrow = arrowO.GetComponent<ArrowProjectile>();
        scriptArrow.target = target;
        scriptArrow.scale = scale;
        scriptArrow.damage = damage;
        scriptArrow.scriptEnemyHP = enemyO.GetComponent<EnemyHealth>();
    }
}
