using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
// The enemy class represents an enemy object. Inherits from Entity
public class Enemy : Entity
{
    //the states of the enemy
    [Header("States")]
    private EnemyState _currentState;
    private RoamingState _roamingState;

    //enemys may not have their own combat stats in the future.
    private CombatStats _enemyCombatStats;
    
    //the spawn/start-position for the enemy. Used to decide how far it will walk while roaming 
    public Vector2 startPosition;
    
    //the current "target" as a position. This should be changed later to only be included in the roaming state,
    //since target should be an entity object when enemy is in combat state
    public Vector3 currentTargetPosition;
    
    // Start is called before the first frame update
    public override void Start()
    {

        //runspeed, startposition and state initialized.
        SetRunSpeed(8f);
        startPosition = transform.position;
        _roamingState = new RoamingState();
        _currentState = _roamingState;
        
        // a state needs to be entered
        _currentState.EnterState(this);

    }

    // Update is called once per frame
    public override void Update()
    {
        //updates the current sate
        _currentState.UpdateState(this);
    }

    //changes the state from the current to a new state
    public void ChangeState(EnemyState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
    
    //instructs the enemy to walk to designated coordinates
    //todo:
    //since this method is called from an update method in RoamingState, the direction and calculations should not have to be calculated many times
    public void WalkTo(Vector3 targetPosition)
    {
        // a new movement direction is calculated by subtracting the target position from the current position
        var currentPosition = transform.position;
        var xDir = targetPosition.x - currentPosition.x;
        var yDir = targetPosition.y - currentPosition.y;
        var movementDirection = new Vector2(xDir, yDir);
        
        //this is for smooth movement
        var inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        
        //vector is normalized so that diagonal movement does not exceed movementspeed
        movementDirection.Normalize();
        
        //the enemy's position is translated towards the target.
        transform.Translate(movementDirection * (GetWalkSpeed() * inputMagnitude * Time.deltaTime), Space.World);
        SetCurrentDirection(new Vector2(movementDirection.x, movementDirection.y));
        
        
    }
    
    //see WalkTo()
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