using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClosestEnemy : MonoBehaviour {
    
    GameObject[] enemysO;
    
    public GameObject GetClosest() {
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
}
