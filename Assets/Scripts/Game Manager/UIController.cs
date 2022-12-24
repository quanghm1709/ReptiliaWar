using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Camera cam;
    [SerializeField] public Text playerCrystal;
    [SerializeField] private Text mes;
    [SerializeField] private Text pop;
    public GameObject GameOverPanel;
    [SerializeField] public List<Image> buyCD;
    [SerializeField] private GameObject[] selectCharBtn;
    private int currentSlot;
    private float activeMes = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for(int i = 0; i < CharacterManager.instance.isActive.Length; i++)
        {
            if (CharacterManager.instance.isActive[i])
            {
                selectCharBtn[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(activeMes <= 0)
        {
            mes.gameObject.SetActive(false);
        }
        else
        {
            activeMes -= Time.deltaTime;
        }

        pop.text = "Pop: " + currentSlot + "/" + GameManager.instance.GetPlayerSlot();
    }

    public void SpawnCharacter(int index)
    {
        Transform spwanpoint = GameObject.Find("Tower").GetComponent<TowerCore>().spawnPoint;
        int unitPrice = CharacterManager.instance.playerCharacterList[index].character.GetComponent<CharacterCore>().unitPrice;

        if(unitPrice <= GameManager.instance.GetMyCystal() && currentSlot < GameManager.instance.GetPlayerSlot() && CharacterManager.instance.playerCharacterList[index].canBuy)
        {
            Instantiate(CharacterManager.instance.playerCharacterList[index].character, spwanpoint.position, spwanpoint.rotation);
            GameManager.instance.Buying(unitPrice, 0);
            UpdateCurrentSLot(1);
            CharacterManager.instance.SetBuyCD(index);
        }
        
    }

    public void ActiveMessage()
    {
        mes.gameObject.SetActive(true);
        activeMes = 3f;
    }

    public void UpdateCurrentSLot(int slot)
    {
        currentSlot += slot;
    }
}
