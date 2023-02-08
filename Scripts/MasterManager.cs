using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField] private GameSettings gameSettings;
    public static GameSettings GameSettings { get { return Instance.gameSettings; } }

   

    [SerializeField] private List<NetworkedPrefab> networkedPrefabs = new List<NetworkedPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach(NetworkedPrefab networkedPrefab in Instance.networkedPrefabs)
        {
            if(networkedPrefab.Prefab == obj)
            {
                if(networkedPrefab.Path != string.Empty){
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    return result;
                }else{
                    Debug.LogError("The prefab " + obj.name + " does not have a path.");
                    return null;
                }
                
            }
        }

        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkedPrefabs()
    {
#if UNITY_EDITOR
        Instance.networkedPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for(int i = 0; i < results.Length; i++){

            if(results[i].GetComponent<PhotonView>() != null){
               string path = AssetDatabase.GetAssetPath(results[i]);
               Instance.networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
            }
        }
#endif
    }
}
