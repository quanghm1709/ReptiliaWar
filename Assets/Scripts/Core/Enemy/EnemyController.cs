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
        if(characterList[randomChar].GetComponent<CharacterCore>().unitPrice < GameManager.instance.GetEnemyCrystal())
        {
            Instantiate(characterList[randomChar], spawnPoint.position, spawnPoint.rotation);
            timeBtwBuy = Random.Range(1, 3);
        }      
    }
}
