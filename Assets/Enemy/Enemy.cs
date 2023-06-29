using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Entity
{
    [Header("States")]
    private EnemyState _currentState;
    private RoamingState _roamingState;

    
    private Stats _enemyStats;
    public Vector2 startPosition;
    public Vector3 currentTarget;
    
    // Start is called before the first frame update
    public override void Start()
    {

        SetRunSpeed(8f);
        startPosition = transform.position;
        _roamingState = new RoamingState();
        _currentState = _roamingState;
        _currentState.EnterState(this);

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
    public void WalkTo(Vector3 position)
    {
        body.velocity = new Vector2(position.x - transform.position.x, position.y - transform.position.y).normalized * GetRunSpeed();
        
    }
    
    public void RunTo(Vector3 position)
    {
        body.velocity = new Vector2(position.x - transform.position.x, position.y - transform.position.y).normalized * GetWalkSpeed();
    }

    public void RotateToDirection()
    {
 
            //todo implement rotation

    }
}