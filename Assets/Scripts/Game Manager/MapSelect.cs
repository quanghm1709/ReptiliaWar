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
    public void Load()
    {
        if (SaveDemo.instance.HasKey("Map"))
        {
            List<int> data = SaveDemo.instance.Load("Map");
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == 1)
                {
                    isActiveMap[i] = true;
                }
            }
        }
    }
    public void Save()
    {
        List<int> data = new List<int>();
        for (int i = 0; i < isActiveMap.Length; i++)
        {
            if (isActiveMap[i])
            {
                data.Add(1);
            }
            else
            {
                data.Add(0);
            }
        }
        SaveDemo.instance.Save("Map", data);
    }
}
