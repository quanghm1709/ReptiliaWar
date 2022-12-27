using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public static MapSelect instance;

    public int mapIndex;
    public bool[] isActiveMap;
    private void Start()
    {
        instance = this;
    }

}
