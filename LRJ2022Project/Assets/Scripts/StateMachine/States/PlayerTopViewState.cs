using UnityEngine;

public class PlayerTopViewState : PlayerBaseState
{
    public PlayerTopViewState(PlayerStateMachine context)
    {
        Context = context;
    }

    public override void EnterState()
    {
        Context.SwitchToTopViewEvent.Raise();
        Context.BombCrosshairObject.SetActive(true);
    }

    public override void ExitState()
    {
        Context.BombCrosshairObject.SetActive(false);
    }

    public override void OnClickGameWorld()
    {
        if (Context.BombCooldownTimer <= 0)
        {
            Vector3 BombSpawnPos = new Vector3(Context.MousePosition.x, 64, Context.MousePosition.y);
            Context.SpawnBombAtPosition(BombSpawnPos);
            Context.SwitchStates(PerspectiveEnum.SIDE);
        }
    }

    public override void UpdateState()
    {
        Context.BombCrosshairObject.transform.position =
            new Vector3(Context.MousePosition.x, 1.0f, Context.MousePosition.y);
    }
}
