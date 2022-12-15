using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [Header("Character List")] 
    public List<GameObject> characterList;
    [SerializeField] private List<float> characterBuyCD;
    [SerializeField] public List<bool> canBuy;
    [SerializeField] private List<float> characterBuyTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        for(int i = 0; i < characterBuyTime.Count; i++)
        {
            if(characterBuyTime[i] <= 0)
            {
                canBuy[i] = true;
            }
            else
            {
                canBuy[i] = false;
                characterBuyTime[i] -= Time.deltaTime;
            }
        }
    }

    public void SetBuyCD(int i)
    {
        characterBuyTime[i] = characterBuyCD[i];
    }
}
