using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timeToKill : MonoBehaviour
{
    private float time;
    public TMP_Text timeText;
    public static float timeToKillPlayer;
    public static bool stopTime;
    void Start()
    {
        stopTime = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(stopTime == false){
           time += Time.deltaTime;
           timeToKillPlayer = time;
           timeText.text = time.ToString("F10.0");
       }
    }
}
