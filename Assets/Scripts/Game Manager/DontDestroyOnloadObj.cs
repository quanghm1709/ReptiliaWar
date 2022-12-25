using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnloadObj : MonoBehaviour
{
    public static DontDestroyOnloadObj instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
