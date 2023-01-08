using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [Header("Character List")] 
    public List<CharacterUI> playerCharacterList;
    public bool[] isActive;

    [Header("All Character")]
    public List<string> characterListName;
    
    private void Awake()
    {
        if(instance == null)
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
        
    }

    private void Update()
    {
        

    }

    

    public void Load()
    {
        if (SaveDemo.instance.HasKey("Character"))
        {
            List<int> data = new List<int>();
            data = SaveDemo.instance.Load("Character");
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == 1)
                {
                    isActive[i] = true;
                }
            }
        }
       
    }
    public void Save()
    {
        List<int> data = new List<int>();
        for(int i = 0; i < isActive.Length; i++)
        {
            if (isActive[i])
            {
                data.Add(1);
            }
            else
            {
                data.Add(0);
            }
        }
        SaveDemo.instance.Save("Character", data);
    }
}
