using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    public GameObject myAvatar;

    void Awake(){
        PV = GetComponent<PhotonView>();
    }

    public void Start(){
        if(PV.IsMine){
            CreateController();
        }
    }

    void CreateController(){
        PhotonNetwork.Instantiate(this.myAvatar.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }

    public void EnterScenePhoton(){
        if(PhotonNetwork.IsConnected){
            SceneManager.LoadSceneAsync(2);
            CreateController();
        }

    }
}
