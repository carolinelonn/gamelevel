using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour{

    public Animator anim;
    public string sceneName;


    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("beehive: " + other.gameObject);
        anim = other.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Death");
        //Application.LoadLevel(index: Application.loadedLevel);
        SceneManager.LoadScene(sceneName);

    }


}
