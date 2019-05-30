using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castleTxt : MonoBehaviour {
    public Text txtCastle;
    GameObject castleO;
    Castle scriptCastle;

    void Start() {
        castleO = GameObject.FindGameObjectWithTag("Castle");
        scriptCastle = castleO.GetComponent<Castle>();
    }

    void Update() {
        txtCastle.text = "Castle health: " + scriptCastle.HP;
    }

}
