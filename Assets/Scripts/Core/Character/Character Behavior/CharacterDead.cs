using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDead : State
{
    public override CharacterState GetState()
    {
        return CharacterState.Die;
    }
    public override void Action()
    {
        base.Action();
        _agent.col.isTrigger = true;
        _agent.anim.SetBool("IsDead", true);
        _agent.anim.SetBool("IsAttack", false);
        _agent.anim.SetFloat("Move", 0);
        if (_agent.isOwner)
        {
            UIController.instance.UpdateCurrentSLot(-1);
        }
        else
        {
            EnemyController.instance.UpdateCurrentSLot(-1);
        }
        
        Destroy(_agent.gameObject);
    }
}
