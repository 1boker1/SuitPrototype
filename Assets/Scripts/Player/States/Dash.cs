using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : State
{
    public float dashSpeed = 7f;
    public float dashDuration = 0.25f;

    public bool mouseDirection = false;

    public float timer = 0;
    public float initalSpeed = 0;

    public override void Enter()
    {
        controller = Controller.instance;

        controller.animator.SetBool("Dashing", true);

        if (mouseDirection)
        {
            controller.transform.forward = (controller.MouseWorldPosition() - controller.transform.position).normalized;
        }

        controller.rigidBody.velocity = controller.transform.forward * dashSpeed;
    }

    public override void Execute()
    {
        timer += Time.deltaTime;

        if (timer >= dashDuration)
        {
            timer = 0;

            controller.ReturnToBaseState();
        }
    }

    public override void Exit()
    {
        controller.animator.SetBool("Dashing", false);

        controller.rigidBody.velocity = Vector3.zero;
    }
}
