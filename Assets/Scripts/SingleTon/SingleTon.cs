using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            instance = (T)FindAnyObjectByType(typeof(T));
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                instance = obj.GetComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}