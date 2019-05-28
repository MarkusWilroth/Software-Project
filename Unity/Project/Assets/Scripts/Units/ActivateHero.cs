using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHero : MonoBehaviour {

    public GameObject rangeHero, warriorHero, heroManager;

    public void Activate(int id) {
        rangeHero = heroManager.FindComponentInChildWithTag("RangeHero");
        warriorHero = heroManager.FindComponentInChildWithTag("WarriorHero");

        switch (id) {
            case 1:
                rangeHero.active = true;
                warriorHero.active = false;
                break;
            case 2:
                rangeHero.active = false;
                warriorHero.active = true;
                break;
        }

    }

    //public static GameObject FindChild(GameObject HeroManager, string tag) {
    //    Transform t = parent.Transform;
    //    foreach(Transform tr in t) {
    //        if ()
    //    }
    //}
}
