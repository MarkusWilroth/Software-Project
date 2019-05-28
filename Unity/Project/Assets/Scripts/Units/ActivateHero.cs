using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHero : MonoBehaviour {

    public GameObject rangeHero, warriorHero;

    public void Activate(int id) {
        rangeHero = GameObject.FindGameObjectWithTag("RangeHero");
        warriorHero = GameObject.FindGameObjectWithTag("WarriorHero");


        switch (id) {
            case 1:
                rangeHero.MakeActive();
                warriorHero.DeActivate();
                break;
            case 2:
                rangeHero.DeActivate();
                warriorHero.MakeActive();
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
