using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //public static Enemy instance;


    public enum State {IDLE, PATROL, CHASE, ATTACK };
    public State currentState;
    public GameObject player;
    [HideInInspector]
    public NavMeshAgent enemyNavMesh;
    public float distanceForChase;
    public float distanceForAttack;


    [Header("States")]
    public EnemyState patrol;
    public EnemyState chase;
    public EnemyState attack;


    private void Awake()
    {
        enemyNavMesh = this.gameObject.GetComponent<NavMeshAgent>();

        //if (instance == null) instance = this;
        //if (instance != this) Destroy(this);
    }

    #region Var
    public float health;



    #endregion

    private void Start()
    {
        currentState = State.IDLE;
        
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.IDLE:
                ChangeState(State.PATROL);
                break;

            case State.PATROL:
                patrol.UpdateState();

                if(CalculateDistance() <= distanceForChase)
                {
                    ChangeState(State.CHASE);
                }
                break;

            case State.CHASE:
                chase.UpdateState();
                if(CalculateDistance() <= distanceForAttack)
                {
                    ChangeState(State.ATTACK);
                }
                else if (CalculateDistance() > distanceForChase)
                {
                    ChangeState(State.PATROL);
                }
                break;
            case State.ATTACK:
                if(CalculateDistance() > distanceForAttack)
                {
                    if(CalculateDistance() > distanceForChase)
                    {
                        ChangeState(State.PATROL);
                    }
                    else
                    {
                        ChangeState(State.CHASE);
                    }
                }
                break;
        }
    }

    #region Functions
    public void OnHit(float damage) { }

    private void ChangeState(State newState)
    {

        switch (currentState)
        {
            case State.IDLE:
                
                break;
            case State.CHASE:

                break;
            case State.ATTACK:

                break;
        }

        switch (newState)
        {
            case State.IDLE:
                break;
            case State.PATROL:
                patrol.SetState();
                break;
            case State.CHASE:
                chase.SetState();
                break;
            case State.ATTACK:
                attack.SetState();
                break;
        }
        currentState = newState;
    }

    public float CalculateDistance()
    {
        Vector2 PlayerVector2 = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 EnemyVector2 = new Vector2(enemyNavMesh.transform.position.x, enemyNavMesh.transform.position.z);
        return Vector2.Distance(PlayerVector2, EnemyVector2);
    }

    #endregion

}
