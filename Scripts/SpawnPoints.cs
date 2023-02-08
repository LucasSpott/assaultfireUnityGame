using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;


public class SpawnPoints : MonoBehaviour
{
    public Transform[] spawnPointsRedTeam;
    public Transform[] spawnPointsBlueTeam;
    public bool isRedTeam;
    public bool isBlueTeam;
    public int nextPlayersTeam;
    public int teamRed;
    public int teamBlue;

    public static SpawnPoints spawnPoints;

    public void UpdateTeam(){
       
       if(nextPlayersTeam == 1){
            nextPlayersTeam = 2;
       }else{
            nextPlayersTeam = 1;
       }
    }

}
