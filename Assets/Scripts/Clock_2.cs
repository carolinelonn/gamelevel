using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clock_2 : MonoBehaviour
{

    public Text Countdown;
    public float timer;
    // Use this for initialization

    void Start()
    {
        Countdown = GetComponent<Text>() as Text;
        timer = 59.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        Countdown.text = timer.ToString("00:00");
        if (timer <= 0)
        {
            Dialogue.scene_Load = 7;
            SceneManager.LoadScene("godLevel");
        }
    }
}