using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour {

    private Building scriptBuild;
    public GameObject buildingO;
    public Text txtDescript;

    private int woodCost, stoneCost, goldCost;
    private string description;

    void Start() {
        scriptBuild = buildingO.GetComponent<Building>();
        woodCost = scriptBuild.woodCost;
        stoneCost = scriptBuild.stoneCost;
        goldCost = scriptBuild.goldCost;
        description = scriptBuild.description;
    }
    
    public void Hover() {
        txtDescript.text = description + "\nWood cost: " + woodCost + " Stone cost: " + stoneCost + " Gold cost: " + goldCost;
    }

    public void Leave() {
        txtDescript.text = "";
    }
}
