using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class SingletonObject<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

*/
public class SingletonObject : MonoBehaviour 
{
    public static SingletonObject Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}