using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartResource : MonoBehaviour
{
    [Header("Crystal")]
    [SerializeField] private int playerCrystal;
    [SerializeField] private int enemyCrystal;

    private void Start()
    {
        GameManager.instance.AddCrystal(playerCrystal, enemyCrystal);
    }
}
