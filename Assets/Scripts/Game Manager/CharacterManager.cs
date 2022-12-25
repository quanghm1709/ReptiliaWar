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
}
