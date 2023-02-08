using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private string gameVersion = "0.0.1";
    [SerializeField] private string nickName = "Punfisher";
    public string GameVersion { get { return gameVersion; } }

    public string NickName{
        get {
            int value = Random.Range(0, 1000);
            return nickName + value.ToString();
        }
    }
}
