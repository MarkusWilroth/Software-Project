using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResScript : MonoBehaviour {
    public int resType;
    public Text resText;
    GameObject lvlO;
    LevelScript lvlScript;

    void Start() {
        

    }
    
    void Update() {
        lvlO = GameObject.FindGameObjectWithTag("lvlManager");
        lvlScript = lvlO.GetComponent<LevelScript>();

        switch (resType) {
            case 1:
                resText.text = lvlScript.gold.ToString();
                break;
            case 2:
                resText.text = lvlScript.wood.ToString();
                break;
            case 3:
                resText.text = lvlScript.stone.ToString();
                break;
            case 4:
                resText.text = "Score: " + lvlScript.score;
                break;
        }

    }
}
