using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

    private static T _instance = null;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                if (FindObjectsOfType<T>().Length > 1)
                    Debug.LogError("More than one");
                else if (FindObjectOfType<T>() != null)
                    _instance = FindObjectOfType<T>();
                else
                {
					GameObject go = new GameObject
					{
						name = typeof(T).Name
					};
					_instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

	public void SetStatic()
    {
        if (_instance != null)
            DontDestroyOnLoad(_instance.gameObject);
    }
}
