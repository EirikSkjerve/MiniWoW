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
    Enemy _enemy;
    public override void EnterState(Enemy enemy)
    {
        this._enemy = enemy;

        _frequency = 3;
        _moveCounter = 0;
        this._enemy.startPosition = this._enemy.transform.position;

    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Enemy stateMachineenemy)
    {
        if (_moveCounter > _frequency)
        {
            _moveCounter = 0;
            Wander();
        }
        else
        {
            _moveCounter += Time.deltaTime;
        }
    }

    void Wander()
    {
        float randX = Random.Range(_enemy.startPosition.x-10, _enemy.startPosition.x+10);
        float randY = Random.Range(_enemy.startPosition.y-10, _enemy.startPosition.y+10);
        _enemy.WalkTo(new Vector2(randX, randY));
    }


}
