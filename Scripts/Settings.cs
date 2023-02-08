using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
   public GameObject settingsCanvas;
   public GameObject returnCanvas;

    public AudioMixer audioMixer;

    Dictionary<string, string> language = new Dictionary<string, string>();

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
