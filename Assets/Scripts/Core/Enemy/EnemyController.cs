using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("Enemy Character List")] 
    public List<GameObject> characterList;
    [SerializeField] private Transform spawnPoint;
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
    }
    private void Spawn()
    {
        int randomChar = Random.Range(0, characterList.Count);
        if(characterList[randomChar].GetComponent<CharacterCore>().unitPrice < GameManager.instance.GetEnemyCrystal() 
            && currentSlot < GameManager.instance.GetEnemySlot())
        {
            Instantiate(characterList[randomChar], spawnPoint.position, spawnPoint.rotation);
            timeBtwBuy = Random.Range(1, 5);
            GameManager.instance.Buying(0, characterList[randomChar].GetComponent<CharacterCore>().unitPrice);
            UpdateCurrentSLot(1);
        }      
    }
    public void UpdateCurrentSLot(int slot)
    {
        currentSlot += slot;
    }
}
