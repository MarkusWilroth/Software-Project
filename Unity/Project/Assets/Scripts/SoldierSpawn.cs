using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawn : MonoBehaviour {
    public GameObject soldier;
    private GameObject soldierO;
    public int maxSoldiers, soldiers;
    Hero_Movement scriptHeroPos;
    private Vector2 heroPos;

    void Start() {
        scriptHeroPos = gameObject.GetComponent<Hero_Movement>();
    }

    void Update() {
        if(soldiers <= maxSoldiers) {
            heroPos = scriptHeroPos.heroPos;
            soldierO = Instantiate(soldier, heroPos, Quaternion.identity);
            //soldierO.transform.parent = gameObject.transform;
            soldiers++;
        }
    }

    public void RecruitSoldier(int id, Vector2 heroPos) {
        
    }
}
