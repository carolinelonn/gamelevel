using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other) {
        GetComponent<Renderer>().enabled = false;
        Destroy(this);
        other.GetComponent<PlayerControllerNew>().count = other.GetComponent<PlayerControllerNew>().count + 1;
    }
	
}