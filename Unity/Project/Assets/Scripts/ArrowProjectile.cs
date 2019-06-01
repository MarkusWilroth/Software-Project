using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {
    public Vector2 target;
    private Vector2 arrowPos;
    public float speed, scale;
    public int damage;
    public EnemyHealth scriptEnemyHP;


    void Start() {
        arrowPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        arrowPos.x = transform.position.x;
        arrowPos.y = transform.position.y;
        //transform.localScale = new Vector2(scale, scale); //Vill fixa scale men vet inte hur jag ska göra det...

        if (arrowPos == target) {
            scriptEnemyHP.hp -= damage;
            Destroy(gameObject);
        }
    }
}
