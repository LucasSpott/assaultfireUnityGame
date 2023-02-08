using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null){
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if(results.Length == 0){
                    Debug.LogError("No instance of " + typeof(T).Name + " found in the scene.");
                    return null;
                }
                if(results.Length > 1){
                    Debug.LogError("More than one instance of " + typeof(T).Name + " found in the scene.");
                    return null;
                }
                instance = results[0];
            }
            return instance;
        }
    }
}