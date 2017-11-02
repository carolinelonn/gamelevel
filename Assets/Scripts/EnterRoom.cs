using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour {
    
    void OnTriggerEnter2D (Collider2D other) {
        if(!GameObject.Find("Father").GetComponent<BabyFather>().hasLeftRoom) {
            other.GetComponent<PlayerController_Baby>().failed = true;
        }
    }
	
}