using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.SceneManagement;

public class PhotonConected : MonoBehaviourPunCallbacks
{
    public GameObject Player;
    public static PhotonConected instance;
    public int teamRed;
    public int teamBlue;
    public GameObject canvasGame;
    public GameObject playerLobby;
    public GameObject playerChoiceTeam;
    

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
    }

    public void ChocieTeam(){
        playerChoiceTeam.SetActive(true);
        playerLobby.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("Disconnected: " + cause);
    }

    public override void OnJoinedLobby(){
        Debug.Log("Joined lobby");
    }

    public void enterGames(){
        canvasGame.SetActive(true);
        playerLobby.SetActive(false);
    }

    public void RandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        string roomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
        Debug.Log("Joined create room");
    }

    public override void OnJoinedRoom(){
        
        
     if (PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count >= PunTeams.PlayersPerTeam[PunTeams.Team.red].Count)
     {
            GameObject player = PhotonNetwork.Instantiate(Player.name, SpawnPoints.spawnPoints.spawnPointsRedTeam[Random.Range(0, SpawnPoints.spawnPoints.spawnPointsRedTeam.Length)].position, Quaternion.identity);
            PhotonNetwork.LocalPlayer.SetTeam(PunTeams.Team.red);
     }else if(PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count < PunTeams.PlayersPerTeam[PunTeams.Team.red].Count){
            GameObject player = PhotonNetwork.Instantiate(Player.name, SpawnPoints.spawnPoints.spawnPointsBlueTeam[Random.Range(0, SpawnPoints.spawnPoints.spawnPointsBlueTeam.Length)].position, Quaternion.identity);
            PhotonNetwork.LocalPlayer.SetTeam(PunTeams.Team.blue);
     }else if(PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count == PunTeams.PlayersPerTeam[PunTeams.Team.red].Count){
            GameObject player = PhotonNetwork.Instantiate(Player.name, SpawnPoints.spawnPoints.spawnPointsRedTeam[Random.Range(0, SpawnPoints.spawnPoints.spawnPointsRedTeam.Length)].position, Quaternion.identity);
            PhotonNetwork.LocalPlayer.SetTeam(PunTeams.Team.red);
     }else if(PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count == PunTeams.PlayersPerTeam[PunTeams.Team.red].Count){
            GameObject player = PhotonNetwork.Instantiate(Player.name, SpawnPoints.spawnPoints.spawnPointsBlueTeam[Random.Range(0, SpawnPoints.spawnPoints.spawnPointsBlueTeam.Length)].position, Quaternion.identity);
            PhotonNetwork.LocalPlayer.SetTeam(PunTeams.Team.blue);
     }
RandomMaps(); 

}
        
            

    public void RandomMaps(){
        //PhotonNetwork.LoadLevel(Random.Range(2, 7));
        SceneManager.LoadSceneAsync(2);
    }

}
