using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(Enemy))]
public class EnemyState : MonoBehaviour
{
    protected Enemy enemyController;
    protected Animator enemyAnimator;



    private void Awake()
    {
        enemyAnimator = this.gameObject.GetComponent<Animator>();
        enemyController = this.gameObject.GetComponent<Enemy>();

    }

    void Start()
    {

    }



    public virtual void SetState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }

    protected void SetNextPatrolPosition(float posX, float posZ)
    {
        Vector3 newPos = new Vector3(posX, enemyController.enemyNavMesh.transform.position.y, posZ);
        enemyController.enemyNavMesh.SetDestination(newPos);
    }
    protected void ChasePosition()
    {
        enemyController.enemyNavMesh.SetDestination(enemyController.player.transform.position);
    }


}
