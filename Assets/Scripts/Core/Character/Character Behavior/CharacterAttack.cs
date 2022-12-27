using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : State
{
    public override CharacterState GetState()
    {
        return CharacterState.Attack;
    }
    public override void Action()
    {
        base.Action();
        
        if (_agent.Detect())
        {
            _agent.rb.velocity = Vector3.zero;
            _agent.navMeshAgent.speed = 0;

            Vector3 lookDir = _agent.ClosetEnemy().position - _agent.transform.position;
            float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;
            _agent.transform.rotation = Quaternion.Euler(0, angle, 0);

            if (_agent.timeBtwHitCD <= 0)
            {
                _agent.anim.SetBool("IsAttack", true);
                _agent.anim.SetFloat("Move", 0);
                if (!_agent.isRanger)
                {
                    MeleeAttack();
                }
                else
                {
                    RangeAttack();
                }
                _agent.timeBtwHitCD = _agent.timeBtwHit;
            }
            else
            {
                _agent.anim.SetBool("IsAttack", false);
                _agent.anim.SetFloat("Move", 0);
                _agent.timeBtwHitCD -= Time.deltaTime;
            }
        }
        else
        {
            _agent.ChangeState(CharacterState.Moving);
        }
    }

    private void MeleeAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_agent.hitPoint.position, _agent.range, _agent.detectLayer);
        
        if (_agent.isOwner)
        {
            foreach (Collider enemy in hitColliders)
            {
                if (!enemy.gameObject.GetComponent<Core>().isOwner)
                {
                    CheckTargetType(enemy);
                }
            }
        }
        else
        {
            foreach (Collider enemy in hitColliders)
            {
                if (enemy.gameObject.GetComponent<Core>().isOwner)
                {
                    CheckTargetType(enemy);
                }
            }
        }
    }

    private void RangeAttack()
    {
        _agent.enemyTarget = _agent.detect.GetClosetEnemy(_agent.detectRange, _agent.detectLayer);

        if (_agent.enemyTarget == null)
        {
            _agent.enemyTarget = _agent.detect.GetClosetBuilding(_agent.isOwner);
        }

        var fireball = Instantiate(_agent.bullet, _agent.firePoint.position, _agent.firePoint.rotation);
        fireball.GetComponent<BulletController>().Setting(_agent.currentAtk, _agent.enemyTarget,!_agent.isOwner);
    }

    private void CheckTargetType(Collider enemy)
    {
        if (enemy.gameObject.GetComponent<Core>().isBuilding)
        {
            enemy.gameObject.GetComponent<TowerCore>().GetDamage(_agent.currentAtk);
        }
        else
        {
            enemy.gameObject.GetComponent<Core>().SetTotalDamageToGet(_agent.currentAtk);
            enemy.gameObject.GetComponent<CharacterCore>().ChangeState(CharacterState.GetDamage);
        }
    }
}
