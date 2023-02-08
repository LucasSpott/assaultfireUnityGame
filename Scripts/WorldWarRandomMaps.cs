using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class WorldWarRandomMaps : MonoBehaviourPunCallbacks{

    public override void OnJoinedRoom(){
        Debug.Log("Joined room");
    }

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void RandomMapsWorldWar(){
        PhotonNetwork.LoadLevel(2);
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        string roomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
        Debug.Log("Joined create room");
    }

}

