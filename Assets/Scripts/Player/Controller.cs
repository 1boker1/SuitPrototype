using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    #region Singleton

    public static Controller instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(this);
    }

    #endregion

    public Vector3 movement;
    public Rigidbody rigidBody;
    public Animator animator;

    private StateMachine stateMachine = new StateMachine();

    public State currentState;

    [Header("Basic States")]
    public State idle;
    public State walk;
    public State dash;

    [Header("Abilities")]

    public Suit currentSuit;

    public Skill skillOne;
    public Skill skillTwo;
    public Skill skillThree;

    public CooldownManager cooldownManager;

    private void Start()
    {
        cooldownManager = CooldownManager.instance;

        ChangeState(idle);
    }

    private void Update()
    {
        stateMachine.ExecuteState();

        if (currentState == idle || currentState == walk)
        {
            if (Input.GetButton(skillOne.button) && skillOne.available) ChangeState(skillOne);
            if (Input.GetButton(skillTwo.button) && skillTwo.available) ChangeState(skillTwo);
            //if (Input.GetButton(skillThree.button) && skillThree.available) ChangeState(skillThree);
        }
    }

    public void ChangeSkill(Skill skill)
    {
        if (Input.GetButton(skill.button) && skill.available) ChangeState(skill);
    }

    public void ChangeState(State state)
    {
        stateMachine.ChangeState(state);

        currentState = stateMachine.currentState;
    }

    public void ReturnToBaseState()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            ChangeState(walk);
        }
        else
        {
            ChangeState(idle);
        }
    }

    public Vector3 MouseWorldPosition()
    {
        Vector3 mousePosition = Vector3.zero;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }

        return mousePosition;
    }
}