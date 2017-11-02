using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuillotineTrigger : MonoBehaviour {

    public Animator anim;
    public string sceneName;
    
    // Use this for initialization
    void OnTriggerEnter2D (Collider2D other) {
        anim = GetComponent<Animator>();
        other.GetComponent<Renderer>().enabled = false;
        anim.SetTrigger("death");

        Dialogue.scene_Load = 2;
        SceneManager.LoadScene("godLevel");
    }
	
}