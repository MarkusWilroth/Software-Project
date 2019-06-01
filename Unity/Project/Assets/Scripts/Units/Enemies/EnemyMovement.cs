using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public int speed;
    private GetClosestTarget scriptTarget;
    private Transform transTarget; 

    void Update() {
        scriptTarget = gameObject.GetComponent<GetClosestTarget>();
        transTarget = scriptTarget.targetO.transform;

        transform.position = Vector2.MoveTowards(transform.position, transTarget.position, speed * Time.deltaTime);
    }
}
