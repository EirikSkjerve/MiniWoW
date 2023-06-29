using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombatState
{
    public abstract void EnterState(Player player);

    public abstract void UpdateState(Player player);

    public abstract void ExitState(Player player);

    // public abstract void FixedUpdateState(ref StateMachine stateMachine);

    // public abstract void OnCollissionEnter2D(ref StateMachine stateMachine);
}
