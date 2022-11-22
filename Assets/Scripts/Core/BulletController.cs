using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] private bool isEnemyBullet;
    [SerializeField] private float lifeTime;
    private Vector3 enemy;
    private int damage;

    private void Start()
    {

    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, enemy, speed * Time.deltaTime);
    }

    public void Setting(int damage, Transform target, bool isEnemy)
    {
        this.damage = damage;
        this.enemy = target.position;
        this.isEnemyBullet = isEnemy;
    }

    private void OnTriggerEnter(Collider enemy)
    {

        if (enemy.tag != "Ground")
        {
            if (enemy.gameObject.GetComponent<Core>().isBuilding)
            {
                enemy.gameObject.GetComponent<TowerCore>().GetDamage(damage);
            }
            else
            {
                enemy.gameObject.GetComponent<Core>().SetTotalDamageToGet(damage);
                enemy.gameObject.GetComponent<CharacterCore>().ChangeState(CharacterState.GetDamage);
            }
            Destroy(gameObject);
        }
    }

}
