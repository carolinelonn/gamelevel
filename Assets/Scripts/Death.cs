using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{

    public Animator anim;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("beehive: " + other.gameObject);
        anim = other.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Death");
        //Application.LoadLevel(index: Application.loadedLevel);
    }
}
