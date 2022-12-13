using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    Base,
    Crystal,
    Wall,
}

public class TowerCore : Core
{
    public TowerType towerType;
    public Transform spawnPoint;
    public GameObject weapUI;
    public GameObject thisTower;
    public bool canBuild;

    private void Update()
    {
        UpdateHealthUI();
        cam = Camera.main;
        weapUI.transform.LookAt(cam.transform);
    }

    public void GetDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Destroy(thisTower);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
