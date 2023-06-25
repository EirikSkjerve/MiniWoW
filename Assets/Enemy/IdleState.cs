using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    
    public override void EnterState(Enemy stateMachineenemy)
    {
        Debug.Log("Entered Idle state");
    }

    public override void UpdateState(Enemy stateMachineenemy)
    {
        
    }

    public override void ExitState(Enemy stateMachineenemy)
    {
        Debug.Log("Exiting Idle State");
    }
}
