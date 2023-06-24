using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RoamingState : EnemyState
{
    float counter;
    Enemy enemy;
    public override void EnterState(Enemy enemy)
    {
        counter = 0;
        enemy.enemyStats.moveSpeed = 3;
        enemy.startPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        this.enemy = enemy;
    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Enemy stateMachineenemy)
    {
        if (counter > 3)
        {
            counter = 0;
            Wander();
        }
        else
        {
            counter += Time.deltaTime;
        }
    }

    void Wander()
    {
        float randX = Random.Range(-10, 10);
        float randY = Random.Range(-10, 10);
        Vector2 test = new Vector2(randX, randY).normalized * enemy.enemyStats.moveSpeed;
        //enemy.body.velocity = 
    }


}
