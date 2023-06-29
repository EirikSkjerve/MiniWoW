///<summary>
/// Base state for a state machine.
///</summary>
public abstract class PlayerMovementState
{
    public abstract void EnterState(Player player);

    public abstract void UpdateState(Player player);

    public abstract void ExitState(Player player);

    // public abstract void FixedUpdateState(ref StateMachine stateMachine);

    // public abstract void OnCollissionEnter2D(ref StateMachine stateMachine);
}