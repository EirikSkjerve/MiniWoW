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
    public override void EnterState(Enemy enemy)
    {

        _frequency = 3;
        _moveCounter = 0; 
        enemy.startPosition = enemy.transform.position;

    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Enemy enemy)
    {
        if (_moveCounter > _frequency)
        {
            _moveCounter = 0;
            enemy.WalkTo(GetRandomPosition(enemy, 10,10));
        }
        else
        {
            _moveCounter += Time.deltaTime;
        }
    }

    Vector2 GetRandomPosition(Enemy enemy, float xMax, float yMax)
    {
        float randX = Random.Range(enemy.startPosition.x-xMax, enemy.startPosition.x+xMax);
        float randY = Random.Range(enemy.startPosition.y - yMax, enemy.startPosition.y + yMax);
        //Debug.Log($"RandX is {randX}");
        //Debug.Log($"RandY is {randY}");
        return new Vector2(randX, randY);
    }


}
