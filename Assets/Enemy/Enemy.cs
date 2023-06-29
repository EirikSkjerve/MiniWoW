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
    public void WalkTo(Vector3 targetPosition)
    {
        var position1 = transform.position;
        var xDir = targetPosition.x - position1.x;
        var yDir = targetPosition.y - position1.y;
        var movementDirection = new Vector2(xDir, yDir);
        var inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
            
        transform.Translate(movementDirection * (GetWalkSpeed() * inputMagnitude * Time.deltaTime), Space.World);
        SetCurrentDirection(new Vector2(movementDirection.x, movementDirection.y));
        //.velocity = new Vector2(position.x - position1.x, position.y - position1.y).normalized * GetWalkSpeed();
        
    }
    
    public void RunTo(Vector3 targetPosition)
    {
        var position1 = transform.position;
        var xDir = targetPosition.x - position1.x;
        var yDir = targetPosition.y - position1.y;
        var movementDirection = new Vector2(xDir, yDir);
        var inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
            
        transform.Translate(movementDirection * (GetRunSpeed() * inputMagnitude * Time.deltaTime), Space.World);
        SetCurrentDirection(new Vector2(movementDirection.x, movementDirection.y));
    }

    public void RotateToDirection()
    {
 
            //todo implement rotation

    }
}