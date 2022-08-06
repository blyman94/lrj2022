public abstract class PlayerBaseState
{
    protected PlayerStateMachine Context;
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void OnClickGameWorld();
}
