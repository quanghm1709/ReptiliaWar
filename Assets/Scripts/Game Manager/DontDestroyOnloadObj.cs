using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnloadObj : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
