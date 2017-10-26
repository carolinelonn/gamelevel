using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touched : MonoBehaviour{

    public GameObject Bolt;
    private float boltTime;

    void Start(){
        Bolt = GameObject.Find("Bolt");
        Bolt.SetActive(false);
        boltTime = 0.21f;
    }

    void Update(){
        boltTime = boltTime - Time.deltaTime;
        if (boltTime <= 0){
            Bolt.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("elec: " + other + Time.deltaTime);
        
        Bolt.transform.position = other.transform.position + new Vector3(1.2f, 2.0f, 0.0f);
        Bolt.SetActive(true);
        boltTime = 0.21f;

        //PLAY ANIMATION
    }
}
