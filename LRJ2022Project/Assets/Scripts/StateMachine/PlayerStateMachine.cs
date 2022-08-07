using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Component References")]
    public GameObject BombCrosshairObject;

    [Header("Game Events")]
    public GameEvent SwitchToFrontViewEvent;
    public GameEvent SwitchToSideViewEvent;
    public GameEvent SwitchToTopViewEvent;

    [Header("State Data")]
    public float BombCooldownTime;

    [Header("Prefabs")]
    public GameObject BombProjectilePrefab;

    private PlayerBaseState _currentState;

    // States
    private PlayerFrontViewState _frontViewState;
    private PlayerSideViewState _sideViewState;
    private PlayerTopViewState _topViewState;

    public bool IsFirstBomb { get; set; } = true;
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
        _currentState.UpdateState();
    }

    public void SwitchStates(Perspective switchToPerspective)
    {
        PlayerBaseState newState;

        switch (switchToPerspective.PerspectiveEnum)
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

    public void SwitchStates(PerspectiveEnum switchToPerspective)
    {
        PlayerBaseState newState;

        switch (switchToPerspective)
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
        _currentState.OnClickGameWorld();
    }

    public void SpawnBombAtPosition(Vector3 spawnPos)
    {
        Instantiate(BombProjectilePrefab, spawnPos, Quaternion.identity);
    }
}
