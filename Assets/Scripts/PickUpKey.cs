using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour {
    
    void OnTriggerEnter2D (Collider2D other) {
        GetComponent<Renderer>().enabled = false;
        Destroy(this);
        other.GetComponent<PlayerController_Baby>().hasKey = true;
    }
	
}