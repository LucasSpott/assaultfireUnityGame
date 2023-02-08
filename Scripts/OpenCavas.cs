using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCavas : MonoBehaviour
{
    public GameObject setting;
    public GameObject Player;
    public GameObject canvasChat;

    public void OpenSetting(){
        setting.SetActive(true);
        Player.SetActive(false);
    }

    public void CloseSetting(){
        setting.SetActive(false);
        Player.SetActive(true);
    }

    public void Chat(){
        canvasChat.SetActive(true);
        Player.SetActive(false);
    }

}
