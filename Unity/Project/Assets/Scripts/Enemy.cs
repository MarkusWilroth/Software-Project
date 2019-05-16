using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHP = 20;
    public int HP = 20;
    public int Armor = 0;
    public int damage = 10;
    public int maxFollowers = 0;
    public int followers = 0;
    public int followerLvl = 0;
    public int range = 5;
    public float speed = 10f;
    public Vector2 pos = new Vector2(0,0);

    void Start() {
        HP = maxHP;
        //pos = map.SpawnPoint;
    }
    
    void Update() {
        if (followers < maxFollowers) {
            Recruit();
        }
        //Funderar på om det inte är bäst att ha alla fiender i ett o samma script... vi får kolla på tutorials vad som är bäst
    }

    void Recruit() {
        //Skapar en ny fiende o ger dess stats beroende på vilka stats den kan ha
        followers++;
    }
}
