using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("Enemy Character List")]
    public List<CharacterUI> enemyCharacterList;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBtwWaveCD;
    private float timeBtwWave;
    private float waveTime;
    private float timeBtwBuy;
    private int currentSlot;
    
    private void Start()
    {
        instance = this;
        timeBtwBuy = 0f;
        waveTime = 1f;
    }
    
    private void Update()
    {
        if(waveTime > 0)
        {
            waveTime -= Time.deltaTime;
            if (timeBtwBuy < 0)
            {
                Spawn();
            }
            else
            {
                timeBtwBuy -= Time.deltaTime;
            }
        }
        else
        {
            if(timeBtwWave > 0)
            {
                timeBtwWave -= Time.deltaTime;
            }
            else
            {
                waveTime = Random.Range(1f, 4f);
                timeBtwWave = Random.Range(4f, 9f);
            }
        }

        

        for (int i = 0; i < enemyCharacterList.Count; i++)
        {
            if (enemyCharacterList[i].characterBuyTime <= 0)
            {
                enemyCharacterList[i].canBuy = true;
            }
            else
            {
                enemyCharacterList[i].canBuy = false;
                enemyCharacterList[i].characterBuyTime -= Time.deltaTime;
            }
        }
    }
    private void Spawn()
    {
        int randomChar = Random.Range(0, enemyCharacterList.Count);
        if(enemyCharacterList[randomChar].character.GetComponent<CharacterCore>().unitPrice < GameManager.instance.GetEnemyCrystal() 
            && currentSlot < GameManager.instance.GetEnemySlot()
            && enemyCharacterList[randomChar].canBuy)
        {
            Instantiate(enemyCharacterList[randomChar].character, spawnPoint.position, spawnPoint.rotation);
            timeBtwBuy = Random.Range(1, 5);
            GameManager.instance.Buying(0, enemyCharacterList[randomChar].character.GetComponent<CharacterCore>().unitPrice);
            UpdateCurrentSLot(1);
            enemyCharacterList[randomChar].characterBuyTime = enemyCharacterList[randomChar].characterBuyCD;
        }      
    }
    public void UpdateCurrentSLot(int slot)
    {
        currentSlot += slot;
    }
}
