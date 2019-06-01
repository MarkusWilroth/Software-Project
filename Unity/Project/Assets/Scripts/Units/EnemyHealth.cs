using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int hp, scoreValue, goldValue;
    private LevelScript scriptLvl;
    GameObject lvlManagerO;

    void Start() {
        lvlManagerO = GameObject.FindGameObjectWithTag("lvlManager");
    }

    void Update() {
        if (hp <= 0) {
            scriptLvl = lvlManagerO.GetComponent<LevelScript>();
            scriptLvl.score += scoreValue;
            scriptLvl.gold += goldValue;
            Destroy(gameObject);
        }
    }
}
