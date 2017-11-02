using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTrigger : MonoBehaviour
{
    public Sprite brokenSprite;
    public bool isBroken = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController_Baby>().hasHammer)
        {
            this.GetComponent<SpriteRenderer>().sprite = brokenSprite;
            isBroken = true;
        }
        Debug.Log(other.name);
        if(other.name == "Father") {
            isBroken = false;
        }
    }

}