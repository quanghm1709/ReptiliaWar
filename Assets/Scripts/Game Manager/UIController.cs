using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Camera cam;
    [SerializeField] public Text playerCrystal;
    private void Awake()
    {
        instance = this;
    }

    public void SpawnCharacter(int index)
    {
        Transform spwanpoint = GameObject.Find("Tower").GetComponent<TowerCore>().spawnPoint;
        int unitPrice = CharacterManager.instance.characterList[index].GetComponent<CharacterCore>().unitPrice;

        if(unitPrice <= GameManager.instance.GetMyCystal())
        {
            Instantiate(CharacterManager.instance.characterList[index], spwanpoint.position, spwanpoint.rotation);
            GameManager.instance.Buying(unitPrice, 0);
        }
        
    }
}
