using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDemo : MonoBehaviour
{
    public static SaveDemo instance;
    public bool isStartGame = true;
    private void Start()
    {
        instance = this;
    }

    public void Save(string key, List<int> value)
    {
        PlayerPrefs.SetInt(key + "count", value.Count);
        for (int i = 0; i< value.Count; i++)
        {
            PlayerPrefs.SetInt(key + i, value[i]);
        }
    }

    public List<int> Load(string key)
    {
        List<int> data = new List<int>();
        int count = PlayerPrefs.GetInt(key + "count");
        for(int i = 0; i < count; i++)
        {
            data.Add(PlayerPrefs.GetInt(key + i));
        }
        return data;
    }

    public bool HasKey(string key)
    {
        if (PlayerPrefs.HasKey(key + "count"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
