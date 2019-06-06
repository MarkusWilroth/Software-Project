using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingIncome : MonoBehaviour {
    private LevelScript scriptLevel;
    public int woodIncome, goldIncome, stoneIncome;

    void Start() {
        scriptLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>();
    }

    public void GenerateBuilding() {
        scriptLevel.wood += woodIncome;
        scriptLevel.stone += stoneIncome;
        scriptLevel.gold += goldIncome;
    }
}
