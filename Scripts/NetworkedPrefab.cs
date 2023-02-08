using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefab
{
    public GameObject Prefab;
    public string Path;

    public NetworkPrefab(GameObject obj, string path)
    {
        Prefab = obj;
        Path = path;
    }

    private string ReturnPrefabPathModified(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");

        if(startIndex == -1){
            Debug.LogError("The path " + path + " does not contain the Resources folder.");
            return string.Empty;
        }else{
            return path.Substring(startIndex + additionalLength, path.Length - extensionLength - startIndex - additionalLength);
        }
    }
}
