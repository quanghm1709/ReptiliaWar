using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("Enemy Character List")] 
    public List<GameObject> characterList;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<float> characterBuyCD;
    [SerializeField] public List<bool> canBuy;
    [SerializeField] private List<float> characterBuyTime;
    private float timeBtwBuy;
    private int currentSlot;

    private void Start()
    {
        instance = this;
        timeBtwBuy = 0f;

    }
    
    private void Update()
    {
        if(timeBtwBuy < 0)
        {
            Spawn();
        }
        else
        {
            timeBtwBuy -= Time.deltaTime;
        }

        for (int i = 0; i < characterBuyTime.Count; i++)
        {
            if (characterBuyTime[i] <= 0)
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
    private void Spawn()
    {
        int randomChar = Random.Range(0, characterList.Count);
        if(characterList[randomChar].GetComponent<CharacterCore>().unitPrice < GameManager.instance.GetEnemyCrystal() 
            && currentSlot < GameManager.instance.GetEnemySlot()
            && canBuy[randomChar])
        {
            Instantiate(characterList[randomChar], spawnPoint.position, spawnPoint.rotation);
            timeBtwBuy = Random.Range(1, 5);
            GameManager.instance.Buying(0, characterList[randomChar].GetComponent<CharacterCore>().unitPrice);
            UpdateCurrentSLot(1);
            characterBuyTime[randomChar] = characterBuyCD[randomChar];
        }      
    }
    public void UpdateCurrentSLot(int slot)
    {
        currentSlot += slot;
    }
}
