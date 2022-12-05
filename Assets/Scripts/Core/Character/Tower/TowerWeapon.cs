using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWeapon : MonoBehaviour
{
    [Header("Tower")]
    [SerializeField] private TowerCore tower;

    [Header("Range Combat")]
    [SerializeField] public float rangeRange;
    [SerializeField] public Transform enemyTarget;
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bullet;

    private int currentAtk;
    private float timeBtwHit;
    private float timeBtwHitCD;
    private float attackRange;

    private void Start()
    {
        currentAtk = tower.currentAtk;
        attackRange = tower.attackRange;
        timeBtwHitCD = 0;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (tower.Detect())
        {
            if (timeBtwHitCD <= 0)
            {
                
                enemyTarget = tower.detect.GetClosetEnemy(tower.detectRange, tower.detectLayer);

                if (enemyTarget != null)
                {
                    Debug.Log("Fire");
                    var fireball = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    fireball.GetComponent<BulletController>().Setting(tower.currentAtk, enemyTarget, !tower.isOwner);
                    timeBtwHitCD = tower.timeBtwHit;
                }

                
            }
            else
            {
                timeBtwHitCD -= Time.deltaTime;
            }
        }
    }
}
