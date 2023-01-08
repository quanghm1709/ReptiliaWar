using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Camera cam;

    [Header("Player Data")]
    [SerializeField] public Text playerCrystal;
    [SerializeField] private Text mes;
    [SerializeField] private Text pop;

    [Header("Game End Screen")]
    public GameObject GameOverPanel;
    public GameObject winPanel;

    [Header("Character UI")]
    [SerializeField] public List<Image> buyCD;
    [SerializeField] private GameObject[] selectCharBtn;

    [Header("Pause Screen")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject quitConfirm;

    [Header("Load Screen")]
    public GameObject loadScreen;
    public Slider loadCD;

    [Header("Build UI")]
    [SerializeField] private GameObject buildBaseTower;
    [SerializeField] private GameObject buildTowerWeap;
    [SerializeField] private GameObject baseTower;
    private Transform buildTarget;
    private bool onBuild;

    private int currentSlot;
    private float activeMes = 0;
    private bool isUIactive = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
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
       
        if (Input.GetMouseButtonDown(0) && !isUIactive)
        {
            BuildTowerUI();
        }
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
            UsingCharacter.instance.SetBuyCD(index);
        }
        
    }

    private void BuildTowerUI()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            TowerCore hitTower = raycastHit.collider.GetComponent<TowerCore>();
            if(hitTower != null)
            {
                if (hitTower.canBuild)
                {
                    buildTarget = hitTower.gameObject.transform;
                    buildTowerWeap.SetActive(true);
                    onBuild = true;
                }
            }
            else
            {
                TileBuild tile = raycastHit.collider.GetComponent<TileBuild>();
                if (tile.canBuild)
                {
                    buildBaseTower.SetActive(true);
                    buildTarget = tile.gameObject.transform;
                    onBuild = true;
                }              
            }

        }
        else
        {
            if (!onBuild)
            {
                buildBaseTower.SetActive(false);
            }
        }
    }

    public void BuildTowerWeap(int index)
    {
        buildTarget.GetComponentInChildren<BuildTowerWeapBtn>().Build(index);
        buildTowerWeap.SetActive(false);
    }

    public void BuilBase(int cost)
    {
        if (GameManager.instance.GetMyCystal() >= cost)
        {
            GameObject newWeap = Instantiate(baseTower);
            newWeap.transform.position = new Vector3(buildTarget.transform.position.x, 1.1f, buildTarget.transform.position.z);
            newWeap.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            newWeap.transform.localScale = new Vector3(1, 1, 1);

            GameManager.instance.Buying(cost, 0);
            buildTarget.GetComponent<TileBuild>().canBuild = false;
        }
        else
        {
            UIController.instance.ActiveMessage();
        }
        buildBaseTower.SetActive(false);
    }

    public void CancelBuild()
    {
        buildTarget = null;
        if (buildBaseTower.activeInHierarchy)
        {
            buildBaseTower.SetActive(false);
        }
        if (buildTowerWeap.activeInHierarchy)
        {
            buildTowerWeap.SetActive(false);
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

    public void PauseScreen()
    {
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
            isUIactive = false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseScreen.SetActive(true);
            isUIactive = true;
            Time.timeScale = 0f;
        }
    }

    public void QuitConfirm()
    {
        if (quitConfirm.activeInHierarchy)
        {
            quitConfirm.SetActive(false);
        }
        else
        {
            quitConfirm.SetActive(true);
        }
    }

    public void Home()
    {       
        SceneManager.LoadScene("HomeScene");
    }
}
