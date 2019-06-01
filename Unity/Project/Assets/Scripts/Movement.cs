using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;

public class Movement : MonoBehaviour {
    public float speed;
    public GameObject point;
    public Vector3 target;
    private bool move = false;

    void Start() {
        //target = new Vector3(-4, -3, 0);
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void ChangeTarget() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        if (!move) {
            move = true;
        }
        if (move) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
