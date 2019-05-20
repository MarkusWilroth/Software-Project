using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchScript : MonoBehaviour {

    public GameObject resPanel;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            OpenRes();
        }
    }

    void OpenRes() {
        resPanel.SetActive(true);
        Time.timeScale = 0; //pausar spelet
    }

    public void CloseRes() {
        resPanel.SetActive(false);
        Time.timeScale = 1; //fortsätter spelet
    }
}

//Kod stulet kommer behöva ändra hur forskningsfönstret öppnas!