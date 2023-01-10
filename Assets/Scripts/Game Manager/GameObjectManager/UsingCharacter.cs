using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingCharacter : MonoBehaviour
{
    public static UsingCharacter instance;

    public List<int> characterUseIndex;
    public List<CharacterUI> characterUseUIList;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < characterUseUIList.Count; i++)
        {
            if (characterUseUIList[i]!=null)
            {
                if(characterUseUIList[i].characterBuyTime <= 0)
                {
                    characterUseUIList[i].canBuy = true;
                }
                else
                {
                    characterUseUIList[i].canBuy = false;
                    characterUseUIList[i].characterBuyTime -= Time.deltaTime;
                }
            }
            
        }
        if (UIController.instance != null)
        {
            for (int i = 0; i < characterUseUIList.Count; i++)
            {
                if (characterUseUIList[i] != null)
                {
                    UIController.instance.buyCD[i].fillAmount = characterUseUIList[i].characterBuyTime / characterUseUIList[i].characterBuyCD;
                }       
            }
        }
    }

    public void SetBuyCD(int i)
    {
        characterUseUIList[i].characterBuyTime = characterUseUIList[i].characterBuyCD;
    }
}
