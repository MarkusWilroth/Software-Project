using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

    public int gold, wood, stone, score, woodModifier, stoneModifier;
    private float addWood, addStone;
    private float timer;
    private GameObject[] buildings;
    private BuildingIncome scriptIncome;
    
    public void Generate(int wave) {
        wood += (stoneModifier + (5 * wave));
        stone += (stoneModifier + (5 * wave));

        buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach(GameObject building in buildings) {
            scriptIncome = building.GetComponent<BuildingIncome>();
            scriptIncome.GenerateBuilding();
        }


    }
}
