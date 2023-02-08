using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab
{
    public GameObject Prefab;
    public string Path;

    public NetworkedPrefab(GameObject obj, string path){
        Prefab = obj;
        Path = path;
        //Assets/Resources/Player.prefab
        //Resources/Player.prefab
    }

    private string ReturnPrefabPathModified(string path)
    {
        int extensionLegh = System.IO.Path.GetExtension(path).Length;
        int startIndex = path.ToLower().IndexOf("resources");

        if(startIndex == -1){
            return string.Empty;
        }else{{
            return path.Substring(startIndex + 10, path.Length - (startIndex + extensionLegh));
        }}
    }
}
