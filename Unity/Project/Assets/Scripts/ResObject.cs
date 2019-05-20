using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResObject : ScriptableObject {

    public string resName = "Research Name Here";
    public int cost = 30; //Kostnad i exp
    public string description;

    //Här ska vi ha alla möjliga saker man kan forska fram!
    //TowerUpgrades:
    public bool fireArrow = false; //Ökad skada på skott
    public bool strongStone = false; //Ökad HP för byggnader

    //Resources:
    public bool tools1 = false;
    public bool tools2 = false;
    public bool tools3 = false;

    //Soldiers
    public bool wellFed = false;
    public bool strongSteel = false;
    public bool advancedSteel = false;

    //Hero:
    public bool soldierCap = false;
    public bool soldierTech = false;
    
}
