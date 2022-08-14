
public abstract class PlayerBaseState
{
    public PerspectiveEnum Perspective;
    protected PlayerStateMachine Context;
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void OnClickGameWorld();
    public abstract void OnReload();
    public abstract void UpdateState();
}
