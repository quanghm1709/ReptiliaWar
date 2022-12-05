using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : CharacterCore
{
    private void Update()
    {
        var curState = GetState(_characterState);
        curState.Init(this);
        curState.Action();

        UpdateHealthUI();
    }

    public override void UpdateHealthUI()
    {
         base.UpdateHealthUI();
    }

    private State GetState(CharacterState characterState)
    {
        foreach (var state in states)
        {
            if (state.GetState() == characterState)
                return state;
        }
        return null;
    }

    public override void ChangeState(CharacterState characterState)
    {
        _characterState = characterState;
    }

    public override bool Detect()
    {
        return base.Detect();
    }

    public override void SetTotalDamageToGet(int damage)
    {
        base.SetTotalDamageToGet(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
