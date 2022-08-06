using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Game Events")]
    public GameEvent SwitchToFrontViewEvent;
    public GameEvent SwitchToSideViewEvent;
    public GameEvent SwitchToTopViewEvent;

    [Header("State Data")]
    public float BombCooldownTimer;

    private PlayerBaseState _currentState;

    // States
    private PlayerFrontViewState _frontViewState;
    private PlayerSideViewState _sideViewState;
    private PlayerTopViewState _topViewState;

    public Vector2 MousePosition { get; set; }

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

    public void SwitchStates(Perspective switchToPerspective)
    {
        PlayerBaseState newState;

        switch (switchToPerspective.perspectiveEnum)
        {
            case (PerspectiveEnum.FRONT):
                newState = _frontViewState;
                break;
            case (PerspectiveEnum.SIDE):
                newState = _sideViewState;
                break;
            case (PerspectiveEnum.TOP):
                newState = _topViewState;
                break;
            default:
                newState = _currentState;
                Debug.LogError("Perspective not recognized by " +
                    "PlayerStateMachine.SwitchStates().");
                break;
        }

        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void OnClickGameWorld()
    {
        Debug.Log("Called");
        _currentState.OnClickGameWorld();
    }
}
