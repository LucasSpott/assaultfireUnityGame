using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvas : MonoBehaviour
{
    public GameObject canvasChat;

    public void Chat()
    {
        canvasChat.SetActive(true);
    }
}
