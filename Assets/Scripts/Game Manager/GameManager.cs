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
    [SerializeField] private float timeBtwCharge;
    private float timeBtwChargeCD;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CheckCrystalTower();
    }

    private void Update()
    {
        
    }

    public void CheckCrystalTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Building");
        
        foreach(GameObject tower in towers)
        {
            if(tower.GetComponent<TowerCore>().towerType == TowerType.Crystal)
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
        Debug.Log(myCrystalTower.Count);
    }

    private void CheckCrystal()
    {
        myCrystal += myCrystalTower.Count;
        enemyCrystal += enemyCrystalTower.Count;
    }
}