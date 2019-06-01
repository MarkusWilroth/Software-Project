using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int range, damage;
    public float attackTime;
    private float targetDist, timeStamp;

    private GameObject targetO;
    public EnemyHealth scriptHealth;
    private GetClosestEnemy scriptTarget;

    void Update() {
        timeStamp += Time.deltaTime;

        if (attackTime <= timeStamp) {
            scriptTarget = gameObject.GetComponent<GetClosestEnemy>();
            targetO = scriptTarget.GetClosest();

            targetDist = Vector2.Distance(transform.position, targetO.transform.position);

            if (targetDist <= range) {
                scriptHealth = targetO.GetComponent<EnemyHealth>();
                scriptHealth.hp -= damage;
                timeStamp = 0;
            }
        }
    }
}
