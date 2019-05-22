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

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //Vector3 mousePosition = UnityInput.mousePosition;

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target = mousePosition;
            target.z = transform.position.z;
            if (!move) {
                move = true;
            }
            Instantiate(point, target, Quaternion.identity);
        }
        if (move) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
