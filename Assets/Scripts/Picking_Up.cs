    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using  UnityEngine.SceneManagement;

public class Picking_Up: MonoBehaviour
    {

    private int count;
    public Text countText;
    public string sceneName;
    public string sceneName2;


       void Start()
        {
        count = 0;
 
    }


        void OnTriggerEnter2D(Collider2D other)
        {
    
        if (other.gameObject.CompareTag("item_winebottle"))
            {
            other.gameObject.SetActive(false);
            count = count + 1;
            

        }
        if (other.gameObject.CompareTag("Police"))
        {
            SceneManager.LoadScene(sceneName);

        }
        if (count == 13)
        {
            SceneManager.LoadScene(sceneName2);

        }
    }
    }