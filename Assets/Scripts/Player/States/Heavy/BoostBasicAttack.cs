using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBasicAttack : Skill
{
    public ParticleSystem particles;

    public float timeBeforeCooldown = 3;

    public override void Enter()
    {
        available = false;

        controller.currentSuit.basicAttack.multiplier = 2;
        particles.Play();
        controller.ChangeState(controller.idle);
    }

    public override void Exit()
    {
        StartCoroutine(MaxActiveTime());
    }

    public IEnumerator MaxActiveTime()
    {
        yield return new WaitForSeconds(timeBeforeCooldown);

        EndBoost();
    }

    public void EndBoost()
    {
        controller.currentSuit.basicAttack.multiplier = 1;

        particles.Stop();

        available = false;
        controller.cooldownManager.SetCooldown(this);
    }
}
