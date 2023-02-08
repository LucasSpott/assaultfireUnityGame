using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimCam : MonoBehaviour
{
    public Transform cam;
    public float Sensitivity;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update(){
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity;
        cam.Rotate(0, MouseX, 0);
        transform.Rotate(-MouseY, 0, 0);
    }
}
