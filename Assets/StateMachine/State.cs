///<summary>
/// Base state for a state machine.
///</summary>
public abstract class State
{
    public abstract void EnterState(StateMachine stateMachine);

    public abstract void UpdateState(StateMachine stateMachine);

    public abstract void ExitState(StateMachine stateMachine);

    // public abstract void FixedUpdateState(ref StateMachine stateMachine);
    
    // public abstract void OnCollissionEnter2D(ref StateMachine stateMachine);
}
