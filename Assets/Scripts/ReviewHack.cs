using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewHack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (Dialogue.scene_Load)
            {
                case 1:
                    SceneManager.LoadScene("Level_1");
                    break;
                case 2:
                    SceneManager.LoadScene("guillotine");
                    break;
                case 3:
                    SceneManager.LoadScene("lawnmower");
                    break;
                case 4:
                    Dialogue.scene_Load = 8;
                    SceneManager.LoadScene("godLevel");
                    break;
                case 5:
                    SceneManager.LoadScene("Level_1");
                    break;
                case 6:
                    SceneManager.LoadScene("guillotine");
                    break;
                case 7:
                    SceneManager.LoadScene("lawnmower");
                    break;
                case 8:
                    SceneManager.LoadScene("Menu");
                    break;

            }
        }
    }
}
