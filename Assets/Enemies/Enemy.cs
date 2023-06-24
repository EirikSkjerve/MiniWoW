using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("States")]
    private EnemyState currentState;
    public RoamingState roamingState = new RoamingState();

    public Stats enemyStats;
    public Vector2 startPosition;

    // Start is called before the first frame update
    public override void Start()
    {
        enemyStats = new Stats();

        currentState = roamingState;

    }

    // Update is called once per frame
    public override void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}