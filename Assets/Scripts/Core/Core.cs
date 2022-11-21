using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    [Header("Data Core")]
    [SerializeField] public string characterName;
    [SerializeField] public int maxHp;
    [SerializeField] public int maxAtk;
    [SerializeField] public bool isOwner;
    [SerializeField] public bool canMove = true;
    [SerializeField] public bool isBuilding;
    [SerializeField] public bool isRanger;
    public int currentHp;
    [HideInInspector] public int getDamage;
    [HideInInspector] public int currentAtk;

    [SerializeField] public GameObject characterSprite;

    [Header("Detector")]
    [SerializeField] public Detect detect;
    [SerializeField] public float detectRange;
    [SerializeField] public float attackRange;
    [SerializeField] public LayerMask detectLayer;
    [SerializeField] public float timeBtwHit;
    [SerializeField] public GameObject[] multiEnemy;
    [HideInInspector] public float timeBtwHitCD;
    [HideInInspector] public Transform closetEnemy;

    private void Start()
    {
        currentHp = maxHp;
        currentAtk = maxAtk;

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
}
