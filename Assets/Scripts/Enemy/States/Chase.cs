using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : EnemyState
{
    

    public override void SetState()
    {
        enemyAnimator.SetTrigger("Run");
        enemyController.enemyNavMesh.speed = 5.0f;
        enemyController.enemyNavMesh.isStopped = false;

    }

    public override void UpdateState()
    {
        ChasePosition();
    }
}
