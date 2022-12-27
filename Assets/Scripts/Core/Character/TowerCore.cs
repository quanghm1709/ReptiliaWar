using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    Base,
    Crystal,
    Wall,
    HQ,
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
        //weapUI.transform.LookAt(cam.transform);
    }

    public void GetDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            
            if (towerType == TowerType.HQ)
            {
                Time.timeScale = 0f;
                if (!isOwner)
                {
                    UIController.instance.winPanel.SetActive(true);
                    WinReward reward = transform.GetComponent<WinReward>();
                    if (reward.reward.Count > 0)
                    {
                        reward.Unlock();
                    }
                    if(MapSelect.instance.mapIndex == 2)
                    {
                        Demo1End.instance.SetEnd();
                    }
                }
                else
                {
                    UIController.instance.GameOverPanel.SetActive(true);
                }
                GameManager.instance.RemoveNav();
                
            }
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
