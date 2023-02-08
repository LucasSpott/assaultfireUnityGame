using UnityEngine;

namespace KnoxGameStudios
{
    public class DontDestory : MonoBehaviour
    {
        private void Awake()
        {
          
        }

        private void Start()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("NoDestroy");

            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}