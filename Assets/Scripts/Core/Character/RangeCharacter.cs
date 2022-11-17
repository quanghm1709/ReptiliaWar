using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCharacter : Core
{
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
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange + 3);
    }
}
