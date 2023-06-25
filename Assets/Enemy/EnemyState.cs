///<summary>
/// Base state for a state machine.
///</summary>
public abstract class EnemyState
{
    public abstract void EnterState(Enemy stateMachineenemy);

    public abstract void UpdateState(Enemy stateMachineenemy);

    public abstract void ExitState(Enemy stateMachineenemy);

    // public abstract void FixedUpdateState(ref StateMachine stateMachine);

    // public abstract void OnCollissionEnter2D(ref StateMachine stateMachine);
}
