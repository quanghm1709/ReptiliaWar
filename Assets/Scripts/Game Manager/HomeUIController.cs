using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour
{
    public static HomeUIController instace;

    [Header("UI component")]
    [SerializeField] private GameObject characterShowAll;
    [SerializeField] private GameObject showCharacterData;
    [SerializeField] private CharacterCore[] characterList;
    [SerializeField] private Text[] showData;
    public GameObject loadScreen;
    public Slider loadCD;
    private void Start()
    {
        instace = this;    
    }

    public void ShowDetails(int index)
    {
        showCharacterData.SetActive(true);
        CharacterCore core = characterList[index];

        showData[0].text = "Name: " + core.name;
        showData[1].text = "Damage: " + core.maxAtk;
        showData[2].text = "Hp: " + core.maxHp;
        showData[3].text = "Range: " + core.attackRange;
        showData[4].text = "Speed: " + core.speed;
    }

    public void CloseDetails()
    {
        showCharacterData.SetActive(false);
    }
}
