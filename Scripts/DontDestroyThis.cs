using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyThis : MonoBehaviour
{

    void Start()
    {

        GameObject audioSourceGO = GameObject.Find("AudioSource");

        AudioSource source = audioSourceGO.GetComponent<AudioSource>();

        source.Play();
        source.Stop();
        source.UnPause();
        source.Pause();

        if(SceneManager.GetActiveScene().name == "Lobby"){
            DontDestroyOnLoad(audioSourceGO);
            source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
