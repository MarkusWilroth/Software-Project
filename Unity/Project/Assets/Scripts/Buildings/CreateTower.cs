using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour {
    private bool building;
    public GameObject towerO, tower;
    private Transform tranBuild;
    
    public void Construct(bool building) {
        this.building = building;
    }

    void Update() {
        if(building) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Tower Building!");
                //tranBuild.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                towerO = Instantiate(tower, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
                towerO.transform.parent = GameObject.Find("BuildingManager").transform;
                Debug.Log("Did it get here?");
                building = false;
            }
            if (Input.GetMouseButtonDown(1)) { //höger musknapp?
                building = false;
            }
        }
    }

}
