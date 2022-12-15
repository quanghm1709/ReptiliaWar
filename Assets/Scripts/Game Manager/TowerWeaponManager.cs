using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWeaponManager : MonoBehaviour
{
    public static TowerWeaponManager instance;

    [Header("Weap Mesh")]
    public GameObject[] weapList;
    public int[] price;

    private void Start()
    {
        instance = this;
    }
}
