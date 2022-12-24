using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour
{
    public static HomeUIController instace;

    [Header("Character")]
    [SerializeField] private GameObject characterShowAll;
    [SerializeField] private GameObject showCharacterData;
    [SerializeField] private CharacterCore[] characterList;
    [SerializeField] private Text[] showData;
    [SerializeField] private GameObject[] characterlistUI;

    [Header("Select Map")]
    [SerializeField] private GameObject mapScreen;
    [SerializeField] private GameObject[] map;
    public bool[] isActiveMap;

    [Header("Load Screen")]
    public GameObject loadScreen;
    public Slider loadCD;

    [Header("Setting")]
    [SerializeField] private GameObject settingScreen;

    private void Start()
    {
        instace = this;    
    }

    private void Update()
    {
        for(int i = 0; i < isActiveMap.Length; i++)
        {
            if (isActiveMap[i])
            {
                map[i].SetActive(false);
            }
        }    
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

    public void SelectMap()
    {
        if (mapScreen.activeInHierarchy)
        {
            mapScreen.SetActive(false);
        }
        else
        {
            mapScreen.SetActive(true);
        }
    }

    public void Setting()
    {
        if (settingScreen.activeInHierarchy)
        {
            settingScreen.SetActive(false);
        }
        else
        {
            settingScreen.SetActive(true);
        }
    }

    public void CloseDetails()
    {
        showCharacterData.SetActive(false);
    }
}
