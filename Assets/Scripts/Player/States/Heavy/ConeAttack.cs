using UnityEngine;
using System.Collections;

public class ConeAttack : Skill
{
    public GameObject effects;
    public Transform spawnPosition;

    public override void Enter()
    {
        controller.animator.SetTrigger("Attack");
    }

    public override void Execute()
    {
        controller.rigidBody.velocity = Vector3.zero;
    }

    public void OnAttack()
    {
        GameObject attack = Instantiate(effects, spawnPosition.position, transform.rotation);

        attack.GetComponentInChildren<OnParticleTrigger>().damage = damage * multiplier;

        if (multiplier != 1)
        {
            GetComponent<BoostBasicAttack>().StopAllCoroutines();
            GetComponent<BoostBasicAttack>().EndBoost();
        }
    }
}
