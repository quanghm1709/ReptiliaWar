using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Crystal Manager")]
    [SerializeField] private List<GameObject> myCrystalTower;
    [SerializeField] private List<GameObject> enemyCrystalTower;
    [SerializeField] private int myCrystal;
    [SerializeField] private int enemyCrystal;
    [SerializeField] private int playerAvailbleSlot;
    [SerializeField] private int enemyAvailbleSlot;

    [Header("Map Manager")]
    [SerializeField] private GameObject[] map;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CheckCrystalTower();
        Instantiate(map[MapSelect.instance.mapIndex]);     
    }

    private void Update()
    {
        DisplayPlayerCrystal();
        /*if (Input.GetMouseButtonDown(0))
        {
            DisplayTowerUI();
        }*/

    }

    public void CheckCrystalTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject tower in towers)
        {
            if (tower.GetComponent<TowerCore>().towerType == TowerType.Crystal)
            {
                if (tower.GetComponent<TowerCore>().isOwner)
                {
                    myCrystalTower.Add(tower);
                }
                else
                {
                    enemyCrystalTower.Add(tower);
                }
            }
        }
    }

    public void AddCrystal(int myCrys, int enemyCrys)
    {
        myCrystal += myCrys;
        enemyCrystal += enemyCrys;
    }

    public void Buying(int myCrys, int enemyCrys)
    {
        myCrystal -= myCrys;
        enemyCrystal -= enemyCrys;
    }

    public int GetMyCystal()
    {
        return myCrystal;
    }
    public int GetEnemyCrystal()
    {
        return enemyCrystal;
    }

    public int GetPlayerSlot()
    {
        return playerAvailbleSlot;
    }

    public int GetEnemySlot()
    {
        return enemyAvailbleSlot;
    }

    private void DisplayPlayerCrystal()
    {
        UIController.instance.playerCrystal.text = "Current crystal: " + myCrystal;
    }

    public void DisplayTowerUI()
    {
        Ray ray = UIController.instance.cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            TowerCore hitTower = raycastHit.collider.GetComponent<TowerCore>();
            if (hitTower.canBuild)
            {
                hitTower.weapUI.SetActive(true);
            }
            
        }
        else
        {
           /*GameObject[] towers = GameObject.FindGameObjectsWithTag("Building");
            Debug.Log(towers.Length);
            foreach(GameObject tower in towers)
            {
                tower.GetComponent<TowerCore>().weapUI.SetActive(false);
            }*/
        }
    }

}
