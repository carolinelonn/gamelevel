using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewHack_4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Dialogue.scene_Load = 9;
            SceneManager.LoadScene("godLevel");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Dialogue.scene_Load = 1;
            SceneManager.LoadScene("Menu");
        }
    }
}
