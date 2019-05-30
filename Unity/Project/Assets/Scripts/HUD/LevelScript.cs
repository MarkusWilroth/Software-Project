using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

    public int gold, wood, stone, score;
    public float woodModifier, stoneModifier;
    private float addWood, addStone;
    private float timer;

    void Start() {
    }
    
    void Update() {
        timer++;
        if(timer >= 60) {
            addWood += woodModifier;
            addStone += stoneModifier;

            if(addWood >= 1) {
                wood++;
                addWood = 0;
            }
            if(addStone >= 1) {
                stone++;
                addStone = 0;
            }
            timer = 0;
        }
    }
}
