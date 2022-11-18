using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : State
{

    public override CharacterState GetState()
    {
        return CharacterState.Moving;
    }
    public override void Action()
    {
        base.Action();
        Transform direction = _agent.detect.GetClosetEnemy(_agent.detectRange, _agent.detectLayer);
        Transform tower = _agent.detect.GetClosetBuilding(_agent.isOwner);

        if (direction != null)
        {
            _agent.movePos = direction;
        }
        else
        {
            _agent.movePos = tower.transform;
        }


        if (!_agent.Detect() && _agent.canMove)
        {
            _agent.navMeshAgent.speed = _agent.speed;
            _agent.navMeshAgent.destination = _agent.movePos.position;
            _agent.anim.SetBool("IsAttack", false);
            _agent.anim.SetFloat("Move", 1);
        }
        else
        {
            _agent.ChangeState(CharacterState.Attack);
        }
    }
}
