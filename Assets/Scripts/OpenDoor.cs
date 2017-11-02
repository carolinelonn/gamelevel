using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isOpen = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController_Baby>().hasKey && !isOpen)
        {
            isOpen = true;
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }

}