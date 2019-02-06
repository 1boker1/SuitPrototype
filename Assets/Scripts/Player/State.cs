using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Controller controller;

    public void Start()
    {
        controller = Controller.instance;
    }

    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }
}

public abstract class Skill : State
{
    public string button;
    public bool available = true;

    public float damage = 10f;
    public float multiplier = 1f;

    public bool hasCooldown = true;
    public float cooldown = 0f;

    public override void Exit()
    {
        if (hasCooldown)
        {
            available = false;
            controller.cooldownManager.SetCooldown(this);
        }
    }
}

