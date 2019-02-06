using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : EnemyState
{
    #region Variables
    float randomPosX;
    float randomPosZ;
    [Space(10)]

    public GameObject PosRight;
    public GameObject PosLeft;
    #endregion


    public override void SetState()
    {
        enemyAnimator.SetTrigger("Walk");
        enemyController.enemyNavMesh.isStopped = false;
        AsignRandom();
        SetNextPatrolPosition(randomPosX, randomPosZ);

    }

    public override void UpdateState()
    {
        if (!enemyController.enemyNavMesh.hasPath && enemyController.enemyNavMesh.pathStatus == NavMeshPathStatus.PathComplete)
        {
            AsignRandom();
            SetNextPatrolPosition(randomPosX, randomPosZ);
        }
    }
    public void AsignRandom()
    {
        randomPosX = Random.Range(PosLeft.transform.position.x, PosRight.transform.position.x);
        randomPosZ = Random.Range(PosLeft.transform.position.z, PosRight.transform.position.z);
    }
}
