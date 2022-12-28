using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [Header("Character List")] 
    public List<CharacterUI> playerCharacterList;
    public bool[] isActive;

    
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
        for(int i = 0; i < playerCharacterList.Count; i++)
        {
            if(playerCharacterList[i].characterBuyTime <= 0 && isActive[i])
            {
                playerCharacterList[i].canBuy = true;
            }
            else
            {
                playerCharacterList[i].canBuy = false;
                playerCharacterList[i].characterBuyTime -= Time.deltaTime;
            }
        }
        if(UIController.instance != null)
        {
            for (int i = 0; i < playerCharacterList.Count; i++)
            {
                UIController.instance.buyCD[i].fillAmount = playerCharacterList[i].characterBuyTime / playerCharacterList[i].characterBuyCD;
            }
        }

    }

    public void SetBuyCD(int i)
    {
        playerCharacterList[i].characterBuyTime = playerCharacterList[i].characterBuyCD;
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
