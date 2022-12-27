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
    [SerializeField] private GameObject[] unlockCharacter;

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
        DisplayCharacterUI();
    }

    private void Update()
    {
        
        ActiveMap();
    }

    public void ShowDetails(int index)
    {
        showCharacterData.SetActive(true);
        CharacterCore core = characterList[index];

        for(int i = 0; i < characterlistUI.Length; i++)
        {
            if(i != index)
            {
                characterlistUI[i].SetActive(false);
            }
        }

        showData[0].text =  core.name;
        showData[1].text = ": " + core.maxAtk;
        showData[2].text = ": " + core.maxHp;
        showData[3].text = ": " + core.speed;
        showData[4].text = ": " + core.attackRange;
        showData[5].text = ": " + core.range;
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

    public void DisplayCharacterUI()
    {
        for(int i = 0; i < CharacterManager.instance.isActive.Length; i++)
        {
            if (CharacterManager.instance.isActive[i])
            {
                characterlistUI[i].SetActive(true);
                unlockCharacter[i].SetActive(false);
            }
        }
    }

    public void ActiveMap()
    {
        for (int i = 0; i < isActiveMap.Length; i++)
        {
            if (isActiveMap[i])
            {
                map[i].SetActive(false);
            }
        }
    }

    public void CloseDetails()
    {
        showCharacterData.SetActive(false);
        DisplayCharacterUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
