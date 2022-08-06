public class PlayerFrontViewState : PlayerBaseState
{
    public PlayerFrontViewState(PlayerStateMachine context)
    {
        Context = context;
    }

    public override void EnterState()
    {
        Context.SwitchToFrontViewEvent.Raise();
    }

    public override void ExitState()
    {
        
    }

    public override void OnClickGameWorld()
    {
        
    }
}
