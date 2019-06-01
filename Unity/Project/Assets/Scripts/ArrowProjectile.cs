using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {
    public Vector2 target;
    private Vector2 arrowPos;
    public float speed, scale;
    public int damage;
    public GameObject enemyO;
    public EnemyHealth scriptEnemyHP;


    void Start() {
        arrowPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        arrowPos.x = transform.position.x;
        arrowPos.y = transform.position.y;
        //transform.localScale = new Vector2(scale, scale);

        if (arrowPos == target) {
            //Debug.Log("Before scriptEnemy");
            //scriptEnemyHP = enemyO.GetComponent<EnemyHealth>();
            Debug.Log("ScriptEnemyHP: " + scriptEnemyHP);
            //Debug.Log("After scriptEnemy");
            scriptEnemyHP.hp -= damage;
            Destroy(gameObject);
        }
    }
}
