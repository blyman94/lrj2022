public class PlayerFrontViewState : PlayerBaseState
{
    public PlayerFrontViewState(PlayerStateMachine context)
    {
        Context = context;
        Perspective = PerspectiveEnum.FRONT;
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

    public override void UpdateState()
    {
        
    }
}
