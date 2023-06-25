using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("States")]
    private EnemyState _currentState;

    private RoamingState _roamingState;

    public Stats EnemyStats;
    public Vector2 startPosition;

    // Start is called before the first frame update
    public override void Start()
    {
        EnemyStats = new Stats();
        _roamingState = new RoamingState();
        _currentState = _roamingState;

    }

    // Update is called once per frame
    public override void Update()
    {
        _currentState.UpdateState(this);
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
}