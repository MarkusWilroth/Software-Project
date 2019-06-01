using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int range, damage;
    public float attackTime;
    private float targetDist, timeStamp;

    private GameObject targetO;
    public HealthManager scriptHealth;
    private GetClosestTarget scriptTarget;
    
    void Update() {
        timeStamp += Time.deltaTime;

        if(attackTime <= timeStamp) {
            scriptTarget = gameObject.GetComponent<GetClosestTarget>();
            targetO = scriptTarget.targetO;

            targetDist = Vector2.Distance(transform.position, targetO.transform.position);

            if (targetDist <= range) {
                scriptHealth = targetO.GetComponent<HealthManager>();
                scriptHealth.hp -= damage;
                timeStamp = 0;
            }
        }
    }
}
