using UnityEngine;
using Cinemachine;

public class PlayerStateMachine : MonoBehaviour
{
    public CinemachineVirtualCamera FrontViewCam;
    public CinemachineVirtualCamera SideViewCam;
    public CinemachineVirtualCamera TopViewCam;

    private PlayerBaseState _currentState;

    // States
    private PlayerFrontViewState _frontViewState;
    private PlayerSideViewState _sideViewState;
    private PlayerTopViewState _topViewState;

    public float BombCooldownTimer;

    private void Awake()
    {
        _frontViewState = new PlayerFrontViewState(this);
        _sideViewState = new PlayerSideViewState(this);
        _topViewState = new PlayerTopViewState(this);
    }

    private void Start()
    {
        _currentState = _topViewState;
        _currentState.EnterState();
    }

    private void Update()
    {
        if (BombCooldownTimer >= 0)
        {
            BombCooldownTimer -= Time.deltaTime;
        }
    }

    public void SwitchStates(PlayerBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void OnClickGameWorld()
    {
        _currentState.OnClickGameWorld();
    }

    public void OnGameWorldHover()
    {
        _currentState.OnGameWorldHover();
    }
}
