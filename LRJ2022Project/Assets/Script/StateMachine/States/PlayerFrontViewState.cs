public class PlayerFrontViewState : PlayerBaseState
{
    public PlayerFrontViewState(PlayerStateMachine context)
    {
        Context = context;
    }

    public override void EnterState()
    {
        Context.FrontViewCam.Priority = 10;
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnClickGameWorld()
    {
        
    }

    public override void OnGameWorldHover()
    {
        
    }
}
