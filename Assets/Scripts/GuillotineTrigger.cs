using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotineTrigger : MonoBehaviour {

    public Animator anim;
    
    // Use this for initialization
    void OnTriggerEnter2D (Collider2D other) {
        anim = GetComponent<Animator>();
        other.GetComponent<Renderer>().enabled = false;
        anim.SetTrigger("death");

        //Application.LoadLevel(index: Application.loadedLevel);
    }
	
}