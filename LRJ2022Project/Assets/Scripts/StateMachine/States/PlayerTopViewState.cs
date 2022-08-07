using UnityEngine;

public class PlayerTopViewState : PlayerBaseState
{
    private float _bombCooldownTimer;

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
        if (_bombCooldownTimer <= 0)
        {
            Vector3 BombSpawnPos = new Vector3(Context.MousePosition.x, 64, Context.MousePosition.y);
            Context.SpawnBombAtPosition(BombSpawnPos);
            _bombCooldownTimer = Context.BombCooldownTime;

            if (Context.IsFirstBomb)
            {
                Context.SwitchStates(PerspectiveEnum.SIDE);
                Context.IsFirstBomb = false;
            }
        }
    }

    public override void UpdateState()
    {
        Context.BombCrosshairObject.transform.position =
            new Vector3(Context.MousePosition.x, 1.0f, Context.MousePosition.y);

        if (_bombCooldownTimer > 0)
        {
            _bombCooldownTimer -= Time.deltaTime;
        }
    }
}
