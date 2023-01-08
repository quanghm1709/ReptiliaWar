using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    [SerializeField] private int playerCrystal;
    [SerializeField] private int enemyCrystal;
    [SerializeField] private float timeBtwCharge;
    private float timeBtwChargeCD;

    private void Start()
    {
        timeBtwChargeCD = timeBtwCharge;    
    }

    private void Update()
    {
        AddCrystal();
    }

    private void AddCrystal()
    {
        if(timeBtwChargeCD <= 0)
        {
            GameManager.instance.AddCrystal(playerCrystal, enemyCrystal);
            timeBtwChargeCD = timeBtwCharge;
        }
        else
        {
            timeBtwChargeCD -= Time.deltaTime;
        }
    }
}
