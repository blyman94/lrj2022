using UnityEngine;

public class PlayerTopViewState : PlayerBaseState
{
    private float _bombCooldownTimer;

    private bool bombReady = false;

    public PlayerTopViewState(PlayerStateMachine context)
    {
        Context = context;
        Perspective = PerspectiveEnum.TOP;
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
        if (_bombCooldownTimer <= 0)
        {
            Vector3 BombSpawnPos = new Vector3(Context.MousePosition.x, 64, Context.MousePosition.y);
            Context.SpawnBombAtPosition(BombSpawnPos);
            _bombCooldownTimer = Context.BombCooldownTime;
            bombReady = false;

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
            new Vector3(Context.MousePosition.x, 32.0f, Context.MousePosition.y);

        if (_bombCooldownTimer > 0)
        {
            
            _bombCooldownTimer -= Time.deltaTime;
        }
        else if (!bombReady)
        {
            Context.BombReady.Raise();
            bombReady = true;
        }
    }
}
