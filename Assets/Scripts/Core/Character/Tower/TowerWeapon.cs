using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWeapon : MonoBehaviour
{
    [Header("Tower")]
    [SerializeField] private TowerCore tower;
    [SerializeField] private GameObject weaponMesh;

    [Header("Range Combat")]
    [SerializeField] public Transform enemyTarget;
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bullet;

    private void Start()
    {

    }

    private void Update()
    {
        Attack();

        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (Transform child in weaponMesh.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            GameObject newWeap = Instantiate(TowerWeaponManager.instance.weapList[0]);
            newWeap.transform.parent = weaponMesh.transform;
            newWeap.transform.position = weaponMesh.transform.position;
            newWeap.transform.localRotation = Quaternion.Euler(Vector3.zero);
            newWeap.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private void Attack()
    {
        if (tower.Detect())
        {
            enemyTarget = tower.detect.GetClosetEnemy(tower.detectRange, tower.detectLayer);
            
            if(enemyTarget != null)
            {
                Vector3 lookDir = enemyTarget.position - transform.position;
                float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }

            if (tower.timeBtwHitCD <= 0)
            {
                if (enemyTarget != null)
                {
                    var fireball = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    fireball.GetComponent<BulletController>().Setting(tower.currentAtk, enemyTarget, !tower.isOwner);
                    tower.timeBtwHitCD = tower.timeBtwHit;
                }

                
            }
            else
            {
                tower.timeBtwHitCD -= Time.deltaTime;
            }
        }
    }
}
