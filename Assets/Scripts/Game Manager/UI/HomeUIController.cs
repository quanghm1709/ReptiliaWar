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
    [SerializeField] private GameObject tileMapScreen;

    [Header("Select Map")]
    [SerializeField] private Text mapText;
    [SerializeField] private GameObject mapScreen;
    [SerializeField] private GameObject[] map;

    [Header("Load Screen")]
    public GameObject loadScreen;
    public Slider loadCD;

    [Header("Setting")]
    [SerializeField] private GameObject settingScreen;

    [SerializeField] private GameObject creditsScreen;
    [Header("Demo End")]
    public GameObject endScreen;
    public GameObject startScreen;

    

    private void Start()
    {
        instace = this;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (SaveDemo.instance.isStartGame)
        {
            startScreen.SetActive(true);
        }
        else
        {
            startScreen.SetActive(false);
        }
    }

    private void Update()
    {
        
        ActiveMap();
        DisplayCharacterUI();

        
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
            characterShowAll.SetActive(true);
            tileMapScreen.SetActive(true);
            mapScreen.SetActive(false);
            mapText.text = "BẢN ĐỒ";
        }
        else
        {
            mapScreen.SetActive(true);
            tileMapScreen.SetActive(false);
            characterShowAll.SetActive(false);
            mapText.text = "ĐỘI HÌNH";
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
        for(int i = 0; i < UsingCharacter.instance.characterUseUIList.Count; i++)
        {
            characterlistUI[i].SetActive(true);
            unlockCharacter[i].SetActive(false);
        }
    }

    public void ActiveMap()
    {
        for (int i = 0; i < MapSelect.instance.isActiveMap.Length; i++)
        {
            if (MapSelect.instance.isActiveMap[i])
            {
                map[i].SetActive(false);
            }
        }
    }

    public void CreditsScreen()
    {
        if (creditsScreen.activeInHierarchy)
        {
            creditsScreen.SetActive(false);

        }
        else
        {
            creditsScreen.SetActive(true);
        }
    }
    public void CloseDetails()
    {
        showCharacterData.SetActive(false);
        DisplayCharacterUI();
    }

    public void CloseEndScreen()
    {
        if (endScreen.activeInHierarchy)
        {
            endScreen.SetActive(false);
        }     
    }

    public void StartScreen()
    {
        if (startScreen.activeInHierarchy)
        {
            CharacterMeshUI.instance.SetupUI();
            SaveDemo.instance.isStartGame = false;
            startScreen.SetActive(false);
        }
    }

    public void ResetData()
    {
        SaveDemo.instance.ResetData();
    }
    public void QuitGame()
    {
        CharacterManager.instance.Save();
        MapSelect.instance.Save();
        Application.Quit();
    }
}
