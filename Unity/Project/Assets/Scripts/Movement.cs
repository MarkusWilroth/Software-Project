using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject point;
    private Vector3 target;
    private bool move = false;
    
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void ChangeTarget() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
    }
}
