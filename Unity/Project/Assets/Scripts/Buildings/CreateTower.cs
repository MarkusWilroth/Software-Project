using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour {
    private bool building;
    private int woodCost, stoneCost, goldCost;
    public GameObject towerO, tower;
    private Transform tranBuild;
    private LevelScript scriptLvl;
    private Building scriptBuild;
    GameObject lvlManagerO;
    Vector2 mousePos;

    void Start() {
        lvlManagerO = GameObject.FindGameObjectWithTag("lvlManager");
    }

    public void Construct(bool building) {
        this.building = building;
    }

    void Update() {
        if(building) {
            if (Input.GetMouseButtonDown(0)) {
                scriptBuild = tower.GetComponent<Building>();

                scriptLvl = lvlManagerO.GetComponent<LevelScript>();

                if(scriptLvl.wood >= scriptBuild.woodCost && scriptLvl.stone >= scriptBuild.stoneCost && scriptLvl.gold >= scriptBuild.goldCost) {

                    scriptLvl.wood -= scriptBuild.woodCost;
                    scriptLvl.stone -= scriptBuild.stoneCost;
                    scriptLvl.gold -= scriptBuild.goldCost;

                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    towerO = Instantiate(tower, mousePos, Quaternion.identity) as GameObject;
                    towerO.transform.parent = GameObject.Find("TowerManager").transform;
                    building = false;
                }
                else {
                    Debug.Log("Inte nog med resurser");
                }
               
            }
            if (Input.GetMouseButtonDown(1)) { //höger musknapp?
                building = false;
            }
        }
    }

}
/* Den hoppar ut ut scriptet vid rad 19 eller 20... tror det har med Camera.main.ScreenToWorldPoint(Input.mousePosition) att göra... såg att man kunde
 * göra transform.position = Camera.main.ScreenToWorldPont(Input.mousePosition) men det blev konstigt.. kan du kolla på det?
*/
