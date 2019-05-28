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
                Debug.Log("Tower Building!"); //Detta debuggas
                //tranBuild.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                towerO = Instantiate(tower, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
                towerO.transform.parent = GameObject.Find("BuildingManager").transform;
                Debug.Log("Did it get here?"); //Detta debuggas inte....
                building = false;
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
