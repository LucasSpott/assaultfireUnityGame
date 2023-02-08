using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonStart : MonoBehaviour
{
    public GameObject canvasSignIn;
    public GameObject canvasRegister;

    public void StartGame()
    {
        canvasSignIn.SetActive(true);
    }

    public void Register(){
        canvasSignIn.SetActive(false);
    }
}
