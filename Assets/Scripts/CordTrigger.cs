using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordTrigger : MonoBehaviour {

    public GameObject fence;
    public GameObject FenceTrigger;
    public GameObject Lawnmover;

    public GameObject wireBolt;
    private float boltTime;

    public Animator anim;

    void Start(){
        fence = GameObject.Find("fence");
        FenceTrigger = GameObject.Find("FenceTrigger");
        Lawnmover = GameObject.Find("Lawnmover");

        wireBolt = GameObject.Find("wireBolt");
        wireBolt.SetActive(false);
        boltTime = 0.21f;
    }
    /*
    void Update(){
        boltTime = boltTime - Time.deltaTime;
        if (boltTime <= 0){
            wireBolt.SetActive(false);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger " + other.GetComponent<Collider2D>());
        Debug.Log("test" + Lawnmover.GetComponent<Collider2D>());
        if (other == Lawnmover.GetComponent<Collider2D>()){
            Debug.Log("triggerIF ");
            //Debug.Log("IF FenceTrigger: " + FenceTrigger);
            fence.GetComponent<Collider2D>().enabled = false;
            anim = fence.GetComponent<Animator>();
            anim.SetTrigger("FenceOff");
            FenceTrigger.GetComponent<Collider2D>().enabled = false;

            wireBolt.transform.position = other.transform.position + new Vector3(1.2f, 2.0f, 0.0f);
            wireBolt.SetActive(true);
            //boltTime = 0.21f;
            //PLAY ANIMATION
        }

    }
	
}