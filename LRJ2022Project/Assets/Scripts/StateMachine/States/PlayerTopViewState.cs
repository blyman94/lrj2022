public class PlayerTopViewState : PlayerBaseState
{
    public PlayerTopViewState(PlayerStateMachine context)
    {
        Context = context;
    }

    public override void EnterState()
    {
        Context.SwitchToTopViewEvent.Raise();
    }

    public override void ExitState()
    {

    }

    public override void OnClickGameWorld()
    {
        if (Context.BombCooldownTimer <= 0)
        {
            Context.BombCooldownTimer = 5.0f;
        }
    }
}
