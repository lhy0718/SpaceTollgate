using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{
    public static MainSound inst;
    private void Awake()
    {
        if (inst != null) Destroy(gameObject);
        else
        {
            inst = this;
            DontDestroyOnLoad(this);
        }
    }
}
