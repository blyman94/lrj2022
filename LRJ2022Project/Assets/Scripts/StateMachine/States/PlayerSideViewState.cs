
public class PlayerSideViewState : PlayerBaseState
{
    public PlayerSideViewState(PlayerStateMachine context)
    {
        Context = context;
        Perspective = PerspectiveEnum.SIDE;
    }

    public override void EnterState()
    {
        Context.SwitchToSideViewEvent.Raise();
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
