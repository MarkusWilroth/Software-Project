using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenyButtons : MonoBehaviour {
    public GameObject startMenu, optionMenu, helpMenu;

    void Start() {
        startMenu = GameObject.Find("StartMenu");
        optionMenu = GameObject.Find("OptionMenu");
        helpMenu = GameObject.Find("HelpMenu");

        optionMenu.SetActive(false);
        helpMenu.SetActive(false);
    }

    public void changeMenuScene(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Help() {
        helpMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void Options() {
        optionMenu.SetActive(true);
        startMenu.SetActive(false);
    }
    public void Return() {
        startMenu.SetActive(true);
        optionMenu.SetActive(false);
        helpMenu.SetActive(false);
    }
    public void Quit() {
        Application.Quit();
    }

}
