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
    [SerializeField] private float _moveCounter;
    [SerializeField] private float _frequency;
    [SerializeField] private float _maxRoamingRange;
    [SerializeField] private bool _idle;
    
    public override void EnterState(Enemy enemy)
    {

        _idle = true;
        _frequency = 3;
        _moveCounter = 0;
        enemy.currentTarget = GetRandomPosition(enemy, 8, 5);

    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Enemy enemy)
    {

        
        if ((_moveCounter > _frequency)&&_idle)
        {

            _idle = false;
            
            enemy.currentTarget = GetRandomPosition(enemy, 8, 5);

            _moveCounter = 0;
            
        }
        else if(!_idle)
        { 
            enemy.WalkTo(enemy.currentTarget);
            _moveCounter += Time.deltaTime;
        }
        else
        {
            _moveCounter += Time.deltaTime;
        }

        //if the enemy has reached its target position (within some error bound), movement is stopped and 
        // counter is set to zero
        if(((enemy.transform.position - enemy.currentTarget).magnitude < 0.1f) && !_idle)
        {
            _idle = true;
            
            enemy.currentTarget = GetRandomPosition(enemy, 8, 5);
            //enemy.body.velocity = new Vector2(0, 0);
            
            _moveCounter = 0;

        }
    }



    Vector3 GetRandomPosition(Enemy enemy, float xMax, float yMax)
    {
        float randX = Random.Range(enemy.startPosition.x-xMax, enemy.startPosition.x+xMax);
        float randY = Random.Range(enemy.startPosition.y - yMax, enemy.startPosition.y + yMax);

        return new Vector3(randX, randY, enemy.transform.position.z);
    }


}
