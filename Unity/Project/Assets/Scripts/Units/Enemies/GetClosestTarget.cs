using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClosestTarget : MonoBehaviour {
    public bool isTargetUnits;
    public int attackDist;
    private float warriorDist, rangeDist, castleDist, soldierDist;
    private Transform castlePos, warriorHeroPos, rangeHeroPos, soldierPos, targetPos;
    GameObject soldierO, warriorO, rangerO, castleO;
    GameObject[] soldiersO;
    public GameObject targetO;
    
    private EnemyMovement scriptMovement;
    //private EnemyAttack scriptAttack;
    
    void Update() {
        GetObject();
        GetPos();
        GetDist();
        GetScript();
        
        targetO = GetClosest();
    }

    #region Varibles
    public void GetObject() {
        soldierO = GetClosestSoldier();
        warriorO = GameObject.FindGameObjectWithTag("WarriorHero");
        rangerO = GameObject.FindGameObjectWithTag("RangeHero");
        castleO = GameObject.FindGameObjectWithTag("Castle");
    }

    public void GetPos() {
        warriorHeroPos = warriorO.transform;
        soldierPos = soldierO.transform;
        rangeHeroPos = rangerO.transform;
        castlePos = castleO.transform;
    }

    public void GetDist() {
        castleDist = Vector2.Distance(transform.position, castlePos.position);
        soldierDist = Vector2.Distance(transform.position, soldierPos.position);
        warriorDist = Vector2.Distance(transform.position, warriorHeroPos.position);
        rangeDist = Vector2.Distance(transform.position, rangeHeroPos.position);
    }

    public void GetScript() {
        scriptMovement = gameObject.GetComponent<EnemyMovement>();
    }


    #endregion
    GameObject GetClosestSoldier() {
        soldiersO = GameObject.FindGameObjectsWithTag("Soldier");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject go in soldiersO) {
            Vector2 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    GameObject GetClosest() {
        GameObject target = null;
        float dist;
        if ((rangeDist < attackDist|| warriorDist < attackDist || soldierDist < attackDist) && castleDist > attackDist) {
            if (rangeDist <= warriorDist && rangeDist <= soldierDist) {
                dist = rangeDist;
                target = rangerO;
            } else if (warriorDist <= soldierDist) {
                dist = warriorDist;
                target = warriorO;
            } else {
                dist = soldierDist;
                target = soldierO;
            }
        } else {
            dist = castleDist;
            target = castleO;
        }

        return target;
    }
}
