public class PlayerTopViewState : PlayerBaseState
{
    public PlayerTopViewState(PlayerStateMachine context)
    {
        Context = context;
    }

    public override void EnterState()
    {

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

    public override void OnGameWorldHover()
    {

    }
}
