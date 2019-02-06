using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : EnemyState
{
    public override void SetState()
    {
        enemyAnimator.SetTrigger("Attack");
        enemyController.enemyNavMesh.isStopped = true;

    }

    public override void UpdateState()
    {
    }
}
