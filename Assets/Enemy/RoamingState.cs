using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

///<summary>
/// The roaming state for an enemy. Given some interval of time, enemy should randomly walk around
/// in an area around its starting position
///</summary>
public class RoamingState : EnemyState
{
    private Enemy enemy;
    
    //the counter that tracks seconds
    [SerializeField] private float _moveCounter;
    //the amount of seconds an enemy should roam and stand still before changing direction
    [SerializeField] private float _frequency;
    
    //bool that controls whether the enemy is in an idle state. Used for standing still while roaming
    [SerializeField] private bool _idle;
    
    public override void EnterState(Enemy enemy)
    {
        this.enemy = enemy;
        _idle = true;
        _frequency = 1;
        _moveCounter = 0;
        
        //initializes the enemy's current target position with a random value 
        enemy.currentTargetPosition = GetRandomPosition( 8, 5);

    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Enemy enemy)
    {
        
        Roam();
        
    }

    //method controlling the roaming of an enemy
    private void Roam()
    {
        //if the enemy is standing still and the counter has exceeded the frequency, compute a new random target position to walk to,
        //reset the counter and make it able to move again
        if ((_moveCounter > _frequency)&&_idle)
        {

            _idle = false;
            enemy.currentTargetPosition = GetRandomPosition(8, 5);
            _moveCounter = 0;
            
        }
        
        //if the counter isn't high enough, and the enemy can move, walk towards the target position.
        //Increment the counter
        else if(!_idle)
        { 
            enemy.WalkTo(enemy.currentTargetPosition);
            _moveCounter += Time.deltaTime;

        }

        //if the enemy cannot move, but counter is not yet high enough, only increment the counter.
        else
        {
            _moveCounter += Time.deltaTime;
        }

        //if the enemy has reached its target position (within some error bound), movement is stopped and 
        // counter is set to zero. A new random target is computed.
        if(((enemy.transform.position - enemy.currentTargetPosition).magnitude < 0.1f) && !_idle)
        {
            _idle = true;
            
            enemy.currentTargetPosition = GetRandomPosition(8, 5);

            _moveCounter = 0;

        }
    }

    //computes a set of random coordinates, and returns a Vector3 with x and y as the random new coordinates, and z as the same old. 
    Vector3 GetRandomPosition(float xMax, float yMax)
    {
        var randX = Random.Range(enemy.startPosition.x-xMax, enemy.startPosition.x+xMax);
        var randY = Random.Range(enemy.startPosition.y - yMax, enemy.startPosition.y + yMax);
        
        return new Vector3(randX, randY, enemy.transform.position.z);
    }


}
