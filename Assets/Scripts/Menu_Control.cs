using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour {

    public void NewGameBtn(string newGameLevel)
    {
        Dialogue.scene_Load = 1;
        SceneManager.LoadScene("godLevel");
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
