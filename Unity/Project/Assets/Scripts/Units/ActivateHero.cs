using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHero : MonoBehaviour {

    //public GameObject rangeHero, warriorHero;
    public Hero_Movement rangeHero, warriorHero;

    public void Activate(int id) { //Får in värde 1 eller 2 beroende på vilken knapp man klickar på
        rangeHero = GameObject.FindGameObjectWithTag("RangeHero").GetComponent<Hero_Movement>(); //Borde inte vara annorlund än hur vi gör detta i EnemyLeader, hade tänkt att detta skulle vara en sorts FindChild men hittade ingen sådan
        warriorHero = GameObject.FindGameObjectWithTag("WarriorHero").GetComponent<Hero_Movement>();

        switch (id) {
            case 1: //Om id = 1 så klickade man på ranger knappen och ranger ska bli activerad
                rangeHero.MakeActive(); //Ska finnas en metod i Hero som ska fixa detta så som vi gör TakeDamage
                warriorHero.DeActivate();
                break;
            case 2:
                rangeHero.DeActivate();
                warriorHero.MakeActive();
                break;
        }

    }
}
