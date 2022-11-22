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

    private void Update()
    {
        UpdateHealthUI();
    }

    public void GetDamage(int damage)
    {
        currentHp -= damage;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
