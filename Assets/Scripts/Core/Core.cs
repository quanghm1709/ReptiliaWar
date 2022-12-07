using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Core : MonoBehaviour
{
    [Header("Data Core")]
    public string characterName;
    public int maxHp;
    public int maxAtk;
    public bool isOwner;
    public bool canMove = true;
    public bool canAttack;
    public bool isBuilding;
    public bool isRanger;
    public int currentHp;
    [HideInInspector] public int getDamage;
    [HideInInspector] public int currentAtk;

     public GameObject characterSprite;

    [Header("Detector")]
    public Detect detect;
    public float detectRange;
    public float attackRange;
    public LayerMask detectLayer;
    public float timeBtwHit;
    [HideInInspector] public float timeBtwHitCD;
    [HideInInspector] public Transform closetEnemy;

    [Header("UI")]
     public Slider healthBar;
     public GameObject healthBarCanvas;

    [HideInInspector]
    public Camera cam;
    private void Start()
    {
        currentHp = maxHp;
        currentAtk = maxAtk;

        cam = Camera.main;
    }

    public virtual bool Detect()
    {
        return detect.Detecting(attackRange, detectLayer);
    }
    public virtual Transform ClosetEnemy()
    {
        return detect.GetClosetEnemy(detectRange, detectLayer);
    }
    public virtual Transform ClosetBuilding()
    {
        return detect.GetClosetBuilding(isOwner);
    }
    public virtual void SetTotalDamageToGet(int damage)
    {
        getDamage = damage;
    }

    public virtual void UpdateHealthUI()
    {
        healthBarCanvas.transform.LookAt(cam.transform);
        healthBar.value = currentHp;
        healthBar.maxValue = maxHp;
    }
}
