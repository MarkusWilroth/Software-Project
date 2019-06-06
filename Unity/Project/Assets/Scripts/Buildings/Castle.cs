using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour {
    
    public void GameOver() {
        SceneManager.LoadScene("Menu Start");
    }
}
