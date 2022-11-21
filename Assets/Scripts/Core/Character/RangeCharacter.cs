using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCharacter : CharacterCore
{
    public override void ChangeState(CharacterState troopState)
    {
        throw new System.NotImplementedException();
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
