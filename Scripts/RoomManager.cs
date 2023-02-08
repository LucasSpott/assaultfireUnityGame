using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public void ButtonRun()
    {
        if(!PhotonNetwork.IsConnected){
            return;
        }

        if(PhotonNetwork.CurrentRoom == null){
            CreateAndJoinRoom();
        }else{
            PhotonNetwork.JoinRandomRoom();
        }

        if(!PhotonNetwork.IsMasterClient){
            base.photonView.RPC("RPC_LoadGame", RpcTarget.MasterClient);
        }
            
    }

    [PunRPC]
    private void RPC_LoadGame(){
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.LoadLevel(2);
        }else{
            Debug.Log("Not master client");
        }
    }

    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }


    void CreateAndJoinRoom(){
        string roomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom(){
        Debug.Log("Room created: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.Log("Room creation failed: " + message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom(){
        Debug.Log(PhotonNetwork.NickName + " joined " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene(2);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log(newPlayer.NickName + " joined " + PhotonNetwork.CurrentRoom.Name + PhotonNetwork.CurrentRoom.PlayerCount);
    }
}
